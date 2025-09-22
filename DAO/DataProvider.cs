using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyJewelry.Model;

namespace QuanLyJewelry.DAO
{
    internal class DataProvider
        
    {
        private static DataProvider instance; // ctrl + r + e đóng gói
        SqlCommand sqlCommand;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        // hàm dựng 
        private DataProvider() { }

        private string connectionSTR = @"Data Source=VOHOATHUAN\VOHOATHUAN1;Initial Catalog=db_Jewelry;Integrated Security=True";





        // procedure theo mảng
        public DataTable ExcuteQuery(string query , object[] parameter = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }    
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;

        }

        // hien ra số dòng thành công
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;

        }
        //đếm số dong thành công
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            Object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;

        }

        //public void Commanđ(HinhAnh hinhanh , string query)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionSTR))
        //    {
        //        connection.Open();

        //        sqlCommand = new SqlCommand(query, connection);
                
        //        sqlCommand.Parameters.Add("@TenHinhAnh", SqlDbType.NVarChar).Value = hinhanh.Tenhinhanh;


        //        connection.Close();
        //    }

         

        //}

        // INSERT, UPDATE, DELETE ....
        public int execNonSql(string sql, params Object[] args)
        {
            int effectedRows;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (args.Length > 0)
                {
                    string[] processSql = sql.Split(' ');
                    List<string> paramList = new List<string>();
                    foreach (string s in processSql)
                        if (s.StartsWith("@"))
                        {
                            if (s.EndsWith(","))
                                paramList.Add(s.Remove(s.Length - 1));
                            else paramList.Add(s);
                        }
                    for (int i = 0; i < args.Length; i++)
                        command.Parameters.AddWithValue(paramList[i], args[i]);
                }
                effectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            return effectedRows;
        }
        // SELECT ....
        public DataTable execSql(string sql, params Object[] args)
        {
            DataTable dat = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (args.Length > 0)
                {
                    string[] processSql = sql.Split(' ');
                    List<string> paramList = new List<string>();
                    foreach (string s in processSql)
                        if (s.StartsWith("@"))
                        {
                            if (s.EndsWith(","))
                                paramList.Add(s.Remove(s.Length - 1));
                            else paramList.Add(s);
                        }
                    for (int i = 0; i < args.Length; i++)
                        command.Parameters.AddWithValue(paramList[i], args[i]);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dat);
                connection.Close();
            }
            return dat;
        }
        //public void Insert(string query, KhachHang KhachHang)
        //{
        //    Object data = 0;
        //    using (SqlConnection connection = new SqlConnection(connectionSTR))
        //    {
        //        connection.Open();

        //        SqlCommand command = new SqlCommand(query, connection);

        //        //if (parameter != null)
        //        //{
        //            //string[] listPara = query.Split(' ');

        //            //int i = 0;
        //            //foreach (string item in listPara)
        //            //{
        //                //if (item.Contains('@'))
        //                //{
        //                    command.Parameters.Add("@Hoten",SqlDbType.NVarChar).Value = KhachHang.Hoten ;
        //                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = KhachHang.Sdt;
        //            //i++;
        //            //}
        //            //}
        //        //}

        //        //data = command.ExecuteScalar();

        //        connection.Close();
        //    }

        //    //return data;

        //}

    }
}
