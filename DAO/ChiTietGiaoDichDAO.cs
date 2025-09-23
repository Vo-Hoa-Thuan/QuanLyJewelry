using QuanLyJewelry.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyJewelry.DAO
{
    internal class ChiTietGiaoDichDAO
    {
        private static ChiTietGiaoDichDAO instance;

        internal static ChiTietGiaoDichDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietGiaoDichDAO();
                return instance;
            }
        }

        private ChiTietGiaoDichDAO() { }

        // Xem tất cả chi tiết giao dịch
        public DataTable Xem()
        {
            string sql = "SELECT * FROM CHITIETGIAODICH";
            return KetNoiSql.Instance.execSql(sql);
        }

        // Thêm chi tiết giao dịch
        public bool Them(CHITIETGIAODICH ct)
        {
            string sql = @"INSERT INTO CHITIETGIAODICH (MaGD, MaSanPham, SoLuong, DonGia)
                           VALUES (@maGD, @maSP, @soLuong, @donGia)";

            var prms = new Dictionary<string, object>
            {
                { "@maGD", ct.MaGD},
                { "@maSP", ct.MaSanPham },
                { "@soLuong", ct.SoLuong },
                { "@donGia", ct.DonGia }
            };

            return KetNoiSql.Instance.execNonSql(sql, prms) > 0;
        }

        // Xem chi tiết theo mã giao dịch
        public DataTable GetByMaGD(long maGD)
        {
            string sql = @"SELECT c.MaSanPham, s.TenSanPham, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien
                           FROM CHITIETGIAODICH c
                           INNER JOIN SANPHAM s ON s.ID = c.MaSanPham
                           WHERE c.MaGD = @maGD";

            var prms = new Dictionary<string, object>
            {
                { "@maGD", maGD }
            };

            return KetNoiSql.Instance.execSql(sql, prms);
        }
    }
}
