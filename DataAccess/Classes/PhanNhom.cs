using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;

namespace DataAccess.Classes
{
    public class PhanNhom
    {
        #region khai bao cac thuoc tinh anh xa
        public int IDPhanNhom { get; set; }
        public int IDNguoiDung { get; set; }
        public string IDNhom { get; set; }
        public string TenNhom { get; set; }
        public string MoTa { get; set; }
        public int QuyenHan { get; set; }
        public string TenDangNhap { get; set; }
        public string NgayTao { get; set; }
        public PhanNhom() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(PhanNhom pnnd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@IDPhanNhom", "PhanNhom_Them",
                    pnnd.IDPhanNhom, pnnd.IDNguoiDung, pnnd.IDNhom, pnnd.NgayTao);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool Xoa(string maPhanNhom)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("PhanNhom_Xoa", Convert.ToInt32(maPhanNhom));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("PhanNhom_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoNhom(string nhom)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("PhanNhom_DemTheoNhom",nhom));
            }
            catch
            {
                return 0;
            }
        }
        public static List<PhanNhom> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<PhanNhom>(DataProvider.Instance.ExecuteReader("PhanNhom_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }
        public static List<PhanNhom> LayTheoMaNguoiDung(string idNguoiDung)
        {
            try
            {
                return CBO.FillCollection<PhanNhom>(DataProvider.Instance.ExecuteReader("PhanNhom_LayTheoIDNguoiDung", ConvertType.ToInt32(idNguoiDung)));
            }
            catch
            {
                return null;
            }
        }
        public static List<PhanNhom> LayTheoMaNhom(string idNhom)
        {
            try
            {
                return CBO.FillCollection<PhanNhom>(DataProvider.Instance.ExecuteReader("PhanNhom_LayTheoIDNhom", idNhom));
            }
            catch
            {
                return null;
            }
        }
        public static List<PhanNhom> TimKiem(string sreach)
        {
            try
            {
                return CBO.FillCollection<PhanNhom>(DataProvider.Instance.ExecuteReader("PhanNhom_TimKiem", sreach));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
