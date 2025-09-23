using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyJewelry.DTO
{
    public class ThongKeDoanhThu
    {
        public DateTime Ngay { get; set; }
        public decimal DoanhThu { get; set; }
        public int SoDonHang { get; set; }
    }

    public class ThongKeSanPham
    {
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal PhanTram { get; set; }
    }

    public class ThongKeNhanVien
    {
        public string TenNhanVien { get; set; }
        public int SoDonHang { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal DonGiaTrungBinh { get; set; }
    }

    public class ThongKeKhachHang
    {
        public string TenKhachHang { get; set; }
        public int SoLanMua { get; set; }
        public decimal TongChiTieu { get; set; }
        public DateTime LanMuaGanNhat { get; set; }
    }

    public class ThongKeLoaiSanPham
    {
        public string LoaiSanPham { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal PhanTram { get; set; }
    }

    public class ThongKeVatLieu
    {
        public string LoaiVatLieu { get; set; }
        public int SoLuong { get; set; }
        public decimal DoanhThu { get; set; }
    }
}