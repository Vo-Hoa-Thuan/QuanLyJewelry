using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyJewelry
    .Business
{
    internal class ChiTietGiaoDichBUS
    {
        private static ChiTietGiaoDichBUS instance;

        internal static ChiTietGiaoDichBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietGiaoDichBUS();
                return instance;
            }
        }

        private ChiTietGiaoDichBUS() { }

        /// <summary>
        /// Load chi tiết giao dịch lên DataGridView theo mã GD
        /// </summary>
        public void LoadChiTietByMaGD(DataGridView dgv, long maGD)
        {
            DataTable dt = ChiTietGiaoDichDAO.Instance.GetByMaGD(maGD);
            dgv.DataSource = dt;
        }

        /// <summary>
        /// Lấy chi tiết giao dịch theo mã GD (trả về DataTable)
        /// </summary>
        public DataTable GetChiTietByMaGD(long maGD)
        {
            return ChiTietGiaoDichDAO.Instance.GetByMaGD(maGD);
        }

        /// <summary>
        /// Lấy toàn bộ chi tiết giao dịch
        /// </summary>
        public DataTable GetAll()
        {
            return ChiTietGiaoDichDAO.Instance.Xem();
        }

        /// <summary>
        /// Thêm mới chi tiết giao dịch
        /// </summary>
        public bool ThemChiTiet(CHITIETGIAODICH ct)
        {
            return ChiTietGiaoDichDAO.Instance.Them(ct);
        }
    }
}
