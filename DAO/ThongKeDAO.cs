using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyJewelry.DAO
{
    internal class ThongKeDAO
    {
        private static ThongKeDAO instance;

        public static ThongKeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongKeDAO();
                return instance;
            }
        }

        private ThongKeDAO() { }

        public DataTable LayDoanhThuTheoThang(int nam, int thang)
        {
            string sql = @"SELECT 
                CONVERT(DATE, NgayGD) as Ngay,
                ISNULL(SUM(TongTien), 0) as DoanhThu,
                COUNT(*) as SoDonHang
            FROM GIAODICH 
            WHERE LoaiGD = 'BAN_RA' 
                AND YEAR(NgayGD) = @Nam 
                AND MONTH(NgayGD) = @Thang
            GROUP BY CONVERT(DATE, NgayGD)
            ORDER BY Ngay";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayTopSanPham(int top, int nam, int thang)
        {
            string sql = $@"SELECT TOP {top}
                sp.TenSanPham,
                lh.TenLoaiHang as LoaiSanPham,
                ISNULL(SUM(ct.SoLuong), 0) as SoLuongBan,
                ISNULL(SUM(ct.SoLuong * ct.DonGia), 0) as DoanhThu
            FROM CHITIETGIAODICH ct
            JOIN SANPHAM sp ON ct.MaSanPham = sp.ID
            JOIN LOAIHANG lh ON sp.MaLoaiHang = lh.ID
            JOIN GIAODICH gd ON ct.MaGD = gd.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND YEAR(gd.NgayGD) = @Nam
                AND MONTH(gd.NgayGD) = @Thang
            GROUP BY sp.TenSanPham, lh.TenLoaiHang
            ORDER BY DoanhThu DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayDoanhThuNhanVien(int nam, int thang)
        {
            string sql = @"SELECT 
                nv.HoTen as TenNhanVien,
                COUNT(*) as SoDonHang,
                ISNULL(SUM(gd.TongTien), 0) as DoanhThu,
                ISNULL(AVG(NULLIF(gd.TongTien, 0)), 0) as DonGiaTrungBinh
            FROM GIAODICH gd
            JOIN NHANVIEN nv ON gd.MaNhanVien = nv.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND YEAR(gd.NgayGD) = @Nam
                AND MONTH(gd.NgayGD) = @Thang
            GROUP BY nv.HoTen
            ORDER BY DoanhThu DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayTopKhachHang(int top, int nam, int thang)
        {
            string sql = $@"SELECT TOP {top}
                kh.ID as MaKhachHang,
                kh.HoTen as TenKhachHang,
                COUNT(*) as SoLanMua,
                ISNULL(SUM(gd.TongTien), 0) as TongChiTieu,
                MAX(gd.NgayGD) as LanMuaGanNhat
            FROM GIAODICH gd
            JOIN KHACHHANG kh ON gd.MaKhachHang = kh.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND YEAR(gd.NgayGD) = @Nam
                AND MONTH(gd.NgayGD) = @Thang
            GROUP BY kh.ID, kh.HoTen
            ORDER BY TongChiTieu DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayDoanhThuTheoLoaiSP(int nam, int thang)
        {
            string sql = @"SELECT 
                lh.TenLoaiHang as LoaiSanPham,
                ISNULL(SUM(ct.SoLuong), 0) as SoLuongBan,
                ISNULL(SUM(ct.SoLuong * ct.DonGia), 0) as DoanhThu
            FROM CHITIETGIAODICH ct
            JOIN SANPHAM sp ON ct.MaSanPham = sp.ID
            JOIN LOAIHANG lh ON sp.MaLoaiHang = lh.ID
            JOIN GIAODICH gd ON ct.MaGD = gd.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND YEAR(gd.NgayGD) = @Nam
                AND MONTH(gd.NgayGD) = @Thang
            GROUP BY lh.TenLoaiHang
            ORDER BY DoanhThu DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayTongQuan(int nam, int thang)
        {
            string sql = @"SELECT 
                COUNT(*) as TongSoDonHang,
                ISNULL(SUM(TongTien), 0) as TongDoanhThu,
                ISNULL(AVG(NULLIF(TongTien, 0)), 0) as DonGiaTrungBinh,
                (SELECT COUNT(DISTINCT MaKhachHang) FROM GIAODICH 
                 WHERE LoaiGD = 'BAN_RA' AND YEAR(NgayGD) = @Nam AND MONTH(NgayGD) = @Thang) as SoKhachHang
            FROM GIAODICH 
            WHERE LoaiGD = 'BAN_RA'
                AND YEAR(NgayGD) = @Nam
                AND MONTH(NgayGD) = @Thang";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LayDoanhThuTheoNam(int nam)
        {
            string sql = @"SELECT 
                MONTH(NgayGD) as Thang,
                ISNULL(SUM(TongTien), 0) as DoanhThu,
                COUNT(*) as SoDonHang
            FROM GIAODICH 
            WHERE LoaiGD = 'BAN_RA' 
                AND YEAR(NgayGD) = @Nam
            GROUP BY MONTH(NgayGD)
            ORDER BY Thang";

            var parameters = new Dictionary<string, object>
            {
                { "@Nam", nam }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LaySanPhamDaMuaKhachHang(int maKhachHang, int nam, int thang)
        {
            string sql = @"SELECT 
                gd.ID as MaGiaoDich,
                CONVERT(DATE, gd.NgayGD) as NgayGD,
                sp.TenSanPham,
                ISNULL(ct.SoLuong, 0) as SoLuong,
                ISNULL(ct.DonGia, 0) as DonGia,
                ISNULL(ct.SoLuong * ct.DonGia, 0) as ThanhTien
            FROM GIAODICH gd
            JOIN CHITIETGIAODICH ct ON gd.ID = ct.MaGD
            JOIN SANPHAM sp ON ct.MaSanPham = sp.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND gd.MaKhachHang = @MaKhachHang
                AND YEAR(gd.NgayGD) = @Nam
                AND MONTH(gd.NgayGD) = @Thang
            ORDER BY gd.NgayGD DESC, gd.ID DESC, sp.TenSanPham";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhachHang", maKhachHang },
                { "@Nam", nam },
                { "@Thang", thang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }

        public DataTable LaySanPhamDaMuaKhachHangAll(int maKhachHang)
        {
            string sql = @"SELECT 
                gd.ID as MaGiaoDich,
                CONVERT(DATE, gd.NgayGD) as NgayGD,
                sp.TenSanPham,
                ISNULL(ct.SoLuong, 0) as SoLuong,
                ISNULL(ct.DonGia, 0) as DonGia,
                ISNULL(ct.SoLuong * ct.DonGia, 0) as ThanhTien
            FROM GIAODICH gd
            JOIN CHITIETGIAODICH ct ON gd.ID = ct.MaGD
            JOIN SANPHAM sp ON ct.MaSanPham = sp.ID
            WHERE gd.LoaiGD = 'BAN_RA'
                AND gd.MaKhachHang = @MaKhachHang
            ORDER BY gd.NgayGD DESC, gd.ID DESC, sp.TenSanPham";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhachHang", maKhachHang }
            };

            return KetNoiSql.Instance.execSql(sql, parameters);
        }
    }
}