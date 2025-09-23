using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyJewelry.DAO
{
    internal class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        internal static NhaCungCapDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapDAO();
                return instance;
            }
        }
        private NhaCungCapDAO() { }

        // Xem toàn bộ danh sách NCC
        public DataTable Xem()
        {
            string sql = @"SELECT ID, MaNhaCungCap, TenNhaCungCap, SoDienThoai, DiaChi, Email, NguoiDaiDien, NgayTao 
                           FROM NHACUNGCAP";
            return KetNoiSql.Instance.execSql(sql);
        }

        // Thêm NCC mới
        public bool Them(NHACUNGCAP p)
        {
            string sql = @"INSERT INTO NHACUNGCAP(TenNhaCungCap, SoDienThoai, DiaChi, Email, NguoiDaiDien) 
                           VALUES(@tenncc, @sodienthoai, @diachi, @email, @nguoidd)";
            var prms = new Dictionary<string, object>
            {
                ["@tenncc"] = p.TenNhaCungCap,
                ["@sodienthoai"] = p.SoDienThoai,
                ["@diachi"] = p.DiaChi,
                ["@email"] = p.Email,
                ["@nguoidd"] = p.NguoiDaiDien
            };
            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Xóa NCC theo ID
        public bool Xoa(int id)
        {
            string sql = "DELETE FROM NHACUNGCAP WHERE ID = @id";
            var prms = new Dictionary<string, object>
            {
                ["@id"] = id
            };
            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Sửa thông tin NCC theo ID
        public bool Sua(NHACUNGCAP ncc)
        {
            string sql = @"UPDATE NHACUNGCAP 
                           SET TenNhaCungCap = @tenncc, 
                               SoDienThoai   = @sdt, 
                               DiaChi        = @diachi,
                               Email         = @email, 
                               NguoiDaiDien  = @nguoidd
                           WHERE ID = @id";

            var prms = new Dictionary<string, object>
            {
                ["@tenncc"] = ncc.TenNhaCungCap,
                ["@sdt"] = ncc.SoDienThoai,
                ["@diachi"] = ncc.DiaChi,
                ["@email"] = ncc.Email,
                ["@nguoidd"] = ncc.NguoiDaiDien,
                ["@id"] = ncc.ID
            };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Tìm NCC theo tên
        public DataTable Tim(string name)
        {
            string sql = "SELECT ID, MaNhaCungCap, TenNhaCungCap, SoDienThoai, DiaChi, Email, NguoiDaiDien, NgayTao " +
                         "FROM NHACUNGCAP WHERE TenNhaCungCap LIKE @keyword";
            var prms = new Dictionary<string, object>
            {
                ["@keyword"] = "%" + name + "%"
            };
            return KetNoiSql.Instance.execSql(sql, prms);
        }

        // Lấy toàn bộ NCC dưới dạng List<Model>
        public List<NHACUNGCAP> getDataNhaCungCap()
        {
            return KetNoiSql.Instance.getDataNhaCungCap();
        }

        // Lấy NCC theo tên (an toàn hơn với param)
        public DataTable getMaNhaCungCap(string tenNCC)
        {
            string sql = "SELECT MaNhaCungCap, TenNhaCungCap FROM NHACUNGCAP WHERE TenNhaCungCap = @tenncc";
            var prms = new Dictionary<string, object>
            {
                ["@tenncc"] = tenNCC
            };
            return KetNoiSql.Instance.execSql(sql, prms);
        }
    }
}
