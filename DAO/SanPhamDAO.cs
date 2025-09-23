using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyJewelry.DAO
{
    internal class SanPhamDAO
    {
        private static SanPhamDAO instance;
        internal static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return instance;
            }
        }

        private SanPhamDAO() { }

        // Lấy danh sách sản phẩm
        public DataTable Xem()
        {
            string sql = @"
                SELECT 
                    s.MaSanPham,
                    s.TenSanPham,
                    l.TenLoaiHang AS LoaiHang,
                    s.GiaBan,
                    s.MoTa,
                    s.HinhAnh AS AnhFile
                FROM SANPHAM s
                INNER JOIN LOAIHANG l ON l.ID = s.MaLoaiHang";

            return KetNoiSql.Instance.execSql(sql);
        }

        // Thêm sản phẩm
        public bool Them(SANPHAM p)
        {
            string sql = @"
                INSERT INTO SANPHAM(TenSanPham, MaLoaiHang, MoTa, GiaBan, HinhAnh) 
                VALUES(@tensp, @maloaihang, @mota, @gia, @anh)";

            var parameters = new Dictionary<string, object>
            {
                { "@tensp", p.TenSanPham },
                { "@maloaihang", p.MaLoaiHang },
                { "@mota", p.MoTa },
                { "@gia", p.GiaBan },
                { "@anh", p.HinhAnh }
            };

            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }

        // Xóa sản phẩm
        public bool Xoa(string maSP)
        {
            string sql = "DELETE FROM SANPHAM WHERE MaSanPham = @masp";
            var parameters = new Dictionary<string, object>
    {
        { "@masp", maSP }
    };
            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }


        // Sửa sản phẩm
        public bool Sua(SANPHAM sp)
        {
            string sql = @"
                UPDATE SANPHAM 
                SET TenSanPham = @tensp, 
                    MaLoaiHang = @mal, 
                    GiaBan = @gia, 
                    HinhAnh = @anh, 
                    MoTa = @mota 
                WHERE MaSanPham = @masp";

            var parameters = new Dictionary<string, object>
            {
                { "@tensp", sp.TenSanPham },
                { "@mal", sp.MaLoaiHang },
                { "@gia", sp.GiaBan },
                { "@anh", sp.HinhAnh },
                { "@mota", sp.MoTa },
                { "@masp", sp.MaSanPham }
            };

            return KetNoiSql.Instance.execNonSql(sql, parameters) > 0;
        }

        // Tìm sản phẩm theo tên (phải lấy cả ảnh để load lên form)
        public DataTable Tim(string name)
        {
            string sql = @"
                SELECT 
                    s.MaSanPham,
                    s.TenSanPham,
                    l.TenLoaiHang,
                    s.GiaBan,
                    s.MoTa,
                    s.HinhAnh AS AnhFile
                FROM SANPHAM s 
                INNER JOIN LOAIHANG l ON l.ID = s.MaLoaiHang
                WHERE s.TenSanPham LIKE @keyword";

            var parameters = new Dictionary<string, object>
            {
                { "@keyword", "%" + name + "%" }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        // Lấy list sản phẩm (model)
        public List<SANPHAM> GetDataSanPham()
        {
            return KetNoiSql.Instance.getDataSanPham();
        }

        // Lấy mã sản phẩm theo tên
        public DataTable GetMaSanPham(string tenSP)
        {
            string sql = "SELECT MaSanPham, TenSanPham FROM SANPHAM WHERE TenSanPham = @tensp";
            var parameters = new Dictionary<string, object>
            {
                { "@tensp", tenSP }
            };
            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        // Load dữ liệu vào combobox
        public void SetCbx(ComboBox b, string table, string displayMember)
        {
            string sql = "SELECT * FROM " + table;
            DataTable data = KetNoiSql.Instance.execSql(sql);
            b.DataSource = data;
            b.DisplayMember = displayMember;
        }
    }
}
