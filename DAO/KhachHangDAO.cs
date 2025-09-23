using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyJewelry.DAO
{
    internal class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }

        private KhachHangDAO() { }

        public DataTable LayTatCaKhachHang()
        {
            string sql = "SELECT ID, MaKhachHang, HoTen, SoDienThoai, Email, DiaChi, NgayVao FROM KHACHHANG ORDER BY NgayVao DESC";
            return KetNoiSql.Instance.execSql(sql);
        }

        public KHACHHANG LayKhachHangTheoID(int id)
        {
            string sql = "SELECT ID, MaKhachHang, HoTen, SoDienThoai, Email, DiaChi, NgayVao FROM KHACHHANG WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                { "@ID", id }
            };

            DataTable dt = KetNoiSql.Instance.execSql(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new KHACHHANG
                {
                    ID = Convert.ToInt32(row["ID"]),
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    NgayVao = Convert.ToDateTime(row["NgayVao"])
                };
            }

            return null;
        }

        public bool ThemKhachHang(KHACHHANG kh)
        {
            string sql = @"INSERT INTO KHACHHANG (HoTen, SoDienThoai, Email, DiaChi, NgayVao) 
                           VALUES (@HoTen, @SoDienThoai, @Email, @DiaChi, @NgayVao)";

            var parameters = new Dictionary<string, object>
            {
                { "@HoTen", kh.HoTen },
                { "@SoDienThoai", kh.SoDienThoai },
                { "@Email", kh.Email ?? (object)DBNull.Value },
                { "@DiaChi", kh.DiaChi ?? (object)DBNull.Value },
                { "@NgayVao", kh.NgayVao }
            };

            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }

        public bool CapNhatKhachHang(KHACHHANG kh)
        {
            string sql = @"UPDATE KHACHHANG 
                           SET HoTen = @HoTen, 
                               SoDienThoai = @SoDienThoai, 
                               Email = @Email, 
                               DiaChi = @DiaChi 
                           WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                { "@ID", kh.ID },
                { "@HoTen", kh.HoTen },
                { "@SoDienThoai", kh.SoDienThoai },
                { "@Email", kh.Email ?? (object)DBNull.Value },
                { "@DiaChi", kh.DiaChi ?? (object)DBNull.Value }
            };

            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }

        public bool XoaKhachHang(int id)
        {
            string sql = "DELETE FROM KHACHHANG WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                { "@ID", id }
            };

            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }

        public DataTable TimKiemKhachHang(string keyword)
        {
            string sql = @"SELECT ID, MaKhachHang, HoTen, SoDienThoai, Email, DiaChi, NgayVao 
                           FROM KHACHHANG 
                           WHERE HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword OR MaKhachHang LIKE @Keyword
                           ORDER BY NgayVao DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Keyword", "%" + keyword + "%" }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LaySanPhamDaMua(int maKH)
        {
            string sql = @"
        SELECT 
            SP.TenSanPham,
            ISNULL(CTGD.DonGia, SP.GiaBan) AS DonGia,
            CTGD.SoLuong,
            (ISNULL(CTGD.DonGia, SP.GiaBan) * CTGD.SoLuong) AS ThanhTien,
            GD.NgayGD AS NgayMua
        FROM CHITIETGIAODICH CTGD
        INNER JOIN SANPHAM SP ON CTGD.MaSanPham = SP.ID
        INNER JOIN GIAODICH GD ON CTGD.MaGD = GD.ID
        WHERE GD.MaKhachHang = @MaKH
          AND GD.LoaiGD = 'BAN_RA'
        ORDER BY GD.NgayGD DESC;";

            var parameters = new Dictionary<string, object>
    {
        { "@MaKH", maKH }
    };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }



        public bool KiemTraSoDienThoaiTonTai(string soDienThoai, int? excludeId = null)
        {
            string sql = "SELECT COUNT(*) FROM KHACHHANG WHERE SoDienThoai = @SoDienThoai";

            var parameters = new Dictionary<string, object>
            {
                { "@SoDienThoai", soDienThoai }
            };

            if (excludeId.HasValue)
            {
                sql += " AND ID != @ID";
                parameters.Add("@ID", excludeId.Value);
            }

            object result = KetNoiSql.Instance.execScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}