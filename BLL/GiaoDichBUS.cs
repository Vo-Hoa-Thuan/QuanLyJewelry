using QuanLyJewelry.DAO;
using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyJewelry.BLL
{
    internal class GiaoDichBLL
    {
        private static GiaoDichBLL instance;

        internal static GiaoDichBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoDichBLL();
                return instance;
            }
        }

        private GiaoDichBLL() { }

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