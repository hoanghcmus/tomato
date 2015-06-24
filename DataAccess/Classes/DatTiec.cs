using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;
using System.Data;
using DataAccess.Connect;

namespace DataAccess.Classes
{
    public class DatTiec
    {
        #region khai bao cac thuoc tinh anh xa

        public int ID { get; set; }
        public string Ten { get; set; }

        public string DiaChi { get; set; }
        public string Email { get; set; }

        public int SDT { get; set; }

        public string SoNguoi { get; set; }
        public DateTime Ngay { get; set; }

        public string Gio { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayGui { get; set; }



        public DatTiec() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(DatTiec dattiec)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "DatTiec_Them", dattiec.ID, dattiec.Ten, dattiec.DiaChi, dattiec.Email, dattiec.SDT, dattiec.SoNguoi, dattiec.Ngay, dattiec.Gio, dattiec.TrangThai, dattiec.NgayGui);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(DatTiec dattiec)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTiec_Sua", dattiec.ID, dattiec.Ten, dattiec.DiaChi, dattiec.Email, dattiec.SDT, dattiec.SoNguoi, dattiec.Ngay, dattiec.Gio, dattiec.TrangThai, dattiec.NgayGui);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTrangThai(int id, string trangthai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTiec_SuaTrangThai", id, ConvertType.ToInt32(trangthai));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTiec_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatTiec_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTrangThai(string trangthai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatTiec_DemTheoTrangThai", ConvertType.ToInt32(trangthai)));
            }
            catch
            {
                return 0;
            }
        }

        public static List<DatTiec> ByDate(string startDate, string endDate)
        {
            try
            {
                return CBO.FillCollection<DatTiec>(DataProvider.Instance.ExecuteReader("DatTiec_ByDate", startDate, endDate));
            }
            catch (Exception)
            {
                return new List<DatTiec>();
            }
        }
        public static DatTiec LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<DatTiec>(DataProvider.Instance.ExecuteReader("DatTiec_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<DatTiec> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatTiec_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatTiec>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatTiec>();
            }
        }
        public static List<DatTiec> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatTiec_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatTiec>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatTiec>();
            }
        }
        #endregion
    }
}
