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
    public partial class frmHome : Form
    {
        string quyen;
        string sdt;

        int widthFrm = 1350;
        int heightFrm = 640;
        int widthTskbar = 323;
        public frmHome()
        {
            InitializeComponent();
            frmTrangChu a = new frmTrangChu();
            LoadForm(a);
            loadFormResized();
        }
        public frmHome(string quyen, string sdt)
        {
            this.quyen = quyen;
            this.sdt = sdt;
            InitializeComponent();
            frmTrangChu a = new frmTrangChu();
            LoadForm(a);
            loadFormResized();
        }

        // resized frm home
        void loadFormResized()
        {
            panel1.Size = new Size(widthFrm, 70);
            //btnClose.Location = new Point(1363, 12);
            PBody.Size = new Size(widthFrm - widthTskbar, 843);
            taskbar.Size = new Size(widthTskbar, heightFrm);
            this.ClientSize = new Size(widthFrm, heightFrm);
        }

        // theo dõi Form hiện tại đang được hiển thị
        private Form formNow;
        private void LoadForm(Form formnew)
        {
            //Nếu có form đang hiển thị, đóng form
            if (formNow != null)
            {
                formNow.Close();
            }

            // Xóa các control cũ trong panel
            PBody.Controls.Clear();

            //đổi form hiển thị
            formNow = formnew;

            formnew.TopLevel = false;
            formnew.FormBorderStyle = FormBorderStyle.None;
            formnew.Dock = DockStyle.Fill;

            PBody.Controls.Add(formnew);
            PBody.Tag = formnew;

            formnew.BringToFront();
            formnew.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {

                Application.Exit();
            }
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
            MessageBox.Show("SP Clicked");
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
            if (quyen == "Employee")
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe a = new frmThongKe();
            LoadForm(a);
        }
    }
}
