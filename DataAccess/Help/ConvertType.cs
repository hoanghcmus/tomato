using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DataAccess.Help
{
    public class ConvertType
    {
        public static int ToInt32(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static string ToString(object value)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch
            {
                return "";
            }
        }

        public static DateTime ToDateTime(object value)
        {
            try
            {
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "MM/dd/yyyy";
                dtfi.DateSeparator = "/";
                DateTime objDate = Convert.ToDateTime(value, dtfi);
                return Convert.ToDateTime(objDate);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static string ToShorDateString(DateTime? date)
        {
            if (date == null)
                return "";
            return date.Value.ToString("MM/dd/yyyy");
        }
        public static DateTime ToShortDateTimeNow()
        {
            string str = DateTime.Now.ToShortDateString();
            return Convert.ToDateTime(str);
        }
        public static DateTime ToShortDateTime(DateTime date)
        {
            string str = date.ToShortDateString();
            return Convert.ToDateTime(str);
        }

        public static DateTime ToDateTime(object value, string format)
        {
            try
            {
                DateTimeFormatInfo di = new DateTimeFormatInfo();
                di.ShortDatePattern = format;
                return Convert.ToDateTime(value, di);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static DateTime? ToNullableDateTime(object value)
        {
            try
            {
                if (value == null)
                    return null;
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }

    }
}
