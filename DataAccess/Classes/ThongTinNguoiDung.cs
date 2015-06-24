using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public class ThongTinNguoiDung
    {
        #region khai bao cac thuoc tinh anh xa
        public int IDTTND { get; set; }
        public int IDNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string NgayCapNhat { get; set; }
        public ThongTinNguoiDung() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(ThongTinNguoiDung ttnd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@IDTTND", "ThongTinNguoiDung_Them",
                    ttnd.IDTTND, ttnd.IDNguoiDung, ttnd.TenNguoiDung, ttnd.ChucVu,
                    ttnd.DiaChi, ttnd.NgaySinh, ttnd.SoDT);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool Sua(ThongTinNguoiDung ttnd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("ThongTinNguoiDung_Sua",
                    ttnd.IDNguoiDung, ttnd.TenNguoiDung, ttnd.ChucVu,
                    ttnd.DiaChi, ttnd.NgaySinh, ttnd.SoDT, ttnd.NgayCapNhat);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static ThongTinNguoiDung LayTheoIDTTND(string idNguoiDung)
        {
            try
            {
                return CBO.FillObject<ThongTinNguoiDung>(DataProvider.Instance.ExecuteReader("ThongTinNguoiDung_LayTheoIDTTND", Convert.ToInt32(idNguoiDung)));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
