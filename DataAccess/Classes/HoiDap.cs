using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data;
using DataAccess.Connect;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public class HoiDap
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string TieuDe { get; set; }
        public string NoiDungHoi { get; set; }
        public string NoiDungDap { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayGui { get; set; }
        public int TrangThai { get; set; }

        public HoiDap() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static bool Them(HoiDap lienHe)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "HoiDap_Them",
                    lienHe.ID, lienHe.HoTen, lienHe.Email, lienHe.DiaChi, lienHe.TieuDe, lienHe.NoiDungHoi, lienHe.NoiDungDap, lienHe.NgayGui, lienHe.TrangThai);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }

        }
        public static bool Xoa(string id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("HoiDap_Xoa", Convert.ToInt32(id));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTrangThai(string id, string trangThai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("HoiDap_SuaTrangThai", ConvertType.ToInt32(id), ConvertType.ToInt32(trangThai));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool CapNhaHoiDap(string id, string noiDungDap)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("HoiDap_CapNhatHoiDap", ConvertType.ToInt32(id), noiDungDap);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static List<HoiDap> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("HoiDap_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<HoiDap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<HoiDap>();
            }
        }
        public static List<HoiDap> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("HoiDap_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, pageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<HoiDap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<HoiDap>();
            }
        }



        public static List<HoiDap> LayTatCaTheoTrangThai(int trangThai)
        {
            try
            {
                return CBO.FillCollection<HoiDap>(DataProvider.Instance.ExecuteReader("HoiDap_LayTatCaTheoTrangThai", trangThai));
            }
            catch
            { return null; }
        }

        public static List<HoiDap> LayTheoTrangThaiVaTheLoai(string trangThai, string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("HoiDap_LayTheoTrangThaiVaTheLoai", ConvertType.ToInt32(trangThai), ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<HoiDap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<HoiDap>();
            }
        }
        public static List<HoiDap> LayTheoTheLoai(string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("HoiDap_LayTheoTheLoai", ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<HoiDap>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<HoiDap>();
            }
        }
        public static HoiDap LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<HoiDap>(DataProvider.Instance.ExecuteReader("HoiDap_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static int Dem()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("HoiDap_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTrangThai(int trangThai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("HoiDap_DemTheoTrangThai", trangThai));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTheLoai(int theloai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("HoiDap_DemTheoTheLoai", theloai));
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
