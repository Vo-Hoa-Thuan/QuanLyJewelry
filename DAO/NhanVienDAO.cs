using QuanLyJewelry.Model;
using QuanLyJewelry.Properties;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyJewelry.DAO
{
    internal class NhanVienDAO
    {
        private static NhanVienDAO instance;

        internal static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            }
        }

        private NhanVienDAO() { }

        // Lấy thông tin nhân viên theo số điện thoại
        //public DataTable GetByPhone(string phone)
        //{
        //    string sql = "SELECT ID, MaNhanVien, HoTen, SoDienThoai, Email, CCCD, NgayVao, MaQuyen, MatKhau " +
        //                 "FROM NHANVIEN WHERE SoDienThoai = @sdt";
        //    object[] prms = new object[] { phone };
        //    return KetNoiSql.Instance.execSql(sql, prms);
        //}

        //// Xem toàn bộ nhân viên
        //public DataTable Xem()
        //{
        //    string sql = "SELECT n.ID, n.MaNhanVien, n.HoTen, q.TenQuyen, n.CCCD, n.SoDienThoai, n.DiaChi, n.Email, n.NgayVao " +
        //                 "FROM NHANVIEN n JOIN QUYEN q ON n.MaQuyen = q.ID";
        //    return KetNoiSql.Instance.execSql(sql);
        //}
        public DataRow GetNhanVienByMa(string maNV)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE MaNhanVien = @maNV";

            var prms = new Dictionary<string, object>
    {
        { "@maNV", maNV }
    };

            DataTable dt = KetNoiSql.Instance.execSql(sql, prms);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }


        // Xem toàn bộ nhân viên
        public DataTable Xem()
        {
            string sql = @"SELECT n.ID, 
                          n.MaNhanVien, 
                          n.HoTen, 
                          q.TenQuyen, 
                          n.CCCD, 
                          n.SoDienThoai, 
                          n.DiaChi, 
                          n.Email, 
                          n.NgayVao
                   FROM NHANVIEN n 
                   JOIN QUYEN q ON n.MaQuyen = q.ID";
            return KetNoiSql.Instance.execSql(sql);
        }


        // Thêm nhân viên mới (mật khẩu mặc định = hash(số điện thoại))
        // Thêm nhân viên mới (mật khẩu mặc định = số điện thoại dạng plain text)
        // Thêm nhân viên mới (mật khẩu mặc định = số điện thoại)
        public bool Them(NHANVIEN nv)
        {
            string sql = "INSERT INTO NHANVIEN (HoTen, SoDienThoai, Email, CCCD, MaQuyen, MatKhau) " +
                         "VALUES (@hoten, @sdt, @email, @cccd, @maquyen, @matkhau)";

            var prms = new Dictionary<string, object>
    {
        { "@hoten", nv.HoTen },
        { "@sdt", nv.SoDienThoai },
        { "@email", nv.Email },
        { "@cccd", nv.CCCD },
        { "@maquyen", nv.MaQuyen },
        { "@matkhau", nv.SoDienThoai } // mật khẩu mặc định = số điện thoại
    };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Xóa nhân viên
        public bool Xoa(int id)
        {
            string sql = "DELETE FROM NHANVIEN WHERE ID = @id";

            var prms = new Dictionary<string, object>
    {
        { "@id", id }
    };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Sửa thông tin nhân viên (không đổi mật khẩu)
        public bool Sua(NHANVIEN nv)
        {
            string sql = "UPDATE NHANVIEN SET HoTen = @hoten, SoDienThoai = @sdt, Email = @email, CCCD = @cccd, MaQuyen = @maquyen " +
                         "WHERE ID = @id";

            var prms = new Dictionary<string, object>
    {
        { "@hoten", nv.HoTen },
        { "@sdt", nv.SoDienThoai },
        { "@email", nv.Email },
        { "@cccd", nv.CCCD },
        { "@maquyen", nv.MaQuyen },
        { "@id", nv.ID }
    };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }


        // Đăng nhập (kiểm tra tài khoản/mật khẩu đã hash)
        // Đăng nhập
        public DataRow DangNhap(string maNV, string matKhauNhap)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE MaNhanVien = @maNV";

            var prms = new Dictionary<string, object>
    {
        { "@maNV", maNV }
    };

            DataTable dt = KetNoiSql.Instance.execSql(sql, prms);

            if (dt.Rows.Count == 0)
                return null;

            DataRow nv = dt.Rows[0];
            string matKhauTrongDB = nv["MatKhau"].ToString();
            string soDT = nv["SoDienThoai"].ToString();

            // 1. Lần đầu login (mật khẩu = số điện thoại plain text)
            if (matKhauTrongDB == soDT)
            {
                if (matKhauNhap == soDT)
                    return nv; // login thành công -> ép đổi mật khẩu
                return null; // sai mật khẩu
            }

            // 2. Các lần sau, so sánh bằng hash
            if (!SecurityHelper.VerifyPassword(matKhauNhap, matKhauTrongDB))
                return null;

            return nv;
        }



        // Đổi mật khẩu
        public bool DoiMatKhau(string maNV, string matKhauMoi)
        {
            string matKhauHash = SecurityHelper.HashPassword(matKhauMoi);

            string sql = "UPDATE NHANVIEN SET MatKhau = @matkhau WHERE MaNhanVien = @maNV";

            // Chỉ dùng Dictionary<string, object>
            var prms = new Dictionary<string, object>
    {
        { "@matkhau", matKhauHash },
        { "@maNV", maNV }
    };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }


    }
}
