using System;
using System.Security.Cryptography;
using System.Text;

namespace BlogApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public User()
        {
            CreatedDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
            IsAdmin = false;
        }

        // Hash password using SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Verify password
        public bool VerifyPassword(string password)
        {
            string hashedPassword = HashPassword(password);
            return PasswordHash == hashedPassword;
        }
    }
}
