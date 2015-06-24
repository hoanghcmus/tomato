using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public class HoTro
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string Ten_Vn { get; set; }
        public string Ten_En { get; set; }
        public string Ten_Ru { get; set; }
        public string Ten_Cn { get; set; }
        public string Khac { get; set; }
        public string SDT { get; set; }
        public HoTro() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static bool Them(HoTro hoTro)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "HoTro_Them",
                    hoTro.ID, hoTro.Ten_Vn, hoTro.Ten_En, hoTro.Ten_Ru, hoTro.SDT, hoTro.Khac, hoTro.Ten_Cn);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            { return false; }
        }
        public static bool Xoa(string id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("HoTro_Xoa", Convert.ToInt32(id));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            { return false; }
        }
        public static bool Sua(HoTro hoTro)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("HoTro_Sua",
                    hoTro.ID, hoTro.Ten_Vn, hoTro.Ten_En, hoTro.Ten_Ru, hoTro.SDT, hoTro.Khac, hoTro.Ten_Cn);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            { return false; }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int Dem()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("HoTro_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static List<HoTro> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<HoTro>(DataProvider.Instance.ExecuteReader("HoTro_LayTatCa"));
            }
            catch
            { return null; }
        }
        #endregion
    }
}
