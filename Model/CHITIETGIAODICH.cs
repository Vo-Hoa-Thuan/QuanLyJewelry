using System;

namespace QuanLyJewelry.Model
{
    internal class CHITIETGIAODICH
    {
        public long MaGD { get; set; }            // FK -> GIAODICH.ID
        public int MaSanPham { get; set; }        // FK -> SANPHAM.ID
        public int SoLuong { get; set; }          // Số lượng sản phẩm
        public decimal DonGia { get; set; }       // Đơn giá tại thời điểm giao dịch
    }
}
