using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataAccess.Classes
{
    public class ThongKeTruyCap
    {
        #region khai bao cac thuoc tinh va truy xuat thu tuc
        public string Ten { get; set; }
        public int LuotTruyCap { get; set; }
        public ThongKeTruyCap() { }
        public static ThongKeTruyCap Start()
        {
            try
            {
                return CBO.FillObject<ThongKeTruyCap>(DataProvider.Instance.ExecuteReader("ThongKeTruyCap_Start"));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
