using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Help;
using System.Data;
using DataAccess.Connect;
using Core;

namespace DataAccess.Classes
{
    public class DangNhap
    {
        #region khai bao cac thuoc tinh anh xa
        public int IDDangNhap { get; set; }
        public int IDNguoiDung { get; set; }
        public string ThoiGian { get; set; }
        public string DiaChiIP { get; set; }
        public string HanhDong { get; set; }
        public string TenDangNhap { get; set; }
        public DangNhap() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(DangNhap dangNhap)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@IDDangNhap", "DangNhap_Them", dangNhap.IDDangNhap
                    , dangNhap.IDNguoiDung, dangNhap.ThoiGian, dangNhap.DiaChiIP, dangNhap.HanhDong);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool SuaHanhDong(string idDangNhap, string idNguoiDung, string hanhDong)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DangNhap_SuaHanhDong",
                    ConvertType.ToInt32(idDangNhap), ConvertType.ToInt32(idNguoiDung), hanhDong);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Xoa(string idDangNhap)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DangNhap_Xoa", Convert.ToInt32(idDangNhap));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DangNhap_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static List<DangNhap> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("DangNhap_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DangNhap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DangNhap>();
            }
        }
        public static List<DangNhap> LayTheoIDNguoiDung(string idNguoiDung, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("DangNhap_LayTheoIDNguoiDung", ConvertType.ToInt32(idNguoiDung), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DangNhap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DangNhap>();
            }
        }
        #endregion
    }
}
