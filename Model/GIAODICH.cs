using System;

namespace QuanLyJewelry.Model
{
    internal class GIAODICH
    {
        public long ID { get; set; }              // Khóa chính
        public string MaGD { get; set; }          // Mã giao dịch (GD000001...)
        public string LoaiGD { get; set; }        // Loại GD: MUA_VAO hoặc BAN_RA
        public int MaKhachHang { get; set; }      // FK -> KHACHHANG.ID
        public int MaNhanVien { get; set; }       // FK -> NHANVIEN.ID
        public DateTime NgayGD { get; set; }      // Ngày giao dịch
        public decimal TongTien { get; set; }     // Tổng tiền
    }
}
