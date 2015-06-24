using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;
using DataAccess.StringUtil;
using MultipleLanguage;

public partial class En_ArticleByCatgory : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        string IDTheLoai = Request.QueryString["MenuItemID"] ?? "0";
        List<BaiViet> listBV = BaiViet.LayTheoIDTheLoai_List(IDTheLoai);

        if (listBV != null && listBV.Count != 0)
        {
            rptArticleList.DataSource = listBV;
            rptArticleList.DataBind();

            if (Session["lang"].ToString().Equals("vn")) { ltrCtTitle.Text = listBV.First().TenTheLoai_Vn; }
            else if (Session["lang"].ToString().Equals("en")) { ltrCtTitle.Text = listBV.First().TenTheLoai_En; }
            else if (Session["lang"].ToString().Equals("ru")) { ltrCtTitle.Text = listBV.First().TenTheLoai_Ru; }

        }
    }

    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }

    protected string ShowArticleCat(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;

        switch (column)
        {
            case "laytomtat":
                if (baiviet.TomTat_Vn.Length > 100)
                {
                    if (Session["lang"].ToString().Equals("vn")) { return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 100) + "..."; }
                    else if (Session["lang"].ToString().Equals("en")) { return StringUltility.GetStringByLenght(baiviet.TomTat_En, 100) + "..."; }
                    else if (Session["lang"].ToString().Equals("ru")) { return StringUltility.GetStringByLenght(baiviet.TomTat_Ru, 100) + "..."; }
                    return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 100) + "...";
                }
                else
                {
                    if (Session["lang"].ToString().Equals("vn")) { return baiviet.TomTat_Vn; }
                    else if (Session["lang"].ToString().Equals("en")) { return baiviet.TomTat_En; }
                    else if (Session["lang"].ToString().Equals("ru")) { return baiviet.TomTat_Ru; }
                    return baiviet.TomTat_Vn + "...";
                }

            case "ArticleCatDuongDan":
                if (Session["lang"].ToString().Equals("vn"))
                {
                    return "/vn/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html";
                }
                else if (Session["lang"].ToString().Equals("en"))
                {
                    return "/en/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html";
                }
                else if (Session["lang"].ToString().Equals("ru"))
                {
                    return "/ru/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html";
                }

                return "/vn/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html"; ;

            case "ArticleCatTieuDe":
                if (Session["lang"].ToString().Equals("vn")) { return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); }
                else if (Session["lang"].ToString().Equals("en")) { return HttpUtility.HtmlEncode(Eval("TieuDe_En").ToString()); }
                else if (Session["lang"].ToString().Equals("ru")) { return HttpUtility.HtmlEncode(Eval("TieuDe_Ru").ToString()); }

                return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); ;

            default: return "";
        }
    }
}