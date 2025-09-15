using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyJewelry.Business
{
    internal class NhaCungCapBUS
    {
        private static NhaCungCapBUS instance;

        internal static NhaCungCapBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapBUS();
                return instance;
            }
        }
        private NhaCungCapBUS() { }

        public void Xem(DataGridView dgv)
        {
            dgv.DataSource = NhaCungCapDAO.Instance.Xem();
            //Đổi tên cột datafridview
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgv.Columns[2].HeaderText = "Tên nhà cung cấp";
            dgv.Columns[3].HeaderText = "Số điện thoại";
            dgv.Columns[4].HeaderText = "Địa chỉ";
            dgv.Columns[5].HeaderText = "Email";
            dgv.Columns[6].HeaderText = "Người đại diện";
            dgv.Columns[7].HeaderText = "Ngày tạo";
        }
        public string Them(NHACUNGCAP p)
        {
            if (p.TenNhaCungCap == "")
            {
                return "errorTen";
            }
            if (p.MaNhaCungCap == "")
            {
                return "errorMa";
            }
            if (p.SoDienThoai == "")
            {
                return "errorSdt";
            }
            //@"^(03|07|08|09|01[2-9])[0-9]{8}$" Kiểm tra 1 chuỗi có phải là số điện thoại @"^\d+$"
            if (!Regex.IsMatch(p.SoDienThoai, @"^(03|07|08|09|01[2-9])[0-9]{8}$"))
            {
                return "errorSdt2";
            }
            if (p.DiaChi == "")
            {
                return "errorDiachi";
            }
            //kiểm tra mã ncc và sđt đã tồn tại chưa
            DataTable check = NhaCungCapDAO.Instance.Xem();
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["MaNhaCungCap"].ToString() == p.MaNhaCungCap)
                {
                    return "error1";
                }
                if (existingRow["SoDienThoai"].ToString() == p.SoDienThoai)
                {
                    return "error2";
                }
            }
            NhaCungCapDAO.Instance.Them(p);
            return "";
        }
        public bool Xoa(DataGridView dgv)
        {
            //lấy dữ liệu cộ đầu đang được chọn
            int id = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
            bool kt = false;
            string codepnk = "";
            //kiem tra xem mancc có tồn tại trong phiếu nhập kho không
            //DataTable check = PhieuNhapKhoDAO.Instance.Xem();
            //foreach (DataRow existingRow in check.Rows)
            //{
            //    if (existingRow["MaNhaCungCap"].ToString() == code)
            //    {
            //        MessageBox.Show("Không thể xóa nhà cung cấp này?", "Thông báo!");
            //        return false;
            //        break;
            //    }
            //}
            return NhaCungCapDAO.Instance.Xoa(id);
        }
            public string Sua(NHACUNGCAP p, string sdt)
            {
                if (p.TenNhaCungCap == "")
                {
                    return "errorTen";
                }
                if (p.MaNhaCungCap == "")
                {
                    return "errorMa";
                }
                if (p.SoDienThoai == "")
                {
                    return "errorSdt";
                }
                if (p.DiaChi == "")
                {
                    return "errorDiachi";
                }
                // kiểm tra sđt đã tồn tại chưa
                DataTable check = NhaCungCapDAO.Instance.Xem();
                //foreach (DataRow existingRow in check.Rows)
                //{
                //    if (existingRow["SoDienThoai"].ToString() == p.SoDienThoai && existingRow["SoDienThoai"].ToString() != sdt)
                //    {
                //        return "error2";
                //    }
                //}
                NhaCungCapDAO.Instance.Sua(p);
                return "";
            }
        public void Tim(DataGridView dgv, string tenncc)
        {
            dgv.DataSource = NhaCungCapDAO.Instance.Tim(tenncc);
            //Đổi tên cột datafridview
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgv.Columns[2].HeaderText = "Tên nhà cung cấp";
            dgv.Columns[3].HeaderText = "Số điện thoại";
            dgv.Columns[4].HeaderText = "Địa chỉ";
            dgv.Columns[5].HeaderText = "Email";
            dgv.Columns[6].HeaderText = "Người đại diện";
            dgv.Columns[7].HeaderText = "Ngày tạo";
        }
        public void getDataNhaCungCap(ComboBox comboBoxQuyen)
        {
            // Sử dụng hàm getDataQuyen để lấy danh sách QUYEN từ CSDL
            List<NHACUNGCAP> loaih = NhaCungCapDAO.Instance.getDataNhaCungCap();

            // Thêm dữ liệu vào ComboBox
            comboBoxQuyen.DataSource = loaih; //chọn nguồn dữ liệu
            comboBoxQuyen.DisplayMember = "TenNhaCungCap"; // Hiển thị tên quyền trong ComboBox

            comboBoxQuyen.SelectedIndex = 0; // Chọn mục đầu tiên
        }
        public string getMaNhaCungCap(string ten)
        {
            string ma = null;
            DataTable check = NhaCungCapDAO.Instance.getMaNhaCungCap(ten);
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["TenNhaCungCap"].ToString() == ten)
                {
                    return existingRow["MaNhaCungCap"].ToString();
                }
            }
            return ma;
        }
    }
}
