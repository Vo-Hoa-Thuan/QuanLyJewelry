using QuanLyJewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyJewelry.DAO
{
    internal class QuyenDAO
    {
        private static QuyenDAO instance;

        internal static QuyenDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyenDAO();
                return instance;
            }
        }
        private QuyenDAO() { }

        public List<QUYEN> getDataQuyen()
        {
            return KetNoiSql.Instance.getDataQuyen();
        }


        public int? getMaQuyen(string tenQuyen)
        {
            string sql = "SELECT ID FROM QUYEN WHERE TenQuyen = @tenQuyen";

            var prms = new Dictionary<string, object>
        {
            { "@tenQuyen", tenQuyen }
        };

            DataTable dt = KetNoiSql.Instance.execSql(sql, prms);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ID"]);
            }
            return null; 
        }


        public string getTenQuyenById(int idQuyen)
        {
            string sql = "SELECT TenQuyen FROM QUYEN WHERE ID = @idQuyen";

            var prms = new Dictionary<string, object>
    {
        { "@idQuyen", idQuyen }
    };

            DataTable dt = KetNoiSql.Instance.execSql(sql, prms);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TenQuyen"].ToString();
            }

            return null; 

        }


    }
}
