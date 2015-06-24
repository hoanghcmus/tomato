using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DataAccess.StringUtil;

namespace DataAccess.Help
{
    public class Helper
    {
        public static string ToAlias(string text)
        {
            if (String.IsNullOrEmpty(text))
                return text;
            text = text.Replace("_", " ");
            string joinString = "-";
            string[] words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                words[i] = UnicodeToAsscii(word).ToLower();
            }
            return String.Join(joinString, words);
        }
        public static string UnicodeToAsscii(string unicode)
        {
            Regex reg = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string frmD = unicode.Normalize(NormalizationForm.FormD);
            return reg.Replace(frmD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

        }
        //dinh dang kieu dateTime:ngay.thang.nam gio:phut
        public static string ToDateString(DateTime? date)
        {
            if (date == null)
                return "";
            return date.Value.ToString("dd.MM.yyyy HH:mm");
        }
        public static string ToShorDateString(DateTime? date)
        {
            if (date == null)
                return "";
            return "(" + date.Value.ToString("dd/MM/yyyy") + ")";
        }
        //dinh dang kieu Nam, nu
        public static string ToGioiTinh(Boolean? date)
        {
            if (date == true)
                return "Nam";
            return "Nữ";
        }
        public static string TinhTiLePhanTram(int a, int tong)
        {
            if (tong != 0)
            {
                string str = " %";
                double tam;
                tam = ((Convert.ToDouble(a) * 100) / tong);
                return Math.Round(tam, 2).ToString() + str;
            }
            else
                return "0 %";
        }
        public static string ToGioiTinhKhac(int? date)
        {
            string str = "";
            switch (date)
            {
                case 1:
                    str = "Nam";
                    break;
                case 2:
                    str = "Nữ";
                    break;
                case 3:
                    str = "Khác";
                    break;
                default:
                    str = "Khác";
                    break;
            }
            return str;
        }
        public static string ToThongTinViecLam(int? date)
        {
            string str = "";
            switch (date)
            {
                case 0:
                    str = "Chưa có việc làm";
                    break;
                case 1:
                    str = "Đã có việc làm";
                    break;
            }
            return str;
        }
        public static string ToYKien(int? date)
        {
            string str = "";
            switch (date)
            {
                case 1:
                    str = "Rất đạt";
                    break;
                case 2:
                    str = "Đạt";
                    break;
                case 3:
                    str = "Phân vân";
                    break;
                case 4:
                    str = "Chưa đạt";
                    break;
                case 5:
                    str = "Hoàn toàn chưa đạt";
                    break;
            }
            return str;
        }
        //dinh dang kieu Nam, nu
        public static string ToMonHoc(Boolean? date)
        {
            if (date == true)
                return "Bắt buộc";
            return "Tự chọn";
        }
        //Kiem tra chuoi nhap vao la so
        public static Boolean IsNumber(string Value)
        {
            foreach (Char c in Value)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        //dinh dang kieu DateTime: Thu, ngay thang nam
        public static string ToLongDateString(DateTime? date)
        {
            if (date == null)
                return "";
            return date.Value.ToString("dddd, dd MMMM yyyy HH:mm");
        }
        public static void EnumToListBox(Type EnumType, ListControl TheListBox)
        {
            Array Values = System.Enum.GetValues(EnumType);

            foreach (int Value in Values)
            {
                string Display = Enum.GetName(EnumType, Value);
                ListItem Item = new ListItem(Display, Value.ToString());
                TheListBox.Items.Add(Item);
            }
        }
        public static void EnumStringToListBox(Type EnumType, ListControl TheListBox)
        {
            Array Values = System.Enum.GetValues(EnumType);

            foreach (int Value in Values)
            {
                string Display = Enum.GetName(EnumType, Value);
                ListItem Item = new ListItem("~/Controls/" + Display + ".ascx", Value.ToString());
                TheListBox.Items.Add(Item);
            }
        }
        public static string ReadTagXML(string xml)
        {
            string hashValue = "";
            XDocument doc = XDocument.Parse(xml);
            foreach (XElement hashElement in doc.Descendants("maxItem"))
            {
                hashValue = (string)hashElement;
            }
            return hashValue;
        }
        //Chuyen chuoi
        public static string RejectMarks(string valus)
        {
            string text = valus.ToLowerInvariant();
            string[] pattern = new string[7];
            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "o|(ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            text = removewhite(text);
            return text;
        }
        public static string ChuyenChuoiSangThuong(string valus)
        {
            string text = valus.ToLowerInvariant();
            return text;
        }
        public static string removewhite(string valu)
        {
            string s = valu.Trim();
            while (s.IndexOf("'") >= 0 || s.IndexOf(":") >= 0 || s.IndexOf("\"") >= 0 || s.IndexOf("?") >= 0 || s.IndexOf("&") >= 0 || s.IndexOf("|") >= 0 || s.IndexOf(" ") >= 0 || s.IndexOf("/") >= 0 || s.IndexOf("\\") >= 0 || s.IndexOf(".") >= 0)    //tim trong chuoi vi tri co khoang trong       
            {
                s = s.Replace("'", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace(":", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace(" ", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("\"", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("?", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("|", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace(".", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("\\", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("/", "-");   //sau do thay the bang 1 dau '-'
                s = s.Replace("&", "-");   //sau do thay the bang 1 dau '-'
            }
            return s;
        }
        public static string ToFirstUpper(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            string result = "";
            //lấy danh sách các từ
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result.Trim();
        }
        public static string ConvertToTitleCase(string s)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        public static string ToSQLServerDateTimeString(string dateString, string dateFormatString, string dateFormatForReplace)
        {
            DateTime dt = DateTime.ParseExact(dateString, dateFormatString, CultureInfo.InvariantCulture);
            return String.Format("{0:" + dateFormatForReplace + "}", dt);
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
        public static string ToThumb(string source)
        {
            source = source ?? "";
            if (source.StartsWith("/Uploads/"))
            {
                if (!source.StartsWith("/Uploads/_thumbs/"))
                    return source.Replace("/Uploads/", "/Uploads/_thumbs/");
            }
            return source;
        }

    }
}
