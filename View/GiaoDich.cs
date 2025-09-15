using QuanLyJewelry.Business;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class frmGiaoDich : Form
    {
        public frmGiaoDich()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            this.BeginInvoke(new MethodInvoker(delegate {
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
                    this.BeginInvoke(new MethodInvoker(delegate {
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