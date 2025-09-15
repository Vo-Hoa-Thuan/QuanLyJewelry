using System;

namespace QuanLyJewelry.Model
{
    internal class LOAIHANG
    {
        public int ID { get; set; }              // Khóa chính
        public string MaLoaiHang { get; set; }   // Mã định dạng (sinh tự động)
        public string TenLoaiHang { get; set; }  // Tên loại hàng
    }
}
