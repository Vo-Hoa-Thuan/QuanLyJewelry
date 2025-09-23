using QuanLyJewelry.DAO;
using QuanLyJewelry.DTO;
using System;
using System.Data;

namespace QuanLyJewelry.BLL
{
    internal class KhachHangBLL
    {
        private static KhachHangBLL instance;

        public static KhachHangBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBLL();
                return instance;
            }
        }

        private KhachHangBLL() { }

        public DataTable LayTatCaKhachHang()
        {
            return KhachHangDAO.Instance.LayTatCaKhachHang();
        }

        public KHACHHANG LayKhachHangTheoID(int id)
        {
            return KhachHangDAO.Instance.LayKhachHangTheoID(id);
        }

        public bool ThemKhachHang(KHACHHANG kh)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(kh.HoTen))
                throw new Exception("Họ tên không được để trống");

            if (string.IsNullOrEmpty(kh.SoDienThoai))
                throw new Exception("Số điện thoại không được để trống");

            if (KhachHangDAO.Instance.KiemTraSoDienThoaiTonTai(kh.SoDienThoai))
                throw new Exception("Số điện thoại đã tồn tại");

            kh.NgayVao = DateTime.Now;

            return KhachHangDAO.Instance.ThemKhachHang(kh);
        }

        public bool CapNhatKhachHang(KHACHHANG kh)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(kh.HoTen))
                throw new Exception("Họ tên không được để trống");

            if (string.IsNullOrEmpty(kh.SoDienThoai))
                throw new Exception("Số điện thoại không được để trống");

            if (KhachHangDAO.Instance.KiemTraSoDienThoaiTonTai(kh.SoDienThoai, kh.ID))
                throw new Exception("Số điện thoại đã tồn tại");

            return KhachHangDAO.Instance.CapNhatKhachHang(kh);
        }

        public bool XoaKhachHang(int id)
        {
            return KhachHangDAO.Instance.XoaKhachHang(id);
        }

        public DataTable TimKiemKhachHang(string keyword)
        {
            return KhachHangDAO.Instance.TimKiemKhachHang(keyword);
        }

        public DataTable LaySanPhamDaMua(int maKH)
        {
            return KhachHangDAO.Instance.LaySanPhamDaMua(maKH);
        }

        public int ThemKhachHangMoi(string tenKhachHang, string soDienThoai = null)
        {
            KHACHHANG kh = new KHACHHANG
            {
                HoTen = tenKhachHang,
                SoDienThoai = soDienThoai ?? "0000000000",
                NgayVao = DateTime.Now
            };

            if (ThemKhachHang(kh))
            {
                // Lấy khách hàng vừa thêm để lấy ID
                DataTable dt = LayTatCaKhachHang();
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["ID"]);
                }
            }

            throw new Exception("Không thể thêm khách hàng mới");
        }
    }
}