using QuanLyJewelry.Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public class frmKhachHangMuaHang : Form
    {
        private readonly int _maKhachHang;
        private readonly int _nam;
        private readonly int _thang;
        private DataGridView _grid;

        public frmKhachHangMuaHang(int maKhachHang, int nam, int thang)
        {
            _maKhachHang = maKhachHang;
            _nam = nam;
            _thang = thang;

            this.Text = "Sản phẩm đã mua";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(900, 600);

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 11)
            };
            this.Controls.Add(_grid);

            this.Load += FrmKhachHangMuaHang_Load;
        }

        private void FrmKhachHangMuaHang_Load(object? sender, EventArgs e)
        {
            DataTable dt = ThongKeBUS.Instance.LaySanPhamDaMuaKhachHang(_maKhachHang, _nam, _thang);
            _grid.DataSource = dt;
            if (dt != null && dt.Columns.Count > 0)
            {
                if (dt.Columns.Contains("NgayGD"))
                {
                    _grid.Columns["NgayGD"].HeaderText = "Ngày GD";
                    _grid.Columns["NgayGD"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dt.Columns.Contains("TenSanPham")) _grid.Columns["TenSanPham"].HeaderText = "Sản phẩm";
                if (dt.Columns.Contains("SoLuong")) _grid.Columns["SoLuong"].HeaderText = "Số lượng";
                if (dt.Columns.Contains("DonGia")) { _grid.Columns["DonGia"].HeaderText = "Đơn giá"; _grid.Columns["DonGia"].DefaultCellStyle.Format = "N0"; }
                if (dt.Columns.Contains("ThanhTien")) { _grid.Columns["ThanhTien"].HeaderText = "Thành tiền"; _grid.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; }
            }
        }
    }
}



