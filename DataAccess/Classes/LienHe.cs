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
    public class LienHe
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayGui { get; set; }
        public int TrangThai { get; set; }
        public int TheLoai { get; set; }
        public LienHe() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static bool Them(LienHe lienHe)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "LienHe_Them",
                    lienHe.ID, lienHe.HoTen, lienHe.Email, lienHe.DiaChi,lienHe.TieuDe, lienHe.NoiDung,lienHe.NgayGui, lienHe.TrangThai,lienHe.TheLoai);
                return Convert.ToInt32(rs)>0;
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
                object rs = DataProvider.Instance.ExecuteNonQuery("LienHe_Xoa", Convert.ToInt32(id));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("LienHe_SuaTrangThai", ConvertType.ToInt32(id),ConvertType.ToInt32(trangThai));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static List<LienHe> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("LienHe_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<LienHe>();
            }
        }
        public static List<LienHe> LayTheoTrangThai(string trangThai,string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("LienHe_LayTheoTrangThai",ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<LienHe>();
            }
        }
        public static List<LienHe> LayTheoTrangThaiVaTheLoai(string trangThai,string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("LienHe_LayTheoTrangThaiVaTheLoai", ConvertType.ToInt32(trangThai), ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<LienHe>();
            }
        }
        public static List<LienHe> LayTheoTheLoai(string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("LienHe_LayTheoTheLoai", ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<LienHe>();
            }
        }
        public static LienHe LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<LienHe>(DataProvider.Instance.ExecuteReader("LienHe_LayTheoID", Convert.ToInt32(id)));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("LienHe_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTrangThaiVaTheLoai(int trangThai,int theloai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("LienHe_DemTheoTrangThaiVaTheLoai",trangThai,theloai));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("LienHe_DemTheoTheLoai", theloai));
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
