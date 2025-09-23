using System;

namespace QuanLyJewelry.DTO
{
    internal class GIAVANG
    {
        public int ID { get; set; }             // Khóa chính
        public DateTime Ngay { get; set; }      // Ngày cập nhật giá
        public string LoaiVang { get; set; }    // Loại vàng (VD: 9999, 18K, 24K...)
        public decimal GiaMua { get; set; }     // Giá mua vào
        public decimal GiaBan { get; set; }     // Giá bán ra
    }
}
