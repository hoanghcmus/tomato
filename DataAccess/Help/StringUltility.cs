using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace DataAccess.StringUtil
{
    public class StringUltility
    {
        public static string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static String createMoneyString(String sInput)
        {
            string sFirst = "";
            string sLast = "";
            sInput = sInput.Trim();

            int lenght = sInput.Length;

            if (lenght > 3)
            {
                sFirst = sInput.Substring(0, lenght - 3).Trim();
                sLast = sInput.Substring(lenght - 3, 3).Trim();

                sFirst = StringUltility.createMoneyString(sFirst);

                sInput = sFirst + "." + sLast;
            }

            return sInput;
        }
        public static string GetStringByLenght(string inputString, int lenght)
        {
            int stringLenght = inputString.Length;
            if (stringLenght >= lenght)
            {
                inputString = inputString.Substring(0, lenght);
            }
            return inputString;
        }

        public static string GetLocale(string locale)
        {
            switch (locale)
            {
                case "vn":
                    return "vi-VN";
                case "en":
                    return "en-US";
                case "ru":
                    return "ru-RU";
                default: return "en-US";
            }
        }
    }


}