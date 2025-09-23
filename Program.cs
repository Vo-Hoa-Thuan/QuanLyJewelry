using QuanLyJewelry.BLL;
using QuanLyJewelry.DAO;
using QuanLyJewelry.DT0;
using QuanLyJewelry.GUI;
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
            Application.Run(new Signin());
            //Application.Run(new Signin());
        }
    }
}
