using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
