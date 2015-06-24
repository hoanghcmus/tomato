using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataAccess.Classes
{
    public class LoaiMenu
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public LoaiMenu() { }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static List<LoaiMenu> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<LoaiMenu>(DataProvider.Instance.ExecuteReader("LoaiMenu_LayTatCa"));
            }
            catch
            { return null; }
        }
        #endregion
    }
}
