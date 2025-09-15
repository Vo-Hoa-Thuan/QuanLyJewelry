using OfficeOpenXml;
using QuanLyJewelry.Business;
using QuanLyJewelry.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using System.Globalization;

namespace QuanLyJewelry.View
{
    public partial class frmNhapSP : Form
    {
        public frmNhapSP()
        {
            InitializeComponent();
        }

        // Reset form
        private void reset()
        {
            txtMaSP.Text = "";
            txtGiaBan.Text = "";
            txtTenSP.Text = "";
            txtMoTa.Text = "";
            txtMaSP.Focus();
            pbHinhAnh.Image = null;
            pbHinhAnh.Tag = null;
            if (cbLoaiSP.Items.Count > 0) cbLoaiSP.SelectedIndex = 0;

            SanPhamBUS.Instance.Xem(dtgvDSSP);
        }

        // Export dữ liệu ra Excel
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Tiêu đề cột
                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Style.Font.Bold = true;
                        worksheet.Column(i).AutoFit();
                    }

                    // Dữ liệu
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView[j, i].Value != null)
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView[j, i].Value.ToString();
                        }
                    }

                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNhapSP_Load(object sender, EventArgs e)
        {
            LoaiHangBUS.Instance.getDataLoaiHang(cbLoaiSP);
            SanPhamBUS.Instance.Xem(dtgvDSSP);
        }

        private void dtgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                LoadRowToForm(dtgvDSSP.Rows[e.RowIndex]);
        }

        private void dtgvDSSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDSSP.SelectedRows.Count > 0)
                LoadRowToForm(dtgvDSSP.SelectedRows[0]);
        }

        // Load dữ liệu từ row lên form

        private void LoadRowToForm(DataGridViewRow row)
        {
            txtMaSP.Text = row.Cells[0].Value.ToString();
            txtTenSP.Text = row.Cells[1].Value.ToString();

            string tenLoai = row.Cells[2].Value.ToString();
            var dsLoai = (List<LOAIHANG>)cbLoaiSP.DataSource;
            var loai = dsLoai.FirstOrDefault(x => x.TenLoaiHang == tenLoai);
            if (loai != null)
                cbLoaiSP.SelectedValue = loai.ID;

            txtGiaBan.Text = row.Cells[3].Value.ToString();
            txtMoTa.Text = row.Cells[4].Value.ToString();

            string imageName = row.Cells["AnhFile"].Value?.ToString();
            string fullPath = Path.Combine(Application.StartupPath, "Hinhanh", imageName);

            if (!string.IsNullOrEmpty(imageName) && File.Exists(fullPath))
            {
                try
                {
                    if (pbHinhAnh.Image != null)
                    {
                        pbHinhAnh.Image.Dispose();
                        pbHinhAnh.Image = null;
                    }

                    // Chỉ load vào PictureBox, KHÔNG gán vào DataGridView cell
                    using (var temp = new Bitmap(fullPath))
                    {
                        pbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        pbHinhAnh.Image = new Bitmap(temp);
                        pbHinhAnh.Tag = fullPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load ảnh: " + ex.Message);
                }
            }
            else
            {
                pbHinhAnh.Image?.Dispose();
                pbHinhAnh.Image = null;
                pbHinhAnh.Tag = null;
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string giaBanText = txtGiaBan.Text.Trim();

            // chuẩn hóa: bỏ dấu ngăn cách hàng nghìn, đổi , thành .
            giaBanText = giaBanText.Replace(".", "").Replace(",", ".");

            decimal giaBan;
            if (!decimal.TryParse(giaBanText,
                                  NumberStyles.Any,
                                  CultureInfo.InvariantCulture,
                                  out giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Error");
                return;
            }


            SANPHAM sp = new SANPHAM
            {
                MaSanPham = txtMaSP.Text,
                TenSanPham = txtTenSP.Text,
                MaLoaiHang = Convert.ToInt32(cbLoaiSP.SelectedValue),  
                GiaBan = giaBan,
                MoTa = txtMoTa.Text,
                HinhAnh = pbHinhAnh.Tag?.ToString()
            };


            if (string.IsNullOrEmpty(sp.HinhAnh))
            {
                MessageBox.Show("Ảnh không được để trống!", "Error");
                return;
            }

            string check = SanPhamBUS.Instance.Them(sp);

            if (check != "success")
            {
                MessageBox.Show("Thêm không thành công: " + check, "Error");
                return;
            }

            MessageBox.Show("Thêm thành công!", "Thông báo");
            reset();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pbHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    pbHinhAnh.Image = Image.FromFile(selectedImagePath);
                    pbHinhAnh.Tag = selectedImagePath;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (SanPhamBUS.Instance.Xoa(dtgvDSSP))
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                SanPhamBUS.Instance.Xem(dtgvDSSP);
            }
            else MessageBox.Show("Xóa không thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)

        {
            string giaBanText = txtGiaBan.Text.Trim();

            // chuẩn hóa: bỏ dấu ngăn cách hàng nghìn, đổi , thành .
            giaBanText = giaBanText.Replace(".", "").Replace(",", ".");

            decimal giaBan;
            if (!decimal.TryParse(giaBanText,
                                  NumberStyles.Any,
                                  CultureInfo.InvariantCulture,
                                  out giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Error");
                return;
            }

            SANPHAM sp = new SANPHAM
            {
                MaSanPham = txtMaSP.Text,
                TenSanPham = txtTenSP.Text,
                //MaLoaiHang = Convert.ToInt32(cbLoaiSP.SelectedValue),
                GiaBan = giaBan,
                MoTa = txtMoTa.Text,
                HinhAnh = pbHinhAnh.Tag?.ToString()
            };
            // Gán MaLoaiHang an toàn
            if (cbLoaiSP.SelectedItem is LOAIHANG selectedLoai)
            {
                sp.MaLoaiHang = selectedLoai.ID;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại hàng!");
                return;
            }


            if (string.IsNullOrEmpty(sp.HinhAnh))
            {
                MessageBox.Show("Ảnh không được để trống!", "Error");
                return;
            }

            string check = SanPhamBUS.Instance.Sua(sp);

            if (check != "success")
            {
                MessageBox.Show("Sửa không thành công: " + check, "Error");
                return;
            }

            MessageBox.Show("Sửa thành công!", "Thông báo");
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.Tim(dtgvDSSP, txtTimKiem.Text);
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dtgvDSSP, saveFileDialog.FileName);
                }
            }
        }
    }
}
