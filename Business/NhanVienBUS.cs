using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyJewelry.Business
{
    internal class NhanVienBUS
    {
        private static NhanVienBUS instance;

        internal static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            }
        }
        private NhanVienBUS() { }
        public string getMaNhanVien(string maNV)
        {
            DataRow row = NhanVienDAO.Instance.GetNhanVienByMa(maNV);
            if (row != null)
            {
                return row["MaNhanVien"].ToString();
            }
            return null;
        }



        public void Xem(DataGridView dgv)
        {
            dgv.DataSource = NhanVienDAO.Instance.Xem();
            //Đổi tên cột datafridview
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[0].Visible = false; // ẩn cột ID đi
            dgv.Columns[1].HeaderText = "Mã nhân viên";
            dgv.Columns[2].HeaderText = "Tên nhân viên";
            dgv.Columns[3].HeaderText = "Quyền";
            dgv.Columns[4].HeaderText = "CCCD";
            dgv.Columns[5].HeaderText = "SĐT";
            dgv.Columns[6].HeaderText = "Địa chỉ";
            dgv.Columns[7].HeaderText = "Email";
            dgv.Columns[8].HeaderText = "Ngày vào";
        }

        public string Them(NHANVIEN p)
        {
            if (p.MaNhanVien == "")
            {
                return "errorManv";
            }
            if (p.HoTen == "")
            {
                return "errorHoten";
            }
            if (p.MaQuyen == null)
            {
                return "errorMaq";
            }
    
            if (p.SoDienThoai == "")
            {
                return "errorSđt";
            }
            if (p.DiaChi == "")
            {
                return "errorDiachi";
            }
            if (p.Email == "")
            {
                return "errorEmail";
            }
            if (p.CCCD == "")
            {
                return "errorCccd";
            }
            if (!Regex.IsMatch(p.Email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-z]{2,7})$", RegexOptions.IgnoreCase))
            {
                return "errorEmail1";
            }
            if (!Regex.IsMatch(p.CCCD, @"^\d+$"))
            {
                return "errorCccd1";
            }
            if (!Regex.IsMatch(p.SoDienThoai, @"^(03|07|08|09|01[2-9])[0-9]{8}$"))
            {
                return "errorSdt1";
            }
            //kiểm tra mã nv,cccd,sdt,email đã tồn tại chưa
            DataTable check = NhanVienDAO.Instance.Xem();
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["MaNhanVien"].ToString() == p.MaNhanVien)
                {
                    return "error1";
                }
                if (existingRow["CCCD"].ToString() == p.CCCD)
                {
                    return "error2";
                }
                if (existingRow["SoDienThoai"].ToString() == p.SoDienThoai)
                {
                    return "error3";
                }
                if (existingRow["Email"].ToString() == p.Email)
                {
                    return "error4";
                }
            }
            NhanVienDAO.Instance.Them(p);
            return "";
        }
        public bool Xoa(DataGridView dgv)
        {
            //lấy dữ liệu cột đầu đang được chọn
            int id = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value);
            //kiem tra xem masp có tồn tại trong chi tiet phieu nhap, phieu xuat kho, don mua không
            return NhanVienDAO.Instance.Xoa(id);
        }
        public string Sua(NHANVIEN p, string sdt, string email, string cccd)
        {
            if (p.MaNhanVien == "")
            {
                return "errorManv";
            }
            if (p.HoTen == "")
            {
                return "errorHoten";
            }
            if (p.MaQuyen == null)
            {
                return "errorMaq";
            }
            if (p.SoDienThoai == "")
            {
                return "errorSđt";
            }
            if (p.DiaChi == "")
            {
                return "errorDiachi";
            }
            if (p.Email == "")
            {
                return "errorEmail";
            }
            if (p.CCCD == "")
            {
                return "errorCccd";
            }
            if (!Regex.IsMatch(p.Email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-z]{2,7})$", RegexOptions.IgnoreCase))
            {
                return "errorEmail1";
            }
            if (!Regex.IsMatch(p.CCCD, @"^\d+$"))
            {
                return "errorCccd1";
            }
            if (!Regex.IsMatch(p.SoDienThoai, @"^(03|07|08|09|01[2-9])[0-9]{8}$"))
            {
                return "errorSdt1";
            }
            //kiểm tra mã nv,cccd,sdt,email đã tồn tại chưa
            DataTable check = NhanVienDAO.Instance.Xem();
            foreach (DataRow existingRow in check.Rows)
            {
                if (existingRow["CCCD"].ToString() == p.CCCD && existingRow["CCCD"].ToString() != cccd)
                {
                    return "error2";
                }
                if (existingRow["SoDienThoai"].ToString() == p.SoDienThoai && existingRow["SoDienThoai"].ToString() != sdt)
                {
                    return "error3";
                }
                if (existingRow["Email"].ToString() == p.Email && existingRow["Email"].ToString() != email)
                {
                    return "error4";
                }
            }
            NhanVienDAO.Instance.Sua(p);
            return "";
        }
    
    }
}
