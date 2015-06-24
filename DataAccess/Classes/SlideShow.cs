using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataAccess.Classes
{
    public class SlideShow
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TieuDe_Vn { get; set; }
        public string TieuDe_En { get; set; }
        public string TieuDe_Ru { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int ViTri { get; set; }
        public int HienThi { get; set; }
        public SlideShow() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(SlideShow slideshow)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "SlideShow_Them",
                    slideshow.ID, slideshow.TieuDe_Vn, slideshow.TieuDe_En, slideshow.TieuDe_Ru, slideshow.HinhAnh, slideshow.MoTa, slideshow.ViTri, slideshow.HienThi);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool Sua(SlideShow slideshow)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("SlideShow_Sua",
                    slideshow.ID, slideshow.TieuDe_Vn, slideshow.TieuDe_En, slideshow.TieuDe_Ru, slideshow.HinhAnh, slideshow.MoTa, slideshow.ViTri, slideshow.HienThi);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("SlideShow_Xoa", Convert.ToInt32(id));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static SlideShow LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<SlideShow>(DataProvider.Instance.ExecuteReader("SlideShow_LayTheoID", Convert.ToInt32(id)));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SlideShow_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static List<SlideShow> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<SlideShow>(DataProvider.Instance.ExecuteReader("SlideShow_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }
        public static List<SlideShow> LayTheoHienThi(int hienthi)
        {
            try
            {
                return CBO.FillCollection<SlideShow>(DataProvider.Instance.ExecuteReader("SlideShow_LayTheoHienThi",hienthi));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
