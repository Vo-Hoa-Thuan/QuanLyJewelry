using QuanLyJewelry.Business;
using QuanLyJewelry.DAO;
using QuanLyJewelry.Model;
using QuanLyJewelry.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyJewelry
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmNhaCungCap());
            //Application.Run(new Signin());
        }
    }
}
