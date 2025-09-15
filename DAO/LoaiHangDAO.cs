using DocumentFormat.OpenXml.Bibliography;
using SaleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleApp.DAO
{
    internal class QuanLyJewelry
    {
        private static QuanLyJewelry instance;

        internal static QuanLyJewelry Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuanLyJewelry();
                return instance;
            }
        }
    

        private QuanLyJewelry() { }

        public List<LOAIHANG> getDataLoaiHang()
        {
            string sql = "SELECT ID, MaLoaiHang, TenLoaiHang FROM LOAIHANG";

            return KetNoiSql.Instance.GetList(sql, row => new LOAIHANG
            {
                ID = Convert.ToInt32(row["ID"]),
                MaLoaiHang = row["MaLoaiHang"].ToString(),
                TenLoaiHang = row["TenLoaiHang"].ToString()
            });
        }


        public DataTable getMaLoaiHang(string masp)
        {
            string sql = $"select MaLoaiHang,TenLoaiHang from LOAIHANG where TenLoaiHang = N'{masp}'";
            return KetNoiSql.Instance.execSql(sql);
        }
    }
}
