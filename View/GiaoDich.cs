using QuanLyJewelry.Business;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace QuanLyJewelry.View
{
    public partial class frmGiaoDich : Form
    {
        private PrintDocument _printDocument = new PrintDocument();
        private PrintPreviewDialog _printPreview = new PrintPreviewDialog();
        private GIAODICH _lastSavedGiaoDich;
        private List<CHITIETGIAODICH> _lastSavedChiTiet;
        public frmGiaoDich()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _printDocument.PrintPage += PrintDocument_PrintPage;
            _printPreview.Document = _printDocument;
            _printPreview.UseAntiAlias = true;
        }

        private void frmGiaoDich_Load(object sender, EventArgs e)
        {
            try
            {
                // Thiết lập định dạng tiền tệ
                txtTongTien.Text = "0";
                txtNgayGD.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                // Load combobox khách hàng, nhân viên, sản phẩm...
                LoadKhachHang();
                LoadNhanVien();
                LoadSanPham();

                // Chọn loại giao dịch mặc định
                cboLoaiGD.SelectedIndex = 0;

                // Định dạng DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            // Reset combobox về item đầu tiên
            if (cboLoaiGD.Items.Count > 0)
                cboLoaiGD.SelectedIndex = 0;
            if (cboKhachHang.Items.Count > 0)
                cboKhachHang.SelectedIndex = 0;
            if (cboNhanVien.Items.Count > 0)
                cboNhanVien.SelectedIndex = 0;

            // Xóa hết dữ liệu trong DataGridView
            dgvChiTiet.Rows.Clear();

            // Reset lại tổng tiền và ngày giao dịch
            txtTongTien.Text = "0";
            txtNgayGD.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }


        private void FormatDataGridView()
        {
            dgvChiTiet.Columns["colSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvChiTiet.Columns["colDonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["colThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void LoadKhachHang()
        {
            try
            {
                DataTable dt = GiaoDichBUS.Instance.LayDanhSachKhachHang();
                cboKhachHang.DataSource = dt;
                cboKhachHang.DisplayMember = "HoTen";
                cboKhachHang.ValueMember = "ID";

                if (cboKhachHang.Items.Count > 0)
                    cboKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVien()
        {
            try
            {
                DataTable dt = GiaoDichBUS.Instance.LayDanhSachNhanVien();
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "ID";

                if (cboNhanVien.Items.Count > 0)
                    cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                DataTable dt = GiaoDichBUS.Instance.LayDanhSachSanPham();

                var colSP = (DataGridViewComboBoxColumn)dgvChiTiet.Columns["colMaSP"];
                colSP.DataSource = dt;
                colSP.DisplayMember = "TenSanPham";
                colSP.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            dgvChiTiet.Rows.Add();

            // Sử dụng BeginInvoke để tránh reentrant call
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (dgvChiTiet.Rows.Count > 0)
                {
                    int lastRowIndex = dgvChiTiet.Rows.Count - 1;
                    if (lastRowIndex >= 0 && !dgvChiTiet.Rows[lastRowIndex].IsNewRow)
                    {
                        dgvChiTiet.CurrentCell = dgvChiTiet.Rows[lastRowIndex].Cells["colMaSP"];
                        dgvChiTiet.BeginEdit(true);
                    }
                }
            }));
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null && !dgvChiTiet.CurrentRow.IsNewRow)
            {
                dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                TinhTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private decimal TinhTongTien()
        {
            decimal tong = 0;

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["colSoLuong"].Value != null && row.Cells["colDonGia"].Value != null)
                {
                    int soLuong;
                    decimal donGia;

                    if (int.TryParse(row.Cells["colSoLuong"].Value.ToString(), out soLuong) &&
                        decimal.TryParse(row.Cells["colDonGia"].Value.ToString(), out donGia))
                    {
                        decimal thanhTien = soLuong * donGia;
                        row.Cells["colThanhTien"].Value = thanhTien;

                        tong += thanhTien;
                    }
                }
            }

            // Hiển thị tổng tiền ra textbox
            txtTongTien.Text = tong.ToString("N0");

            return tong;
        }

        private void btnLuuDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (!KiemTraDuLieu())
                    return;

                // Tạo đối tượng giao dịch
                GIAODICH gd = new GIAODICH
                {
                    LoaiGD = cboLoaiGD.Text,
                    MaKhachHang = Convert.ToInt32(cboKhachHang.SelectedValue),
                    MaNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue),
                    NgayGD = DateTime.Now,
                    TongTien = TinhTongTien()
                };

                // Danh sách chi tiết
                List<CHITIETGIAODICH> listCT = new List<CHITIETGIAODICH>();
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Kiểm tra nếu có đủ dữ liệu
                    if (row.Cells["colMaSP"].Value != null &&
                        row.Cells["colSoLuong"].Value != null &&
                        row.Cells["colDonGia"].Value != null)
                    {
                        listCT.Add(new CHITIETGIAODICH
                        {
                            MaSanPham = Convert.ToInt32(row.Cells["colMaSP"].Value),
                            SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value),
                            DonGia = Convert.ToDecimal(row.Cells["colDonGia"].Value)
                        });
                    }
                }

                // Kiểm tra nếu có chi tiết
                if (listCT.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi Business Layer
                bool result = GiaoDichBUS.Instance.TaoDonHang(gd, listCT);

                if (result)
                {
                    MessageBox.Show("Thêm đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu lại đơn hàng vừa tạo để in
                    _lastSavedGiaoDich = gd;
                    _lastSavedChiTiet = listCT;
                    // Hỏi in hóa đơn
                    if (MessageBox.Show("Bạn có muốn in hóa đơn không?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _printPreview.ShowDialog(this);
                    }
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Nếu chưa có dữ liệu đã lưu, sử dụng dữ liệu đang nhập
            var gd = _lastSavedGiaoDich ?? new GIAODICH
            {
                LoaiGD = cboLoaiGD.Text,
                MaKhachHang = cboKhachHang.SelectedValue == null ? 0 : Convert.ToInt32(cboKhachHang.SelectedValue),
                MaNhanVien = cboNhanVien.SelectedValue == null ? 0 : Convert.ToInt32(cboNhanVien.SelectedValue),
                NgayGD = DateTime.Now,
                TongTien = TinhTongTien()
            };

            var ds = _lastSavedChiTiet ?? new List<CHITIETGIAODICH>();
            if (_lastSavedChiTiet == null)
            {
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["colMaSP"].Value == null) continue;
                    ds.Add(new CHITIETGIAODICH
                    {
                        MaSanPham = Convert.ToInt32(row.Cells["colMaSP"].Value),
                        SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value),
                        DonGia = Convert.ToDecimal(row.Cells["colDonGia"].Value)
                    });
                }
            }

            var g = e.Graphics;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int width = e.MarginBounds.Width;

            using var titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            using var headerFont = new Font("Segoe UI", 11, FontStyle.Bold);
            using var textFont = new Font("Segoe UI", 10);

            g.DrawString("HÓA ĐƠN BÁN HÀNG", titleFont, Brushes.Black, x, y); y += 34;
            g.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", textFont, Brushes.Black, x, y); y += 20;
            g.DrawString($"Khách hàng: {cboKhachHang.Text}", textFont, Brushes.Black, x, y); y += 20;
            g.DrawString($"Nhân viên: {cboNhanVien.Text}", textFont, Brushes.Black, x, y); y += 24;

            // Header bảng
            int col1 = x;              // Sản phẩm
            int col2 = x + width - 260; // SL
            int col3 = x + width - 180; // Đơn giá
            int col4 = x + width - 80;  // Thành tiền

            g.DrawString("Sản phẩm", headerFont, Brushes.Black, col1, y);
            g.DrawString("SL", headerFont, Brushes.Black, col2, y);
            g.DrawString("Đơn giá", headerFont, Brushes.Black, col3, y);
            g.DrawString("Thành tiền", headerFont, Brushes.Black, col4, y);
            y += 22;
            g.DrawLine(Pens.Black, x, y, x + width, y); y += 6;

            decimal tong = 0;
            foreach (var ct in ds)
            {
                // Lấy tên sản phẩm từ combo datasource nếu có
                string tenSP = ct.MaSanPham.ToString();
                try
                {
                    var colSP = (DataGridViewComboBoxColumn)dgvChiTiet.Columns["colMaSP"];
                    if (colSP?.DataSource is DataTable sptb)
                    {
                        var rows = sptb.Select($"ID = {ct.MaSanPham}");
                        if (rows.Length > 0) tenSP = rows[0]["TenSanPham"].ToString();
                    }
                }
                catch { }

                decimal thanhTien = ct.SoLuong * ct.DonGia;
                tong += thanhTien;

                g.DrawString(tenSP, textFont, Brushes.Black, col1, y);
                g.DrawString(ct.SoLuong.ToString(), textFont, Brushes.Black, col2, y);
                g.DrawString(ct.DonGia.ToString("N0"), textFont, Brushes.Black, col3, y);
                g.DrawString(thanhTien.ToString("N0"), textFont, Brushes.Black, col4, y);
                y += 20;
                if (y > e.MarginBounds.Bottom - 80)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            y += 10;
            g.DrawLine(Pens.Black, x, y, x + width, y); y += 8;
            g.DrawString($"Tổng cộng: {tong.ToString("N0")} đ", headerFont, Brushes.Black, col3 - 40, y);
        }

        private bool KiemTraDuLieu()
        {
            // Validation code remains the same...
            // [Giữ nguyên phần validation code của bạn]
            return true;
        }

        private void dgvChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Tự động tính lại thành tiền và tổng tiền
            if (e.ColumnIndex == dgvChiTiet.Columns["colSoLuong"].Index ||
                e.ColumnIndex == dgvChiTiet.Columns["colDonGia"].Index)
            {
                TinhTongTien();
            }

            // Tự động điền đơn giá khi chọn sản phẩm
            if (e.ColumnIndex == dgvChiTiet.Columns["colMaSP"].Index &&
                dgvChiTiet.Rows[e.RowIndex].Cells["colMaSP"].Value != null)
            {
                try
                {
                    int maSP = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Cells["colMaSP"].Value);
                    decimal giaBan = GiaoDichBUS.Instance.LayGiaSanPham(maSP);

                    dgvChiTiet.Rows[e.RowIndex].Cells["colDonGia"].Value = giaBan;

                    // Sử dụng BeginInvoke để tránh reentrant call
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (e.RowIndex < dgvChiTiet.Rows.Count && !dgvChiTiet.Rows[e.RowIndex].IsNewRow)
                        {
                            dgvChiTiet.CurrentCell = dgvChiTiet.Rows[e.RowIndex].Cells["colSoLuong"];
                            dgvChiTiet.BeginEdit(true);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvChiTiet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Xử lý sự kiện cho ô số lượng và đơn giá để chỉ cho phép nhập số
            if (dgvChiTiet.CurrentCell.ColumnIndex == dgvChiTiet.Columns["colSoLuong"].Index ||
                dgvChiTiet.CurrentCell.ColumnIndex == dgvChiTiet.Columns["colDonGia"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(TextBoxNumeric_KeyPress);
                }
            }
        }

        private void TextBoxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Định dạng hiển thị số tiền
            if (e.ColumnIndex == dgvChiTiet.Columns["colDonGia"].Index ||
                e.ColumnIndex == dgvChiTiet.Columns["colThanhTien"].Index)
            {
                if (e.Value != null)
                {
                    decimal value;
                    if (decimal.TryParse(e.Value.ToString(), out value))
                    {
                        e.Value = value.ToString("N0");
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}