using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataAccess.Classes
{
    public class NhomNguoiDung
    {
        #region khai bao cac thuoc tinh anh xa
        public string IDNhom { get; set; }
        public string TenNhom { get; set; }
        public int QuyenHan { get; set; }
        public string NgayTao { get; set; }
        public string Mota { get; set; }
        public NhomNguoiDung() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int Dem()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("NhomNguoiDung_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static List<NhomNguoiDung> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<NhomNguoiDung>(DataProvider.Instance.ExecuteReader("NhomNguoiDung_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
