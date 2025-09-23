using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyJewelry.Properties
{
    public static class SecurityHelper
    {
        // Tạo hash kèm salt
        public static (string hash, string salt) HashPassword(string password)
        {
            // Tạo random salt 16 bytes
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            // PBKDF2: 10000 iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes hash
                string hash = Convert.ToBase64String(hashBytes);
                string salt = Convert.ToBase64String(saltBytes);
                return (hash, salt);
            }
        }
        // Kiểm tra mật khẩu
        public static bool VerifyPassword(string passwordNhap, string hashTrongDB, string salt)
        {
            if (string.IsNullOrEmpty(passwordNhap) || string.IsNullOrEmpty(hashTrongDB) || string.IsNullOrEmpty(salt))
                return false;

            try
            {
                byte[] saltBytes = Convert.FromBase64String(salt);
                using (var pbkdf2 = new Rfc2898DeriveBytes(passwordNhap, saltBytes, 10000, HashAlgorithmName.SHA256))
                {
                    byte[] hashBytes = pbkdf2.GetBytes(32);
                    string hashNhap = Convert.ToBase64String(hashBytes);
                    return hashNhap == hashTrongDB;
                }
            }
            catch
            {
                return false; // Tránh crash nếu dữ liệu DB bị lỗi
            }
        }

    }
}
