using OfficeOpenXml;
using QuanLyJewelry.Business;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void reset()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            txtMaNV.Focus();
            cbQuyen.SelectedIndex = 0;
            NhanVienBUS.Instance.Xem(dtgvNhanVien);

        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                //tạo một workbook Excel mới
                using (var package = new ExcelPackage())
                {
                    //tạo trang tinh sheet1 và gán chp workbook
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    // Ghi dữ liệu từ DataGridView vào Excel worksheet
                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        // Ghi tiêu đề cột
                        worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Style.Font.Bold = true;
                        // Đặt độ rộng cột bằng chiều dài của tiêu đề cột
                        worksheet.Column(i).AutoFit();
                    }
                    //Ghi dữ liệu vào woekbook từ datagridview
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView[j, i].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView[j, i].Value.ToString();
                            }
                        }
                    }

                    // Lưu workbook ra tệp Excel
                    //package.SaveAs(new FileInfo(filePath));

                    MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            QuyenBUS.Instance.getDataQuyen(cbQuyen);
            NhanVienBUS.Instance.Xem(dtgvNhanVien);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã bấm vào một ô hợp lệ hay không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dtgvNhanVien.Rows[e.RowIndex];
                // Lấy giá trị từ cột của hàng được chọn và hiển thị nó trong các TextBox
                txtMaNV.Text = selectedRow.Cells[1].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[2].Value.ToString();
                cbQuyen.Text = selectedRow.Cells[3].Value.ToString();
                txtCCCD.Text = selectedRow.Cells[4].Value.ToString();
                txtSDT.Text = selectedRow.Cells[5].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[6].Value.ToString();
                txtEmail.Text = selectedRow.Cells[7].Value.ToString();


            }
        }

        private void dtgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dtgvNhanVien.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dtgvNhanVien.SelectedRows[0];
                // Lấy giá trị từ cột của hàng được chọn và hiển thị nó trong các TextBox
                txtMaNV.Text = selectedRow.Cells[1].Value.ToString();
                txtHoTen.Text = selectedRow.Cells[2].Value.ToString();
                cbQuyen.Text = selectedRow.Cells[3].Value.ToString();
                txtCCCD.Text = selectedRow.Cells[4].Value.ToString();
                txtSDT.Text = selectedRow.Cells[5].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[6].Value.ToString();
                txtEmail.Text = selectedRow.Cells[7].Value.ToString();


            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Đặt tiêu đề cho hộp thoại openFileDialog
                openFileDialog.Title = "Chọn ảnh";
                //Đặt bộ lọc cho các tệp ảnh
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đến tệp đã chọn
                    string selectedImagePath = openFileDialog.FileName;
                    //Chỉnh ảnh phù hợp với pbHinhAnh
                    pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    //Hiển thị ảnh
                    pbAvatar.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MaNhanVien = txtMaNV.Text;
            nv.HoTen = txtHoTen.Text;
            nv.CCCD = txtCCCD.Text;
            nv.Email = txtEmail.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.MaQuyen = QuyenBUS.Instance.getMaQuyen(cbQuyen.Text) ?? 0;
            nv.SoDienThoai = txtSDT.Text;

            string check = NhanVienBUS.Instance.Them(nv);
            switch (check)
            {
                case "errorManv":
                    MessageBox.Show("Mã nhân viên không được để trống!", "Error");
                    return;
                case "errorHoten":
                    MessageBox.Show("Họ tên không được để trống!", "Error");
                    return;
                case "errorMaq":
                    MessageBox.Show("Quyền không được để trống!", "Error");
                    return;
                case "errorAnh":
                    MessageBox.Show("Ảnh không được để trống!", "Error");
                    return;
                case "errorSđt":
                    MessageBox.Show("Số điện thoại không được để trống!", "Error");
                    return;
                case "errorDiachi":
                    MessageBox.Show("Địa chỉ không được để trống!", "Error");
                    return;
                case "errorEmail":
                    MessageBox.Show("Email không được để trống!", "Error");
                    return;
                case "errorCccd":
                    MessageBox.Show("CCCD không được để trống!", "Error");
                    return;
                case "error1":
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Error");
                    return;
                case "error2":
                    MessageBox.Show("CCCD đã tồn tại!", "Error");
                    return;
                case "error3":
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Error");
                    return;
                case "error4":
                    MessageBox.Show("Email đã tồn tại!", "Error");
                    return;
                case "errorEmail1":
                    MessageBox.Show("Email không hợp lệ!", "Error");
                    return;
                case "errorCccd1":
                    MessageBox.Show("CCCD không hợp lệ!", "Error");
                    return;
                case "errorSdt1":
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Error");
                    return;
            }
            MessageBox.Show("Thêm thành công!", "Thông báo");
            reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (NhanVienBUS.Instance.Xoa(dtgvNhanVien))
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                NhanVienBUS.Instance.Xem(dtgvNhanVien);
            }
            else MessageBox.Show("Xóa không thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MaNhanVien = txtMaNV.Text;
            nv.HoTen = txtHoTen.Text;
            nv.CCCD = txtCCCD.Text;
            nv.Email = txtEmail.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.MaQuyen = QuyenBUS.Instance.getMaQuyen(cbQuyen.Text) ?? 0;
            nv.SoDienThoai = txtSDT.Text;

            int rowIndex = dtgvNhanVien.CurrentCell.RowIndex;
            nv.ID = Convert.ToInt32(dtgvNhanVien.Rows[rowIndex].Cells[0].Value);
            // Lấy giá trị từ ô hiện tại
            string macuahang = dtgvNhanVien.Rows[rowIndex].Cells[1].Value.ToString();

            if (macuahang != txtMaNV.Text)
            {
                MessageBox.Show("Mã nhân viên không được thay đổi!", "Error");
                return;
            }
            string check = NhanVienBUS.Instance.Sua(nv, nv.SoDienThoai, nv.Email, nv.CCCD);
            switch (check)
            {
                case "errorManv":
                    MessageBox.Show("Mã nhân viên không được để trống!", "Error");
                    return;
                case "errorHoten":
                    MessageBox.Show("Họ tên không được để trống!", "Error");
                    return;
                case "errorMaq":
                    MessageBox.Show("Quyền không được để trống!", "Error");
                    return;
                case "errorAnh":
                    MessageBox.Show("Ảnh không được để trống!", "Error");
                    return;
                case "errorSđt":
                    MessageBox.Show("Số điện thoại không được để trống!", "Error");
                    return;
                case "errorDiachi":
                    MessageBox.Show("Địa chỉ không được để trống!", "Error");
                    return;
                case "errorEmail":
                    MessageBox.Show("Email không được để trống!", "Error");
                    return;
                case "errorCccd":
                    MessageBox.Show("CCCD không được để trống!", "Error");
                    return;
                case "error2":
                    MessageBox.Show("CCCD đã tồn tại!", "Error");
                    return;
                case "error3":
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Error");
                    return;
                case "error4":
                    MessageBox.Show("Email đã tồn tại!", "Error");
                    return;
                case "errorEmail1":
                    MessageBox.Show("Email không hợp lệ!", "Error");
                    return;
                case "errorCccd1":
                    MessageBox.Show("CCCD không hợp lệ!", "Error");
                    return;
                case "errorSdt1":
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Error");
                    return;
            }
            MessageBox.Show("Sửa thành công!", "Thông báo");
            reset();
        }

        private void btnXuatExel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                //hiển thị hộp thoại lưu cho người dùng
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Chọn vị trí lưu tệp Excel
                    string filePath = saveFileDialog.FileName;

                    // Viết dữ liệu vào tệp Excel
                    ExportToExcel(dtgvNhanVien, filePath);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
