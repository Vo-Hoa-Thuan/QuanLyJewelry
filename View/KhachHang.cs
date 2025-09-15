using QuanLyJewelry.Business;
using QuanLyJewelry.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class frmKhachHang : Form
    {
        private bool isEditMode = false;
        private int currentKhachHangId = 0;

        public frmKhachHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            ResetForm();
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                DataTable dt = KhachHangBUS.Instance.LayTatCaKhachHang();
                dgvKhachHang.DataSource = dt;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvKhachHang.Columns.Count == 0) return;

            dgvKhachHang.Columns["ID"].Visible = false;
            dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã KH";
            dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["NgayVao"].HeaderText = "Ngày vào";
            dgvKhachHang.Columns["NgayVao"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void ResetForm()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            dtpNgayVao.Value = DateTime.Now;

            isEditMode = false;
            currentKhachHangId = 0;
            btnThem.Text = "Thêm";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvSanPhamDaMua.DataSource = null;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên"); txtHoTen.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại"); txtSoDienThoai.Focus(); return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSoDienThoai.Text, @"^[0-9]{10,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ"); txtSoDienThoai.Focus(); return false;
            }
            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ"); txtEmail.Focus(); return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
            catch { return false; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            KHACHHANG kh = new KHACHHANG
            {
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                DiaChi = string.IsNullOrEmpty(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim(),
                NgayVao = dtpNgayVao.Value
            };

            try
            {
                bool result;
                if (isEditMode)
                {
                    kh.ID = currentKhachHangId;
                    result = KhachHangBUS.Instance.CapNhatKhachHang(kh);
                    if (result) { MessageBox.Show("Cập nhật thành công"); LoadDanhSachKhachHang(); ResetForm(); }
                }
                else
                {
                    result = KhachHangBUS.Instance.ThemKhachHang(kh);
                    if (result) { MessageBox.Show("Thêm thành công"); LoadDanhSachKhachHang(); ResetForm(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) { MessageBox.Show("Chọn khách hàng để sửa"); return; }
            int id = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["ID"].Value);
            KHACHHANG kh = KhachHangBUS.Instance.LayKhachHangTheoID(id);
            if (kh != null)
            {
                currentKhachHangId = kh.ID;
                txtMaKH.Text = kh.MaKhachHang;
                txtHoTen.Text = kh.HoTen;
                txtSoDienThoai.Text = kh.SoDienThoai;
                txtEmail.Text = kh.Email ?? "";
                txtDiaChi.Text = kh.DiaChi ?? "";
                dtpNgayVao.Value = kh.NgayVao;

                isEditMode = true;
                btnThem.Text = "Cập nhật";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                HienThiSanPhamDaMua(kh.ID); // Dùng ID
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) { MessageBox.Show("Chọn khách hàng để xóa"); return; }
            int id = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["ID"].Value);
            string tenKH = dgvKhachHang.CurrentRow.Cells["HoTen"].Value.ToString();

            if (MessageBox.Show($"Xóa khách hàng '{tenKH}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = KhachHangBUS.Instance.XoaKhachHang(id);
                if (result) { MessageBox.Show("Xóa thành công"); LoadDanhSachKhachHang(); ResetForm(); }
            }
        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
            currentKhachHangId = Convert.ToInt32(row.Cells["ID"].Value);

            txtMaKH.Text = row.Cells["MaKhachHang"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            dtpNgayVao.Value = Convert.ToDateTime(row.Cells["NgayVao"].Value);

            isEditMode = true;
            btnThem.Text = "Cập nhật";
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            HienThiSanPhamDaMua(currentKhachHangId); // Dùng ID
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dgvKhachHang.CurrentRow != null;
            btnXoa.Enabled = dgvKhachHang.CurrentRow != null;

            if (dgvKhachHang.CurrentRow != null)
            {
                int khId = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["ID"].Value);
                HienThiSanPhamDaMua(khId);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                int khId = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["ID"].Value);
                HienThiSanPhamDaMua(khId);
            }
            else
            {
                MessageBox.Show("Chọn khách hàng để xem chi tiết");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            DataTable dt = string.IsNullOrEmpty(keyword)
                ? KhachHangBUS.Instance.LayTatCaKhachHang()
                : KhachHangBUS.Instance.TimKiemKhachHang(keyword);
            dgvKhachHang.DataSource = dt;
            FormatDataGridView();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSachKhachHang();
            ResetForm();
        }

        private void HienThiSanPhamDaMua(int khachHangId)
        {
            try
            {
                DataTable dtSanPham = KhachHangBUS.Instance.LaySanPhamDaMua(khachHangId);
                dgvSanPhamDaMua.DataSource = dtSanPham;

                if (dtSanPham != null && dtSanPham.Rows.Count > 0)
                {
                    if (dgvSanPhamDaMua.Columns.Contains("DonGia"))
                    {
                        dgvSanPhamDaMua.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                        dgvSanPhamDaMua.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvSanPhamDaMua.Columns.Contains("ThanhTien"))
                    {
                        dgvSanPhamDaMua.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        dgvSanPhamDaMua.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvSanPhamDaMua.Columns.Contains("NgayMua"))
                    {
                        dgvSanPhamDaMua.Columns["NgayMua"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
            catch
            {
                dgvSanPhamDaMua.DataSource = null;
            }
        }
    }
}
