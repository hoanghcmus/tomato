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
    public class DatPhong
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int SDT { get; set; }
        public string NguoiLon { get; set; }
        public string TreEm { get; set; }
        public string YeuCauKhac { get; set; }
        public DateTime NgayGui { get; set; }
        public int TrangThai { get; set; }
        public int IDPhong { get; set; }
        //Lay ket bang Tour
        public string Name_Vn { get; set; }
        public string Name_En { get; set; }
        public string Name_Ru { get; set; }
        public string Description_Vn { get; set; }
        public string Description_En { get; set; }
        public string Description_Ru { get; set; }
        public string Detail_Vn { get; set; }
        public string Detail_En { get; set; }
        public string Detail_Ru { get; set; }
        public decimal? Price { get; set; }
        public string Thumbnail { get; set; }

        public DateTime NgayDen { get; set; }
        public DateTime NgayDi { get; set; }

        public DatPhong() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(DatPhong dattour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "DatPhong_Them",
                    dattour.ID, dattour.HoTen, dattour.Email, dattour.DiaChi, dattour.SDT,
                    dattour.NguoiLon, dattour.TreEm, dattour.YeuCauKhac, dattour.NgayGui,
                    dattour.TrangThai, dattour.IDPhong, dattour.NgayDen, dattour.NgayDi);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(DatPhong dattour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DatPhong_Sua",
                    dattour.ID, dattour.HoTen, dattour.Email, dattour.DiaChi, dattour.SDT,
                    dattour.NguoiLon, dattour.TreEm, dattour.YeuCauKhac, dattour.NgayGui,
                    dattour.TrangThai, dattour.IDPhong);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("DatPhong_SuaTrangThai", id, ConvertType.ToInt32(trangthai));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("DatPhong_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatPhong_Dem"));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatPhong_DemTheoTrangThai", ConvertType.ToInt32(trangthai)));
            }
            catch
            {
                return 0;
            }
        }
        public static int DatPhong_DemTheoIDPhongTrongKhoangThoiGianXacDinh(int idPhong, DateTime ngayDen, DateTime ngayDi)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatPhong_DemTheoIDPhongTrongKhoangThoiGianXacDinh", idPhong, ngayDen, ngayDi));
            }
            catch
            {
                return 0;
            }
        }
        public static List<DatPhong> ByDate(string startDate, string endDate)
        {
            try
            {
                return CBO.FillCollection<DatPhong>(DataProvider.Instance.ExecuteReader("DatPhong_ByDate", startDate, endDate));
            }
            catch (Exception)
            {
                return new List<DatPhong>();
            }
        }
        public static DatPhong LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<DatPhong>(DataProvider.Instance.ExecuteReader("DatPhong_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<DatPhong> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatPhong_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatPhong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatPhong>();
            }
        }
        public static List<DatPhong> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatPhong_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatPhong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatPhong>();
            }
        }
        #endregion
    }
}
