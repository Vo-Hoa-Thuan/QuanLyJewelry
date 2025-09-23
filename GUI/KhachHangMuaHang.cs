using QuanLyJewelry.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyJewelry.GUI
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
            this.Size = new Size(1200, 600);
            this.MinimumSize = new Size(1200, 520);
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);

            // Header
            var pnlTop = new Panel();
            UITheme.StyleHeaderPanel(pnlTop, "Danh sách sản phẩm đã mua");
            var lblTitle = new Label
            {
                AutoSize = true
            };
            pnlTop.Controls.Add(lblTitle);

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToResizeRows = false,
                ColumnHeadersHeight = 36
            };
            UITheme.StyleDataGrid(_grid);
            this.Controls.Add(_grid);
            this.Controls.Add(pnlTop);

            this.Load += FrmKhachHangMuaHang_Load;
        }

        private void FrmKhachHangMuaHang_Load(object? sender, EventArgs e)
        {
            DataTable dt = ThongKeBLL.Instance.LaySanPhamDaMuaKhachHang(_maKhachHang, _nam, _thang);
            if (dt == null || dt.Rows.Count == 0)
            {
                // Fallback: hiển thị tất cả giao dịch của KH nếu tháng/năm không có dữ liệu
                dt = ThongKeBLL.Instance.LaySanPhamDaMuaKhachHangAll(_maKhachHang);
            }
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
                _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _grid.AutoResizeColumns();
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // frmKhachHangMuaHang
            // 
            ClientSize = new Size(358, 253);
            Name = "frmKhachHangMuaHang";
            ResumeLayout(false);

        }
    }
}



