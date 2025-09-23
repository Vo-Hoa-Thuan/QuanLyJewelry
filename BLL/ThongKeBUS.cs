using QuanLyJewelry.DAO;
using System.Data;

namespace QuanLyJewelry.BLL
{
    internal class ThongKeBLL
    {
        private static ThongKeBLL instance;

        public static ThongKeBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongKeBLL();
                return instance;
            }
        }

        private ThongKeBLL() { }

        public DataTable LayDoanhThuTheoThang(int nam, int thang)
        {
            return ThongKeDAO.Instance.LayDoanhThuTheoThang(nam, thang);
        }

        public DataTable LayTopSanPham(int top, int nam, int thang)
        {
            return ThongKeDAO.Instance.LayTopSanPham(top, nam, thang);
        }

        public DataTable LayDoanhThuNhanVien(int nam, int thang)
        {
            return ThongKeDAO.Instance.LayDoanhThuNhanVien(nam, thang);
        }

        public DataTable LayTopKhachHang(int top, int nam, int thang)
        {
            return ThongKeDAO.Instance.LayTopKhachHang(top, nam, thang);
        }

        public DataTable LayDoanhThuTheoLoaiSP(int nam, int thang)
        {
            return ThongKeDAO.Instance.LayDoanhThuTheoLoaiSP(nam, thang);
        }

        public DataTable LayTongQuan(int nam, int thang)
        {
            return ThongKeDAO.Instance.LayTongQuan(nam, thang);
        }

        public DataTable LayDoanhThuTheoNam(int nam)
        {
            return ThongKeDAO.Instance.LayDoanhThuTheoNam(nam);
        }

        public DataTable LaySanPhamDaMuaKhachHang(int maKhachHang, int nam, int thang)
        {
            return ThongKeDAO.Instance.LaySanPhamDaMuaKhachHang(maKhachHang, nam, thang);
        }

        public DataTable LaySanPhamDaMuaKhachHangAll(int maKhachHang)
        {
            return ThongKeDAO.Instance.LaySanPhamDaMuaKhachHangAll(maKhachHang);
        }
    }
}