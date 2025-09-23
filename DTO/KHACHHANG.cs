using System;

namespace QuanLyJewelry.DTO
{
    internal class KHACHHANG
    {
        public int ID { get; set; }              // Khóa chính
        public string MaKhachHang { get; set; }  // Mã khách hàng (KH00001...)
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayVao { get; set; }    // Ngày vào hệ thống
    }
}
