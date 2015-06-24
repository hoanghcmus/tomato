using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_Admin : System.Web.UI.Page
{
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "3")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            PopulateControls();
        }

    }
    private void PopulateControls()
    {
        //if (KiemTraSession() == 1)
        //{
        //    UC_ThongKeNguoiDung3.Visible = true;
        //}

        lblienHe.Text = LienHe.Dem().ToString();
        lbbaiViet.Text = BaiViet.DemTheoModule("1").ToString();
        lbdt.Text = DatTiec.DemTheoTrangThai("0").ToString();
        lbma.Text = MonAn.Count().ToString();
        //lbshop.Text = DatPhong.DemTheoTrangThai("0").ToString();
        //lbTour.Text = DatTour.DemTheoTrangThai("0").ToString();
        //lbalbum.Text = ImageAndClips.DemTheoTheLoai("14").ToString();
    }
}