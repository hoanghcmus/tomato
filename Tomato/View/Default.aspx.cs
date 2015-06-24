using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using DataAccess.Help;
using DataAccess.StringUtil;
using MultipleLanguage;

public partial class Vn_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<BaiViet> listBV = BaiViet.LayTheoIDTheLoai_List("5");
            if (listBV != null && listBV.Count != 0)
            {
                rptListCuisine.DataSource = listBV;
                rptListCuisine.DataBind();
                if (Session["lang"].ToString().Equals("vn")) { ltrCtTitle.Text = listBV.First().TenTheLoai_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { ltrCtTitle.Text = listBV.First().TenTheLoai_En; }
                else if (Session["lang"].ToString().Equals("ru")) { ltrCtTitle.Text = listBV.First().TenTheLoai_Ru; }

            }
        }
    }



    protected string ShowCuisine(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;
        switch (column)
        {
            case "CuisineTomtat":
                if (baiviet.TomTat_Vn.Length > 100)
                {
                    if (Session["lang"].ToString().Equals("vn")) { return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 150) + "..."; }
                    else if (Session["lang"].ToString().Equals("en")) { return StringUltility.GetStringByLenght(baiviet.TomTat_En, 150) + "..."; }
                    else if (Session["lang"].ToString().Equals("ru")) { return StringUltility.GetStringByLenght(baiviet.TomTat_Ru, 150) + "..."; }
                    return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 100) + "...";
                }
                else
                {
                    if (Session["lang"].ToString().Equals("vn")) { return baiviet.TomTat_Vn; }
                    else if (Session["lang"].ToString().Equals("en")) { return baiviet.TomTat_En; }
                    else if (Session["lang"].ToString().Equals("ru")) { return baiviet.TomTat_Ru; }
                    return baiviet.TomTat_Vn + "...";
                }
            case "CuisineDuongDan":
                if (Session["lang"].ToString().Equals("vn")) { return "/vn/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html"; }
                else if (Session["lang"].ToString().Equals("en")) { return "/en/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html"; }
                else if (Session["lang"].ToString().Equals("ru")) { return "/ru/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html"; }
                return "/vn/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html";

            case "CuisineTieuDe":
                if (Session["lang"].ToString().Equals("vn")) { return baiviet.TieuDe_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { return baiviet.TieuDe_En; }
                else if (Session["lang"].ToString().Equals("ru")) { return baiviet.TieuDe_Ru; }
                return baiviet.TieuDe_Vn;

            case "CuisineTomTat":
                if (Session["lang"].ToString().Equals("vn")) { return baiviet.TomTat_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { return baiviet.TomTat_En; }
                else if (Session["lang"].ToString().Equals("ru")) { return baiviet.TomTat_Ru; }
                return baiviet.TomTat_Vn;

            default: return "";
        }
    }

}