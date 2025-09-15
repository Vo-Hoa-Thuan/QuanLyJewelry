using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyJewelry.Business
{
    internal class LoaiHangBUS
    {
        private static LoaiHangBUS instance;

        internal static LoaiHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiHangBUS();
                return instance;
            }
        }
        private LoaiHangBUS() { }

        public void getDataLoaiHang(ComboBox comboBoxLoai)
        {
            List<LOAIHANG> loaih = LoaiHangDAO.Instance.getDataLoaiHang();

            comboBoxLoai.DataSource = loaih;
            comboBoxLoai.DisplayMember = "TenLoaiHang"; // hiển thị tên
            comboBoxLoai.ValueMember = "ID";            // giá trị thật là ID

            if (loaih.Count > 0)
                comboBoxLoai.SelectedIndex = 0;         // chọn dòng đầu tiên
        }

        public int getIdLoaiHang(string ten)
        {
            DataTable check = LoaiHangDAO.Instance.getMaLoaiHang(ten);
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["TenLoaiHang"].ToString() == ten)
                {
                    return Convert.ToInt32(existingRow["ID"]); // trả về ID thật sự
                }
            }
            return -1; // hoặc throw new Exception("Không tìm thấy loại hàng");
        }

        public string getMaLoaiHang(string ten)
        {
            string ma = null;
            DataTable check = LoaiHangDAO.Instance.getMaLoaiHang(ten);
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["TenLoaiHang"].ToString() == ten)
                {
                    return existingRow["MaLoaiHang"].ToString();
                }
            }
            return ma;
        }
    }
}
