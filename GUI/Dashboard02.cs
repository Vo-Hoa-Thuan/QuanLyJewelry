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

namespace QuanLyJewelry.GUI
{
    public partial class frmHome2 : Form
    {
        string quyen;
        string sdt;
        public frmHome2()
        {
            InitializeComponent();
            frmTrangChu a = new frmTrangChu();
            LoadForm(a);
        }
        public frmHome2(string quyen, string sdt)
        {
            this.quyen = quyen;
            this.sdt = sdt;
            InitializeComponent();
            frmTrangChu a = new frmTrangChu();
            LoadForm(a);
        }
        // theo dõi Form hiện tại đang được hiển thị
        private Form formNow;
        private void LoadForm(Form formnew)
        {
            if (formNow != null)
            {
                formNow.Close();
            }

            formNow = formnew;
            formnew.TopLevel = false;
            formnew.FormBorderStyle = FormBorderStyle.None;
            formnew.Dock = DockStyle.Fill;

            PBody.Controls.Clear();   // ⚡ Quan trọng: Xóa form cũ trước khi add
            PBody.Controls.Add(formnew);
            PBody.Tag = formnew;

            formnew.BringToFront();
            formnew.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe a = new frmThongKe();
            LoadForm(a);
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            
            frmNhapSP a = new frmNhapSP();
            LoadForm(a);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang a = new frmKhachHang();
            LoadForm(a);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien a = new frmNhanVien();
            LoadForm(a);
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            frmGiaoDich a = new frmGiaoDich();
            LoadForm(a);
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap a = new frmNhaCungCap();
            LoadForm(a);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            frmTrangChu a = new frmTrangChu();
            LoadForm(a);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblChucVu.Text = quyen;
            label3.Text = sdt;
            if (quyen == "Nhân Viên")
            {
                btnThongKe.Visible = false;
                btnNhanVien.Visible = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin();
            this.Hide();
            signin.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
