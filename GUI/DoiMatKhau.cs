using QuanLyJewelry.DAO;
using QuanLyJewelry.Properties;
using System;
using System.Windows.Forms;

namespace QuanLyJewelry.GUI
{
    public partial class frmDoiMatKhau : Form
    {
        private string maNV; // Mã nhân viên cần đổi mật khẩu

        public frmDoiMatKhau(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text.Trim();
            string mkMoi = txtMatKhauMoi.Text.Trim();
            string mkNhapLai = txtNhapLai.Text.Trim();

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(mkNhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi");
                return;
            }

            if (mkMoi != mkNhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi");
                return;
            }

            // Lấy thông tin nhân viên từ DB
            var nv = NhanVienDAO.Instance.GetNhanVienByMa(maNV);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi");
                return;
            }

            string matKhauTrongDB = nv["MatKhau"].ToString();
            string soDT = nv["SoDienThoai"].ToString();

            bool hopLe = false;

            // Nếu mật khẩu hiện tại = số điện thoại (chưa hash)
            if (matKhauTrongDB == soDT)
            {
                if (mkCu == soDT)
                    hopLe = true;
            }
            else
            {
                // Nếu mật khẩu đã hash thì verify mật khẩu cũ
                if (SecurityHelper.VerifyPassword(mkCu, matKhauTrongDB, nv["Salt"].ToString()))
                    hopLe = true;
            }

            if (!hopLe)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi");
                return;
            }

            // Gửi mật khẩu mới (plain text) cho DAO,
            // DAO sẽ tự hash trước khi lưu vào DB
            bool kq = NhanVienDAO.Instance.DoiMatKhau(maNV, mkMoi);

            if (kq)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi");
            }
        }
    }
}
