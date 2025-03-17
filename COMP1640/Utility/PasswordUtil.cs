using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class PasswordUtil
    {
        public static string HashPassword(string password)
        {
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes("comp1640")))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPasswordHash(string password, string storedHash)
        {
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes("comp1640")))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return storedHash == Convert.ToBase64String(computedHash);
            }
        }
    }
}
