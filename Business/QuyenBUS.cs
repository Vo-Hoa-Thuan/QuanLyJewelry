using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyJewelry.Business
{
    internal class QuyenBUS
    {
        private static QuyenBUS instance;

        internal static QuyenBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyenBUS();
                return instance;
            }
        }
        private QuyenBUS() { }

        public void getDataQuyen(ComboBox comboBoxQuyen)
        {
            // Sử dụng hàm getDataQuyen để lấy danh sách QUYEN từ CSDL
            List<QUYEN> quyens = QuyenDAO.Instance.getDataQuyen();

            // Thêm dữ liệu vào ComboBox
            comboBoxQuyen.DataSource = quyens; //chọn nguồn dữ liệu
            comboBoxQuyen.DisplayMember = "TenQuyen"; // Hiển thị tên quyền trong ComboBox

            comboBoxQuyen.SelectedIndex = 0; // Chọn mục đầu tiên là mục trống
        }
        public string getTenQuyen(int id)
        {
            return QuyenDAO.Instance.getTenQuyenById(id);
        }

        public int? getMaQuyen(string tenQuyen)
        {
            return QuyenDAO.Instance.getMaQuyen(tenQuyen);
        }


    }
}
