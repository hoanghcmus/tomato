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
    public class Tour
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TenTour { get; set; }
        public int GiaTour { get; set; }
        public string KhuyenMai { get; set; }
        public string ThoiGian { get; set; }
        public string PhuongTien { get; set; }
        public string KhachSan { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string LichTrinh { get; set; }
        public string HinhAnh { get; set; }
        public string ChiTiet { get; set; }
        public string NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public Boolean TrangChu { get; set; }
        public Boolean HienKhuyenMai { get; set; }
        public int IDTheLoai { get; set; }


        public string TenTour_En { get; set; }
        public string KhuyenMai_En { get; set; }
        public string PhuongTien_En { get; set; }
        public string KhachSan_En { get; set; }
        public string LichTrinh_En { get; set; }
        public string ChiTiet_En { get; set; }

        public string TenTour_Ru { get; set; }
        public string KhuyenMai_Ru { get; set; }
        public string PhuongTien_Ru { get; set; }
        public string KhachSan_Ru { get; set; }
        public string LichTrinh_Ru { get; set; }
        public string ChiTiet_Ru { get; set; }


        public Tour() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(Tour tour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "Tour_Them",
                    tour.ID, tour.TenTour, tour.GiaTour, tour.KhuyenMai, tour.ThoiGian, tour.PhuongTien,
                    tour.KhachSan, tour.NgayKhoiHanh, tour.LichTrinh, tour.HinhAnh, tour.ChiTiet,
                    tour.NgayTao, tour.NguoiTao, tour.TrangChu, tour.HienKhuyenMai, tour.IDTheLoai, tour.TenTour_En, tour.KhuyenMai_En, tour.PhuongTien_En, tour.KhachSan_En, tour.LichTrinh_En, tour.ChiTiet_En, tour.TenTour_Ru, tour.KhuyenMai_Ru, tour.PhuongTien_Ru, tour.KhachSan_Ru, tour.LichTrinh_Ru, tour.ChiTiet_Ru);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(Tour tour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("Tour_Sua",
                                        tour.ID, tour.TenTour, tour.GiaTour, tour.KhuyenMai, tour.ThoiGian, tour.PhuongTien,
                    tour.KhachSan, tour.NgayKhoiHanh, tour.LichTrinh, tour.HinhAnh, tour.ChiTiet,
                    tour.NgayTao, tour.NguoiTao, tour.TrangChu, tour.HienKhuyenMai, tour.IDTheLoai, tour.TenTour_En, tour.KhuyenMai_En, tour.PhuongTien_En, tour.KhachSan_En, tour.LichTrinh_En, tour.ChiTiet_En, tour.TenTour_Ru, tour.KhuyenMai_Ru, tour.PhuongTien_Ru, tour.KhachSan_Ru, tour.LichTrinh_Ru, tour.ChiTiet_Ru);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaNgan(Tour tour)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("Tour_Sua",
                    tour.ID, tour.TenTour, tour.GiaTour, tour.KhuyenMai, tour.PhuongTien,
                    tour.KhachSan, tour.LichTrinh);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTrangChu(int id, bool trangChu)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("Tour_SuaTrangChu", id, trangChu);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("Tour_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("Tour_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTheLoai(string idTheLoai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("Tour_DemTheoTheLoai", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            {
                return 0;
            }
        }
        public static Tour LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<Tour> LayTatCaKoPhanTrang(string theloai)
        {
            try
            {
                return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoTheLoaiKoPhanTrang", ConvertType.ToInt32(theloai)));
            }
            catch
            { return null; }
        }
        public static List<Tour> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("Tour_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Tour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Tour>();
            }
        }
        public static List<Tour> LayTheoTheLoai(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("Tour_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Tour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Tour>();
            }
        }

        public static List<Tour> Tour_LayTheoTheLoai_NoPaggin(string idTheLoai)
        {
            IDataReader reader = null;
            try
            {
                reader = DataProvider.Instance.ExecuteReader("Tour_LayTheoTheLoai_NoPaggin", Convert.ToInt32(idTheLoai));
                reader.Read();
                int howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)6);
                reader.NextResult();
                return CBO.FillCollection<Tour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                return new List<Tour>();
            }
        }


        public static List<Tour> TimKiem(string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("Tour_TimKiem", sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Tour>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Tour>();
            }
        }
        public static List<Tour> Tour_LayTheoTrangChuAndTop(string top)
        {
            try
            {
                return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoTrangChuAndTop", ConvertType.ToInt32(top)));
            }
            catch
            { return null; }
        }
        public static List<Tour> Tour_LayTheoKhuyenMaiAndTop(string top)
        {
            try
            {
                return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoKhuyenMaiAndTop", ConvertType.ToInt32(top)));
            }
            catch
            { return null; }
        }

        public static List<Tour> Tour_LayTheoParentAndTop(string parent, string top)
        {
            try
            {
                return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoParentAndTop", ConvertType.ToInt32(parent), ConvertType.ToInt32(top)));
            }
            catch
            { return null; }
        }
        public static List<Tour> Tour_LayTheoTheLoaiAndTop(string theloai, string top)
        {
            try
            {
                return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_LayTheoTheLoaiAndTop", ConvertType.ToInt32(theloai), ConvertType.ToInt32(top)));
            }
            catch
            { return null; }
        }
        #endregion
    }
}
