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
    public class ImageAndClips
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string Ten_Vn { get; set; }
        public string Ten_En { get; set; }
        public string Ten_Cn { get; set; }
        public string Ten_Ru { get; set; }
        public string NgayTao { get; set; }
        public string MoTa_Vn { get; set; }
        public string MoTa_En { get; set; }
        public string MoTa_Ru { get; set; }
        public string MoTa_Cn { get; set; }
        public int LuotXem { get; set; }
        public string HinhAnh { get; set; }
        public string ImgOrClip { get; set; }
        public int IDTheLoai { get; set; }
        public ImageAndClips() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(ImageAndClips imgorclip)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "ImageAndClips_Them",
                    imgorclip.ID, imgorclip.Ten_Vn, imgorclip.Ten_En, imgorclip.Ten_Ru, imgorclip.NgayTao, imgorclip.MoTa_Vn, imgorclip.MoTa_En, imgorclip.MoTa_Ru, imgorclip.LuotXem, imgorclip.HinhAnh, imgorclip.ImgOrClip, imgorclip.IDTheLoai, imgorclip.Ten_Cn, imgorclip.MoTa_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(ImageAndClips imgorclip)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("ImageAndClips_Sua",
                    imgorclip.ID, imgorclip.Ten_Vn, imgorclip.Ten_En, imgorclip.Ten_Ru, imgorclip.NgayTao, imgorclip.MoTa_Vn, imgorclip.MoTa_En, imgorclip.MoTa_Ru, imgorclip.LuotXem, imgorclip.HinhAnh, imgorclip.ImgOrClip, imgorclip.IDTheLoai, imgorclip.Ten_Cn, imgorclip.MoTa_Cn);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaLuotXem(int id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("ImageAndClips_SuaLuotXem", id);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("ImageAndClips_Xoa", Convert.ToInt32(id));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int DemTheoTheLoai(string theloai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("ImageAndClips_DemTheLoai", ConvertType.ToInt32(theloai)));
            }
            catch
            {
                return 0;
            }
        }
        public static ImageAndClips ImageAndClipsTop1(string idTheLoai)
        {
            try
            {
                return CBO.FillObject<ImageAndClips>(DataProvider.Instance.ExecuteReader("ImageAndClips_Top1", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            {
                return null;
            }
        }
        public static ImageAndClips LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<ImageAndClips>(DataProvider.Instance.ExecuteReader("ImageAndClips_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<ImageAndClips> ImageAndClipsTop4(string idTheLoai)
        {
            try
            {
                return CBO.FillCollection<ImageAndClips>(DataProvider.Instance.ExecuteReader("ImageAndClips_Top4", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            { return null; }
        }
        public static List<ImageAndClips> LayTheoTheLoai(string theLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("ImageAndClips_LayTheoTheLoai", ConvertType.ToInt32(theLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<ImageAndClips>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<ImageAndClips>();
            }
        }
        public static List<ImageAndClips> TimKiem(string theLoai, string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("ImageAndClips_TimKiem", ConvertType.ToInt32(theLoai), sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<ImageAndClips>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<ImageAndClips>();
            }
        }
        #endregion
    }
}
