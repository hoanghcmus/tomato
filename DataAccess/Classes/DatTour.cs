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
    public class DatTour
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
        public int IDTour { get; set; }
        //Lay ket bang Tour
        public string TenTour { get; set; }
        public string GiaTour { get; set; }
        public string KhuyenMai { get; set; }
        public string ThoiGian { get; set; }
        public string PhuongTien { get; set; }
        public string KhachSan { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string LichTrinh { get; set; }
        public string HinhAnh { get; set; }
        public DatTour() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(DatTour dattour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "DatTour_Them",
                    dattour.ID, dattour.HoTen, dattour.Email, dattour.DiaChi, dattour.SDT,
                    dattour.NguoiLon, dattour.TreEm, dattour.YeuCauKhac,dattour.NgayGui,
                    dattour.TrangThai, dattour.IDTour);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(DatTour dattour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTour_Sua",
                    dattour.ID, dattour.HoTen, dattour.Email, dattour.DiaChi, dattour.SDT,
                    dattour.NguoiLon, dattour.TreEm, dattour.YeuCauKhac, dattour.NgayGui,
                    dattour.TrangThai, dattour.IDTour);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTour_SuaTrangThai", id, ConvertType.ToInt32(trangthai));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("DatTour_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatTour_Dem"));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("DatTour_DemTheoTrangThai", ConvertType.ToInt32(trangthai)));
            }
            catch
            {
                return 0;
            }
        }
        public static List<DatTour> ByDate(string startDate, string endDate)
        {
            try
            {
                return CBO.FillCollection<DatTour>(DataProvider.Instance.ExecuteReader("DatTour_ByDate", startDate, endDate));
            }
            catch (Exception)
            {
                return new List<DatTour>();
            }
        }
        public static DatTour LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<DatTour>(DataProvider.Instance.ExecuteReader("DatTour_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<DatTour> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatTour_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatTour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatTour>();
            }
        }
        public static List<DatTour> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("DatTour_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<DatTour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<DatTour>();
            }
        }
        #endregion
    }
}
