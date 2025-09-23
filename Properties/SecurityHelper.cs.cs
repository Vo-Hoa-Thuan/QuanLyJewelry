using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyJewelry.Properties
{
    public static class SecurityHelper
    {
        private static readonly string salt = "thuan2828";

        // Hash mật khẩu
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                string passWithSalt = password + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(passWithSalt);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Verify password
        public static bool VerifyPassword(string passwordNhap, string hashTrongDB)
        {
            string hashNhap = HashPassword(passwordNhap);
            return hashNhap == hashTrongDB;
        }
    }
}
