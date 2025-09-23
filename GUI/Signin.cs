using QuanLyJewelry.DAO;
using QuanLyJewelry.DTO;
using QuanLyJewelry.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            // Lấy danh sách quyền từ DB
            List<QUYEN> dsQuyen = QuyenDAO.Instance.getDataQuyen();

            // Gán vào ComboBox
            cbRole.DataSource = dsQuyen;
            cbRole.DisplayMember = "TenQuyen";  // Hiển thị tên quyền (Admin, Nhân viên…)
            cbRole.ValueMember = "ID";          // Giá trị thực sự (ID trong DB)
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string maNV = txtUsername.Text.Trim();
            string matKhauNhap = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Error");
                return;
            }
            if (string.IsNullOrEmpty(matKhauNhap))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Error");
                return;
            }

            // gọi DAO để check login
            DataRow nv = NhanVienDAO.Instance.DangNhap(maNV, matKhauNhap);

            if (nv == null)
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác!", "Error");
                return;
            }

            // nếu lần đầu login thì mật khẩu = số điện thoại
            if (nv["MatKhau"].ToString() == nv["SoDienThoai"].ToString())
            {
                MessageBox.Show("Lần đầu đăng nhập, vui lòng đổi mật khẩu!", "Thông báo");
                frmDoiMatKhau doiMK = new frmDoiMatKhau(maNV);
                this.Hide();
                doiMK.ShowDialog();
                this.Show();
                return;
            }

            // đăng nhập thành công
            int idQuyen = (int)cbRole.SelectedValue;
            string tenQuyen = cbRole.Text;

            MessageBox.Show($"{tenQuyen} đăng nhập thành công!", "Success");

            frmHome2 dashboard = new frmHome2(nv["HoTen"].ToString(), tenQuyen);
            this.Hide();
            dashboard.ShowDialog();
            this.Show();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
