using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataAccess.Classes
{
    public class Module
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public Module() { }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static List<Module> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<Module>(DataProvider.Instance.ExecuteReader("Module_LayTatCa"));
            }
            catch
            { return null; }
        }
        #endregion
    }
}
