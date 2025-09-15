using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyJewelry.Business
{
    internal class GiaoDichBUS
    {
        private static GiaoDichBUS instance;

        internal static GiaoDichBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoDichBUS();
                return instance;
            }
        }

        private GiaoDichBUS() { }

        public DataTable LayDanhSachKhachHang()
        {
            return GiaoDichDAO.Instance.LayDanhSachKhachHang();
        }

        public DataTable LayDanhSachNhanVien()
        {
            return GiaoDichDAO.Instance.LayDanhSachNhanVien();
        }

        public DataTable LayDanhSachSanPham()
        {
            return GiaoDichDAO.Instance.LayDanhSachSanPham();
        }

        public decimal LayGiaSanPham(int maSanPham)
        {
            return GiaoDichDAO.Instance.LayGiaSanPham(maSanPham);
        }

        public bool TaoDonHang(GIAODICH gd, List<CHITIETGIAODICH> chiTietList)
        {
            return GiaoDichDAO.Instance.TaoDonHang(gd, chiTietList);
        }
    }
}