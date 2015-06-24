using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public class TheLoai
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TieuDe_Vn { get; set; }
        public string TieuDe_En { get; set; }
        public string TieuDe_Ru { get; set; }
        public string TieuDe_Cn { get; set; }
        public string MoTa_Vn { get; set; }
        public string MoTa_En { get; set; }
        public string MoTa_Cn { get; set; }
        public string MoTa_Ru { get; set; }
        public string HinhAnh { get; set; }
        public string DuongDan_Vn { get; set; }
        public string DuongDan_En { get; set; }
        public string DuongDan_Ru { get; set; }
        public string DuongDan_Cn { get; set; }
        public int IDParent { get; set; }
        public int IDLoaiMenu { get; set; }
        public int IDModule { get; set; }
        public int ViTri { get; set; }
        public Boolean Footer { get; set; }
        //Anh xa bang ngoai
        public string TenLoaiMenu { get; set; }
        public string TenLoaiModule { get; set; }
        public TheLoai() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int ThemYesIDParent(TheLoai theLoai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "TheLoai_ThemYesIDParent",
                    theLoai.ID, theLoai.TieuDe_Vn, theLoai.TieuDe_En, theLoai.TieuDe_Ru, theLoai.MoTa_Vn, theLoai.MoTa_En, theLoai.MoTa_Ru
                    , theLoai.HinhAnh, theLoai.IDParent, theLoai.IDLoaiMenu, theLoai.IDModule, theLoai.DuongDan_Vn, theLoai.DuongDan_En, theLoai.DuongDan_Ru, theLoai.ViTri, theLoai.Footer, theLoai.TieuDe_Cn, theLoai.MoTa_Cn, theLoai.DuongDan_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            { return 0; }
        }
        public static int ThemNoIDParent(TheLoai theLoai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "TheLoai_ThemNoIDParent",
                    theLoai.ID, theLoai.TieuDe_Vn, theLoai.TieuDe_En, theLoai.TieuDe_Ru
                    , theLoai.MoTa_Vn, theLoai.MoTa_En, theLoai.MoTa_Ru, theLoai.HinhAnh
                    , theLoai.IDLoaiMenu, theLoai.IDModule, theLoai.DuongDan_Vn, theLoai.DuongDan_En
                    , theLoai.DuongDan_Ru, theLoai.ViTri, theLoai.Footer, theLoai.TieuDe_Cn, theLoai.MoTa_Cn, theLoai.DuongDan_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            { return 0; }
        }
        public static int Xoa(string id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TheLoai_Xoa", Convert.ToInt32(id));
                return Convert.ToInt32(rs);
            }
            catch
            { return 0; }
        }
        public static int SuaNoParent(TheLoai theLoai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TheLoai_SuaNoParent", ConvertType.ToInt32(theLoai.ID)
                    , theLoai.TieuDe_Vn, theLoai.TieuDe_En, theLoai.TieuDe_Ru, theLoai.MoTa_Vn
                    , theLoai.MoTa_En, theLoai.MoTa_Ru, theLoai.HinhAnh, theLoai.IDLoaiMenu
                    , theLoai.IDModule, theLoai.DuongDan_Vn, theLoai.DuongDan_En, theLoai.DuongDan_Ru
                    , theLoai.ViTri, theLoai.Footer, theLoai.TieuDe_Cn, theLoai.MoTa_Cn, theLoai.DuongDan_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            { return 0; }
        }
        public static int SuaYesParent(TheLoai theLoai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TheLoai_SuaYesParent", ConvertType.ToInt32(theLoai.ID)
                    , theLoai.TieuDe_Vn, theLoai.TieuDe_En, theLoai.TieuDe_Ru, theLoai.MoTa_Vn
                    , theLoai.MoTa_En, theLoai.MoTa_Ru, theLoai.HinhAnh, theLoai.IDParent
                    , theLoai.IDLoaiMenu, theLoai.IDModule, theLoai.DuongDan_Vn, theLoai.DuongDan_En, theLoai.DuongDan_Ru
                    , theLoai.ViTri, theLoai.Footer, theLoai.TieuDe_Cn, theLoai.MoTa_Cn, theLoai.DuongDan_Cn);
                return Convert.ToInt32(rs);
            }
            catch
            { return 0; }
        }
        public static bool SuaFooter(int id, bool footer)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TheLoai_SuaFooter", id, footer);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int DemTheoLoaiMenu(string loaiMenu)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("TheLoai_DemTheoLoaiMenu", ConvertType.ToInt32(loaiMenu)));
            }
            catch
            {
                return 0;
            }
        }
        public static TheLoai LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<TheLoai> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTatCa"));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayMenuFooter()
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayMenuFooter"));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoModule(string idLoaiModule)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoModule", ConvertType.ToInt32(idLoaiModule)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoModuleVaParentNoNull(string idLoaiMenu)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoModuleVaParentNoNull", ConvertType.ToInt32(idLoaiMenu)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoModuleVaParentIsNull(string idLoaiMenu)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoModuleVaParentIsNull", ConvertType.ToInt32(idLoaiMenu)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoIDParent(string idParent)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoIDParent", ConvertType.ToInt32(idParent)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoLoaiMenu(string idLoaiMenu)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoLoaiMenu", ConvertType.ToInt32(idLoaiMenu)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoLoaiMenuVaParentNoNull(string idLoaiMenu)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoLoaiMenuVaParentNoNull", ConvertType.ToInt32(idLoaiMenu)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> LayTheoLoaiMenuVaParentIsNull(string idLoaiMenu)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_LayTheoLoaiMenuVaParentIsNull", ConvertType.ToInt32(idLoaiMenu)));
            }
            catch
            { return null; }
        }
        public static List<TheLoai> TheLoai_GetByCategoryAndParentID(string idLoaiMenu, int parentID)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("TheLoai_GetByCategoryAndParentID", ConvertType.ToInt32(idLoaiMenu), parentID));
            }
            catch
            { return null; }
        }

        public static List<TheLoai> COUNT_ON_THELOAI(int menuItemID)
        {
            try
            {
                return CBO.FillCollection<TheLoai>(DataProvider.Instance.ExecuteReader("COUNT_ON_THELOAI", menuItemID));
            }
            catch
            { return null; }
        }
        #endregion
    }
}
