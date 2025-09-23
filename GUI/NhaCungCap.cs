using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using QuanLyJewelry.BLL;
using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyJewelry.View
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txtDiaChiNCC.Text = "";
            txtMaNCC.Text = "";
            txtSDTNCC.Text = "";
            txtTenNCC.Text = "";
            txtTimKiem.Text = "";
            txtEmail.Text = "";
            txtNguoiDaiDien.Text = "";
            txtMaNCC.Focus();
            NhaCungCapBLL.Instance.Xem(dtgrDSNCC);
        }
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                //tạo một workbook Excel mới
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
                    package.SaveAs(new System.IO.FileInfo(filePath));

                    MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.MaNhaCungCap = txtMaNCC.Text;
            ncc.TenNhaCungCap = txtTenNCC.Text;
            ncc.SoDienThoai = txtSDTNCC.Text;
            ncc.DiaChi = txtDiaChiNCC.Text;
            ncc.Email = txtEmail.Text;
            ncc.NguoiDaiDien = txtNguoiDaiDien.Text;
            string check = NhaCungCapBLL.Instance.Them(ncc);
            switch (check)
            {
                case "errorTen":
                    MessageBox.Show("Tên nhà cung cấp không được để trống!", "Error");
                    return;
                case "errorMa":
                    MessageBox.Show("Mã nhà cung cấp không được để trống!", "Error");
                    return;
                case "errorSdt":
                    MessageBox.Show("Số điện thoại không được để trống!", "Error");
                    return;
                case "errorSdt2":
                    MessageBox.Show("Số điện thoại không đúng!", "Error");
                    return;
                case "errorDiachi":
                    MessageBox.Show("Địa chỉ không được để trống!", "Error");
                    return;
                case "error1":
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại!", "Error");
                    return;
                case "error2":
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Error");
                    return;
            }
            MessageBox.Show("Thêm thành công!", "Thông báo");
            reset();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            NhaCungCapBLL.Instance.Xem(dtgrDSNCC);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgrDSNCC.SelectedCells.Count > 0)
            {
                if (NhaCungCapBLL.Instance.Xoa(dtgrDSNCC))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    NhaCungCapBLL.Instance.Xem(dtgrDSNCC);
                }
                else MessageBox.Show("Xóa không thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn xóa!", "Error!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgrDSNCC.SelectedCells.Count > 0)
            {
                NHACUNGCAP ncc = new NHACUNGCAP();
                ncc.MaNhaCungCap = txtMaNCC.Text;
                ncc.TenNhaCungCap = txtTenNCC.Text;
                ncc.SoDienThoai = txtSDTNCC.Text;
                ncc.DiaChi = txtDiaChiNCC.Text;
                ncc.Email = txtEmail.Text;
                ncc.NguoiDaiDien = txtNguoiDaiDien.Text;

                // Lấy hàng hiện tại (current row)
                int rowIndex = dtgrDSNCC.CurrentCell.RowIndex;
                // Lấy giá trị từ ô hiện tại
                string id = dtgrDSNCC.Rows[rowIndex].Cells[0].Value.ToString(); // ID
                string macuahang = dtgrDSNCC.Rows[rowIndex].Cells[1].Value.ToString(); // MaNCC
                string sdtcuahang = dtgrDSNCC.Rows[rowIndex].Cells[3].Value.ToString(); // SoDienThoai
                ncc.ID = int.Parse(id); // Quan trọng để cập nhật đúng


                if (macuahang != txtMaNCC.Text)
                {
                    MessageBox.Show("Mã nhà cung cấp không được thay đổi!", "Error");
                    return;
                }
                string check = NhaCungCapBLL.Instance.Sua(ncc, sdtcuahang);
                switch (check)
                {
                    case "error2":
                        MessageBox.Show("Số điện thoại đã tồn tại!", "Error");
                        return;
                    case "errorTen":
                        MessageBox.Show("Tên nhà cung cấp không được để trống!", "Error");
                        return;
                    case "errorMa":
                        MessageBox.Show("Mã nhà cung cấp không được để trống!", "Error");
                        return;
                    case "errorSdt":
                        MessageBox.Show("Số điện thoại không được để trống!", "Error");
                        return;
                    case "errorSdt2":
                        MessageBox.Show("Số điện thoại không đúng!", "Error");
                        return;
                    case "errorDiachi":
                        MessageBox.Show("Địa chỉ không được để trống!", "Error");
                        return;
                    case "error1":
                        MessageBox.Show("Mã nhà cung cấp đã tồn tại!", "Error");
                        return;
                }
                MessageBox.Show("Sửa thành công!", "Thông báo");
                reset();
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng bạn muốn sửa!", "Error!");
            }
        }

        private void dtgrDSNCC_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dtgrDSNCC.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dtgrDSNCC.SelectedRows[0];
                // Lấy giá trị từ cột của hàng được chọn và hiển thị nó trong các TextBox
                txtMaNCC.Text = selectedRow.Cells[1].Value.ToString(); // MaNhaCungCap
                txtTenNCC.Text = selectedRow.Cells[2].Value.ToString(); // TenNhaCungCap
                txtSDTNCC.Text = selectedRow.Cells[3].Value.ToString(); // SoDienThoai
                txtDiaChiNCC.Text = selectedRow.Cells[4].Value.ToString(); // DiaChi
                txtEmail.Text = selectedRow.Cells[5].Value.ToString(); // Email
                txtNguoiDaiDien.Text = selectedRow.Cells[6].Value.ToString(); // NguoiDaiDien

            }
        }

        private void dtgrDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã bấm vào một ô hợp lệ hay không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dtgrDSNCC.Rows[e.RowIndex];
                // Lấy giá trị từ cột của hàng được chọn và hiển thị nó trong các TextBox
                txtMaNCC.Text = selectedRow.Cells[1].Value.ToString();
                txtTenNCC.Text = selectedRow.Cells[2].Value.ToString();
                txtSDTNCC.Text = selectedRow.Cells[3].Value.ToString();
                txtDiaChiNCC.Text = selectedRow.Cells[4].Value.ToString();
                txtEmail.Text = selectedRow.Cells[5].Value.ToString();
                txtNguoiDaiDien.Text = selectedRow.Cells[6].Value.ToString();

            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NhaCungCapBLL.Instance.Tim(dtgrDSNCC, txtTimKiem.Text);
        }

        private void btnXuatE_Click(object sender, EventArgs e)
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
                    ExportToExcel(dtgrDSNCC, filePath);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
