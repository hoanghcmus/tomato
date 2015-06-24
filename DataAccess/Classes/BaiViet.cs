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
    public class BaiViet
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TieuDe_Vn { get; set; }
        public string TieuDe_En { get; set; }
        public string TieuDe_Ru { get; set; }
        public string TieuDe_Cn { get; set; }
        public string HinhAnh { get; set; }
        public string TomTat_Vn { get; set; }
        public string TomTat_En { get; set; }
        public string TomTat_Ru { get; set; }
        public string TomTat_Cn { get; set; }
        public string ChiTiet_Vn { get; set; }
        public string ChiTiet_En { get; set; }
        public string ChiTiet_Ru { get; set; }
        public string ChiTiet_Cn { get; set; }
        public string NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public string LinkDown { get; set; }
        public int LuotXem { get; set; }
        public int TrangThai { get; set; }
        public Boolean TrangChu { get; set; }
        public int IDTheLoai { get; set; }
        //Anh xa tu bang the loai

        public string TenTheLoai_Vn { get; set; }
        public string TenTheLoai_En { get; set; }
        public string TenTheLoai_Ru { get; set; }
        public string TenTheLoai_Cn { get; set; }
        public int IDParent { get; set; }
        public BaiViet() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(BaiViet noiDung)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "BaiViet_Them", noiDung.ID, noiDung.TieuDe_Vn, noiDung.TieuDe_En, noiDung.TieuDe_Ru, noiDung.HinhAnh, noiDung.TomTat_Vn, noiDung.TomTat_En, noiDung.TomTat_Ru, noiDung.ChiTiet_Vn, noiDung.ChiTiet_En, noiDung.ChiTiet_Ru, noiDung.NgayTao, noiDung.NguoiTao, noiDung.LuotXem, noiDung.TrangThai, noiDung.IDTheLoai, noiDung.TieuDe_Cn, noiDung.TomTat_Cn, noiDung.ChiTiet_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(BaiViet noiDung)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("BaiViet_Sua", noiDung.ID, noiDung.TieuDe_Vn, noiDung.TieuDe_En, noiDung.TieuDe_Ru, noiDung.HinhAnh, noiDung.TomTat_Vn, noiDung.TomTat_En, noiDung.TomTat_Ru, noiDung.ChiTiet_Vn, noiDung.ChiTiet_En, noiDung.ChiTiet_Ru, noiDung.NgayCapNhat, noiDung.NguoiCapNhat, noiDung.LuotXem, noiDung.TrangThai, noiDung.IDTheLoai, noiDung.TieuDe_Cn, noiDung.TomTat_Cn, noiDung.ChiTiet_Cn);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaLuotXem(string id, string luotXem)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("BaiViet_SuaLuotXem", Convert.ToInt32(id), Convert.ToInt32(luotXem));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("BaiViet_SuaTrangThai", Convert.ToInt32(id), Convert.ToInt32(trangThai));
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
                object rs = DataProvider.Instance.ExecuteNonQuery("BaiViet_SuaTrangChu", id, trangChu);
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
                object rs = DataProvider.Instance.ExecuteNonQuery("BaiViet_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("BaiViet_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTrangThai(string trangThai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("BaiViet_DemTheoTrangThai", ConvertType.ToInt32(trangThai)));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoModule(string module)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("BaiViet_DemTheoModule", ConvertType.ToInt32(module)));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("BaiViet_DemTheoTheLoai", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            {
                return 0;
            }
        }
        public static BaiViet LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static BaiViet LayTheoIDTheLoai(string id)
        {
            try
            {
                return CBO.FillObject<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoai", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<BaiViet> LayTheoIDTheLoai_List(string id)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoai", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<BaiViet> LayTheoTheLoaiKoPhanTrang(string theloai)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTheLoaiKoPhanTrang", ConvertType.ToInt32(theloai)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayLienQuanIDParentTop10(string idParent, string id)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayLienQuanIDParentTop10", ConvertType.ToInt32(idParent), ConvertType.ToInt32(id)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayLienQuanIDTheLoaiTop10(string idtheloai, string id)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayLienQuanIDTheLoaiTop10", ConvertType.ToInt32(idtheloai), ConvertType.ToInt32(id)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTheoIDParentTop6(string idParent)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDParentTop6", ConvertType.ToInt32(idParent)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTheoIDParentTop8(string idParent)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDParentTop8", ConvertType.ToInt32(idParent)));
            }
            catch
            { return null; }
        }

        public static List<BaiViet> LayTheoIDTheLoaiTop2(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoaiTop2", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTheoIDTheLoaiTop4(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoaiTop4", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTheoIDTheLoaiTop6(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoaiTop6", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTheoIDTheLoaiTop10(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<BaiViet>(DataProvider.Instance.ExecuteReader("BaiViet_LayTheoIDTheLoaiTop10", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<BaiViet> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoParent(string parent, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoParent", ConvertType.ToInt32(parent), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoTheLoai(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoTheLoai_4item(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize4;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize4);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoTheLoai20Page(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoModule(string module, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoModule", ConvertType.ToInt32(module), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoTrangThaiVaModule(string module, string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTrangThaiVaModule", ConvertType.ToInt32(module), ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoLoaiMenuVaTrangThai(string trangThai, string loaiMenu, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoLoaiMenuVaTrangThai", ConvertType.ToInt32(trangThai), ConvertType.ToInt32(loaiMenu), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> LayTheoIDTheLoai(string theLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_LayTheoTheLoai", ConvertType.ToInt32(theLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> TimKiem(string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_TimKiem", sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> TimTheoModule(string module, string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_TimTheoModule", ConvertType.ToInt32(module), sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        public static List<BaiViet> TimTheoTheLoai(string sreach, string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("BaiViet_TimTheoTheLoai", sreach, ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<BaiViet>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<BaiViet>();
            }
        }
        #endregion
    }
}
