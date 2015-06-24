using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Help;
using Core;

namespace DataAccess.Classes
{
    public class NguoiDung
    {
        #region khai bao cac thuoc tinh anh xa
        public int IDNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        //Các thuộc tính kết
        public string TenNguoiDung { get; set; }
        public string ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string NgayCapNhat { get; set; }
        public NguoiDung() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(NguoiDung nd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@IDNguoiDung", "NguoiDung_Them",
                    nd.IDNguoiDung, nd.TenDangNhap, nd.MatKhau);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool SuaMatKhau(string idNguoiDung, string matKhau)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("NguoiDung_SuaMatKhau", Convert.ToInt32(idNguoiDung), matKhau);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Xoa(string idNguoiDung)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("NguoiDung_Xoa", Convert.ToInt32(idNguoiDung));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int Dem()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("NguoiDung_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTenDangNhap(string tenDangNhap)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("NguoiDung_DemTenDangNhap", tenDangNhap));
            }
            catch
            {
                return 0;
            }
        }
        public static NguoiDung KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                return CBO.FillObject<NguoiDung>(DataProvider.Instance.ExecuteReader("NguoiDung_KiemTraDangNhap", tenDangNhap, matKhau));
            }
            catch
            {
                return null;
            }
        }
        public static NguoiDung KiemTraMatKhau(string idNguoiDung, string matKhau)
        {
            try
            {
                return CBO.FillObject<NguoiDung>(DataProvider.Instance.ExecuteReader("NguoiDung_KiemTraMatKhau", ConvertType.ToInt32(idNguoiDung), matKhau));
            }
            catch
            {
                return null;
            }
        }
        public static List<NguoiDung> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<NguoiDung>(DataProvider.Instance.ExecuteReader("NguoiDung_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }
        public static NguoiDung LayThongTinDangNhap(string idNguoiDung)
        {
            try
            {
                return CBO.FillObject<NguoiDung>(DataProvider.Instance.ExecuteReader("NguoiDung_LayThongTinDangNhap", ConvertType.ToInt32(idNguoiDung)));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
