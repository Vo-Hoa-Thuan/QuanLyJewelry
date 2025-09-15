using QuanLyJewelry.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyJewelry.DAO
{
    internal class GiaoDichDAO
    {
        private static GiaoDichDAO instance;

        internal static GiaoDichDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoDichDAO();
                return instance;
            }
        }

        private GiaoDichDAO() { }

        public DataTable LayDanhSachKhachHang()
        {
            string sql = "SELECT ID, HoTen FROM KHACHHANG";
            return KetNoiSql.Instance.execSql(sql);
        }

        public DataTable LayDanhSachNhanVien()
        {
            string sql = "SELECT ID, HoTen FROM NHANVIEN";
            return KetNoiSql.Instance.execSql(sql);
        }

        public DataTable LayDanhSachSanPham()
        {
            string sql = "SELECT ID, TenSanPham, GiaBan FROM SANPHAM";
            return KetNoiSql.Instance.execSql(sql);
        }

        public decimal LayGiaSanPham(int maSanPham)
        {
            string sql = $"SELECT GiaBan FROM SANPHAM WHERE ID = {maSanPham}";
            DataTable dt = KetNoiSql.Instance.execSql(sql);
            
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["GiaBan"]);
            }
            return 0;
        }


        public bool TaoDonHang(GIAODICH gd, List<CHITIETGIAODICH> chiTietList)
        {
            using (var conn = new SqlConnection(KetNoiSql.Instance.GetConnection().ConnectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm giao dịch
                        string sqlGD = @"INSERT INTO GIAODICH(LoaiGD, MaKhachHang, MaNhanVien, NgayGD, TongTien)
                                 VALUES(@LoaiGD, @MaKhachHang, @MaNhanVien, GETDATE(), @TongTien);
                                 SELECT SCOPE_IDENTITY();";

                        using (var cmdGD = new SqlCommand(sqlGD, conn, tran))
                        {
                            cmdGD.Parameters.AddWithValue("@LoaiGD", gd.LoaiGD);
                            cmdGD.Parameters.AddWithValue("@MaKhachHang", gd.MaKhachHang);
                            cmdGD.Parameters.AddWithValue("@MaNhanVien", gd.MaNhanVien);
                            cmdGD.Parameters.AddWithValue("@TongTien", gd.TongTien);

                            long maGD = Convert.ToInt64(cmdGD.ExecuteScalar());

                            // 2. Thêm chi tiết giao dịch
                            foreach (var ct in chiTietList)
                            {
                                string sqlCT = @"INSERT INTO CHITIETGIAODICH(MaGD, MaSanPham, SoLuong, DonGia)
                                         VALUES(@MaGD, @MaSanPham, @SoLuong, @DonGia)";
                                using (var cmdCT = new SqlCommand(sqlCT, conn, tran))
                                {
                                    cmdCT.Parameters.AddWithValue("@MaGD", maGD);
                                    cmdCT.Parameters.AddWithValue("@MaSanPham", ct.MaSanPham);
                                    cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                    cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);

                                    cmdCT.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Lỗi khi tạo đơn hàng: " + ex.Message);
                    }
                }
            }
        }

    }
}