using System;

namespace QuanLyJewelry.Model
{
    internal class QUYEN
    {
        public int ID { get; set; }           // Khóa chính (mã quyền)
        public string MaQuyen { get; set; } 
    
        public string TenQuyen { get; set; }  // Tên quyền (Admin, Nhân viên, Quản lý...)
    }
}
