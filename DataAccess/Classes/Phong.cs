using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;
using DataAccess.Connect;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public partial class Phong
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public int MenuID { get; set; }
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
        public string Image { get; set; }
        public bool? PromoFront { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
        public string TenTheLoai_Vn { get; set; }
        public string TenTheLoai_En { get; set; }
        public string TenTheLoai_Ru { get; set; }
        public string Amount { get; set; }
        public int AdultAmount { get; set; }
        public int ChildAmount { get; set; }
        public Phong() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static bool Add(Phong product)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "Phong_Add",
                    product.ID, product.MenuID, product.Name_Vn, product.Description_Vn, product.Detail_Vn, product.Name_En, product.Description_En, product.Detail_En,
                    product.Name_Ru, product.Description_Ru, product.Detail_Ru,
                    product.Price, product.Thumbnail, product.Image, product.PromoFront, product.Amount, product.AdultAmount, product.ChildAmount);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Update(Phong product)
        {
            try
            {
                int rs = DataProvider.Instance.ExecuteNonQuery("Phong_Update",
                    product.ID, product.MenuID, product.Name_Vn, product.Description_Vn, product.Detail_Vn, product.Name_En, product.Description_En, product.Detail_En,
                    product.Name_Ru, product.Description_Ru, product.Detail_Ru,
                    product.Price, product.Thumbnail, product.Image, product.PromoFront, product.Amount, product.AdultAmount, product.ChildAmount);
                return rs > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdatePromo(string productID, bool promo)
        {
            try
            {
                int rs = DataProvider.Instance.ExecuteNonQuery("Phong_UpdatePromo", Convert.ToInt32(productID), promo);
                return rs > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(string productID)
        {
            try
            {
                int rs = DataProvider.Instance.ExecuteNonQuery("Phong_Delete", Convert.ToInt32(productID));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("Phong_Count"));
            }
            catch
            {
                return 0;
            }
        }

        public static List<Phong> Phong_GetIdAll()
        {
            try
            {
                return CBO.FillCollection<Phong>(DataProvider.Instance.ExecuteReader("Phong_GetIdAll"));
            }
            catch
            {
                return null;
            }
        }

        public static int CountOnPromo()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("Phong_CountOnPromo"));
            }
            catch
            {
                return 0;
            }
        }
        public static Phong Single(string productId)
        {
            try
            {
                return CBO.FillObject<Phong>(DataProvider.Instance.ExecuteReader("Phong_Single",
                                                Convert.ToInt32(productId)));
            }
            catch
            {
                return null;
            }
        }
        public static List<Phong> LayTheoIDTheLoaiTop8(string menuID)
        {
            try
            {
                return CBO.FillCollection<Phong>(DataProvider.Instance.ExecuteReader("Phong_LayTheoIDTheLoaiTop8", ConvertType.ToInt32(menuID)));
            }
            catch
            { return null; }
        }

        public static List<Phong> OnPromoTop3()
        {
            try
            {
                return CBO.FillCollection<Phong>(DataProvider.Instance.ExecuteReader("Phong_OnPromoTop3"));
            }
            catch
            { return null; }
        }
        public static List<Phong> OnPromoTop10()
        {
            try
            {
                return CBO.FillCollection<Phong>(DataProvider.Instance.ExecuteReader("Phong_OnPromoTop10"));
            }
            catch
            { return null; }
        }
        public static List<Phong> Search(string searchString, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("Phong_Search", searchString, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Phong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Phong>();
            }
        }
        public static List<Phong> SearchInMenu(string menuID, string searchString, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("Phong_Search", menuID, searchString, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Phong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Phong>();
            }
        }
        public static List<Phong> InMenu(string menuId, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("Phong_InMenu", Convert.ToInt32(menuId),
                    GlobalConfiguration.DescriptionLength, Convert.ToInt32(page), pageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Phong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false) reader.Close();
                howManyPages = 0; return new List<Phong>();
            }
        }
        public static List<Phong> OnPromo(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize0;
                reader = DataProvider.Instance.ExecuteReader("Phong_OnPromo", GlobalConfiguration.DescriptionLength,
                                                            page, GlobalConfiguration.PageSize0);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<Phong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Phong>();
            }
        }
        public static List<Phong> Paging(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("Phong_Paging", page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);

                reader.NextResult();
                return CBO.FillCollection<Phong>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<Phong>();
            }
        }
        #endregion
    }
}
