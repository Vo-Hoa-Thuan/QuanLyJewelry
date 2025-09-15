using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyJewelry.Business
{
    internal class SanPhamBUS
    {
        private static SanPhamBUS instance;
        internal static SanPhamBUS Instance
        {
            get
            {
                if (instance == null) instance = new SanPhamBUS();
                return instance;
            }
        }
        private SanPhamBUS() { }

        // ====== HIỂN THỊ SẢN PHẨM ======
        public void Xem(DataGridView dgv)
        {
            // Lấy dữ liệu từ DAO (có join LOAIHANG)
            DataTable dt = SanPhamDAO.Instance.Xem() ?? new DataTable();

            // Thêm cột HìnhAnh kiểu Image nếu chưa có
            if (!dt.Columns.Contains("HinhAnh"))
                dt.Columns.Add("HinhAnh", typeof(Image));

            string folderPath = Path.Combine(Application.StartupPath, "Hinhanh");

            // Chuyển tên file ảnh thành Image để hiển thị
            foreach (DataRow row in dt.Rows)
            {
                string fileName = row["AnhFile"]?.ToString() ?? "";
                string fullPath = Path.Combine(folderPath, fileName);

                if (!string.IsNullOrEmpty(fileName) && File.Exists(fullPath))
                {
                    using (var img = Image.FromFile(fullPath))
                    {
                        row["HinhAnh"] = new Bitmap(img);
                    }
                }
                else
                {
                    row["HinhAnh"] = null;
                }
            }

            dgv.DataSource = dt;

            // Đặt header cho các cột
            if (dgv.Columns.Contains("MaSanPham"))
                dgv.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            if (dgv.Columns.Contains("TenSanPham"))
                dgv.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            if (dgv.Columns.Contains("LoaiHang"))
                dgv.Columns["LoaiHang"].HeaderText = "Loại hàng";
            if (dgv.Columns.Contains("GiaBan"))
                dgv.Columns["GiaBan"].HeaderText = "Giá bán";
            if (dgv.Columns.Contains("MoTa"))
                dgv.Columns["MoTa"].HeaderText = "Mô tả";

            // Cột ảnh
            if (dgv.Columns.Contains("HinhAnh") && dgv.Columns["HinhAnh"] is DataGridViewImageColumn imgCol)
            {
                dgv.Columns["HinhAnh"].HeaderText = "Hình ảnh";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            // Ẩn cột file gốc
            if (dgv.Columns.Contains("AnhFile"))
                dgv.Columns["AnhFile"].Visible = false;

            dgv.RowTemplate.Height = 70; // chiều cao hàng hiển thị ảnh
        }


        // ====== TÌM KIẾM SẢN PHẨM ======
        public void Tim(DataGridView dgv, string ten)
        {
            DataTable dt = SanPhamDAO.Instance.Tim(ten) ?? new DataTable();

            if (!dt.Columns.Contains("HinhAnh"))
                dt.Columns.Add("HinhAnh", typeof(Image));

            string folderPath = Path.Combine(Application.StartupPath, "Resources", "Hinhanh");

            foreach (DataRow row in dt.Rows)
            {
                string fileName = row["AnhFile"]?.ToString() ?? "";
                string fullPath = Path.Combine(folderPath, fileName);

                if (!string.IsNullOrEmpty(fileName) && File.Exists(fullPath))
                {
                    using (var img = Image.FromFile(fullPath))
                    {
                        row["HinhAnh"] = new Bitmap(img);
                    }
                }
                else
                {
                    row["HinhAnh"] = null;
                }
            }

            dgv.DataSource = dt;
            SetDgvColumnHeaders(dgv);

            if (dgv.Columns.Contains("AnhFile"))
                dgv.Columns["AnhFile"].Visible = false;

            if (dgv.Columns.Contains("HinhAnh") && dgv.Columns["HinhAnh"] is DataGridViewImageColumn imgCol)
            {
                dgv.Columns["HinhAnh"].HeaderText = "Hình ảnh";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            dgv.RowTemplate.Height = Math.Max(dgv.RowTemplate.Height, 64);
        }

        // ====== THÊM SẢN PHẨM ======
        public string Them(SANPHAM sp)
        {
            if (string.IsNullOrEmpty(sp.TenSanPham)) return "errorTen";
            if (sp.MaLoaiHang <= 0) return "errorMal";
            if (string.IsNullOrEmpty(sp.HinhAnh)) return "errorAnh";
            if (sp.GiaBan <= 0) return "errorGia";

            bool result = SanPhamDAO.Instance.Them(sp);
            return result ? "success" : "error";
        }

        // ====== SỬA SẢN PHẨM ======
        public string Sua(SANPHAM sp)
        {
            if (string.IsNullOrEmpty(sp.MaSanPham)) return "errorMa";
            if (string.IsNullOrEmpty(sp.TenSanPham)) return "errorTen";
            if (sp.MaLoaiHang <= 0) return "errorMal";
            if (string.IsNullOrEmpty(sp.HinhAnh)) return "errorAnh";
            if (sp.GiaBan <= 0) return "errorGia";

            bool result = SanPhamDAO.Instance.Sua(sp);
            return result ? "success" : "error";
        }

        // ====== XÓA SẢN PHẨM ======
        public bool Xoa(DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return false;
            string code = dgv.CurrentRow.Cells["MaSanPham"].Value?.ToString();
            if (string.IsNullOrEmpty(code)) return false;

            return SanPhamDAO.Instance.Xoa(code);
        }

        // ====== LẤY DANH SÁCH SẢN PHẨM CHO COMBOBOX ======
        public void GetDataSanPham(ComboBox cb)
        {
            List<SANPHAM> list = SanPhamDAO.Instance.GetDataSanPham();
            cb.DataSource = list;
            cb.DisplayMember = "TenSanPham";
            cb.ValueMember = "MaSanPham";
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }

        // ====== LẤY MÃ SẢN PHẨM THEO TÊN ======
        public string GetMaSanPham(string ten)
        {
            DataTable dt = SanPhamDAO.Instance.GetMaSanPham(ten);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                if (row["TenSanPham"]?.ToString() == ten)
                    return row["MaSanPham"]?.ToString();
            }
            return null;
        }

        // ====== CẬP NHẬT HEADER CỘT DGV ======
        private void SetDgvColumnHeaders(DataGridView dgv)
        {
            if (dgv.Columns.Contains("MaSanPham"))
                dgv.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            if (dgv.Columns.Contains("TenSanPham"))
                dgv.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            if (dgv.Columns.Contains("TenLoaiHang"))
                dgv.Columns["TenLoaiHang"].HeaderText = "Loại hàng";
            if (dgv.Columns.Contains("GiaBan"))
                dgv.Columns["GiaBan"].HeaderText = "Giá bán";
            if (dgv.Columns.Contains("MoTa"))
                dgv.Columns["MoTa"].HeaderText = "Mô tả";
        }
    }
}
