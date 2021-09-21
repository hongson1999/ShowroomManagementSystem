using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Extensions
{
    public static class StringExtensions
    {
        public static string GenerateRandomId(this string currentString, int number)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var strChars = new char[number];
            for(int i = 0; i < strChars.Length; i++)
            {
                strChars[i] = chars[random.Next(chars.Length)];
            }

            return $"{currentString}-{new String(strChars)}";
        }

        public static string HashPasswordMD5(this string currentStr)
        {
            string salt = "IAmVeryHandsome";
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes($"{currentStr}.{salt}"));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
