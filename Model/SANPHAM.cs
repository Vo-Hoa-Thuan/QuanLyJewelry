using System;

namespace QuanLyJewelry.Model
{
    internal class SANPHAM
    {
        public int ID { get; set; }                // Khóa chính
        public string MaSanPham { get; set; }      // Mã SP (SP00001...)
        public string TenSanPham { get; set; }     // Tên sản phẩm
        public int MaLoaiHang { get; set; }        // FK -> LOAIHANG.ID
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; }
        public string HinhAnh { get; set; }
    }
}
