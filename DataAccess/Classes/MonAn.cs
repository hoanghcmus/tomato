using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Connect;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public partial class MonAn
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TenMon_Vn { get; set; }
        public string TenMon_En { get; set; }
        public string TenMon_Ru { get; set; }

        public string MoTa_Vn { get; set; }
        public string MoTa_En { get; set; }
        public string MoTa_Ru { get; set; }

        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; }

        public string ChiTiet_Vn { get; set; }
        public string ChiTiet_En { get; set; }
        public string ChiTiet_Ru { get; set; }

        public int MenuID { get; set; }

        public string TenTheLoai_Vn { get; set; }
        public string TenTheLoai_En { get; set; }
        public string TenTheLoai_Ru { get; set; }

        public MonAn() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static bool Add(MonAn monan)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "MonAn_Add",
                   monan.ID, monan.TenMon_Vn, monan.TenMon_En, monan.TenMon_Ru, monan.MoTa_Vn, monan.MoTa_En, monan.MoTa_Ru, monan.AnhDaiDien, monan.Gia, monan.HinhAnh, monan.ChiTiet_Vn, monan.ChiTiet_En, monan.ChiTiet_Ru, monan.MenuID);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(MonAn monan)
        {
            try
            {
                int rs = DataProvider.Instance.ExecuteNonQuery("MonAn_Update",
                   monan.ID, monan.TenMon_Vn, monan.TenMon_En, monan.TenMon_Ru, monan.MoTa_Vn, monan.MoTa_En, monan.MoTa_Ru, monan.AnhDaiDien, monan.Gia, monan.HinhAnh, monan.ChiTiet_Vn, monan.ChiTiet_En, monan.ChiTiet_Ru, monan.MenuID);
                return rs > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string monanID)
        {
            try
            {
                int rs = DataProvider.Instance.ExecuteNonQuery("MonAn_Delete", Convert.ToInt32(monanID));
                return rs > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int Count()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("MonAn_Count"));
            }
            catch
            {
                return 0;
            }
        }

        public static List<MonAn> MonAn_GetIdAll()
        {
            try
            {
                return CBO.FillCollection<MonAn>(DataProvider.Instance.ExecuteReader("MonAn_GetIdAll"));
            }
            catch
            {
                return null;
            }
        }

        public static List<MonAn> MonAn_LayTheoIDTheLoai(int IDTheLoai)
        {
            try
            {
                return CBO.FillCollection<MonAn>(DataProvider.Instance.ExecuteReader("MonAn_LayTheoIDTheLoai", IDTheLoai));
            }
            catch
            {
                return null;
            }
        }

        public static MonAn Single(string monanId)
        {
            try
            {
                return CBO.FillObject<MonAn>(DataProvider.Instance.ExecuteReader("MonAn_Single",
                                                Convert.ToInt32(monanId)));
            }
            catch
            {
                return null;
            }
        }
        public static List<MonAn> LayTheoIDTheLoaiTop8(string menuID)
        {
            try
            {
                return CBO.FillCollection<MonAn>(DataProvider.Instance.ExecuteReader("MonAn_LayTheoIDTheLoaiTop8", ConvertType.ToInt32(menuID)));
            }
            catch
            { return null; }
        }

        public static List<MonAn> LayTheoIDTheLoaiTopN(string menuID)
        {
            try
            {
                return CBO.FillCollection<MonAn>(DataProvider.Instance.ExecuteReader("MonAn_LayTheoIDTheLoaiTopN", ConvertType.ToInt32(menuID)));
            }
            catch
            { return null; }
        }


        public static List<MonAn> Search(string searchString, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("MonAn_Search", searchString, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<MonAn>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<MonAn>();
            }
        }

        public static List<MonAn> SearchInMenu(string menuID, string searchString, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("MonAn_Search", menuID, searchString, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<MonAn>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<MonAn>();
            }
        }

        public static List<MonAn> InMenu(string menuId, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("MonAn_InMenu", Convert.ToInt32(menuId),
                    GlobalConfiguration.DescriptionLength, Convert.ToInt32(page), pageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<MonAn>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false) reader.Close();
                howManyPages = 0; return new List<MonAn>();
            }
        }


        public static List<MonAn> Paging(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("MonAn_Paging", page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);

                reader.NextResult();
                return CBO.FillCollection<MonAn>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<MonAn>();
            }
        }
        #endregion
    }
}
