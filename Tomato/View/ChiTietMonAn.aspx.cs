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

public partial class View_ChiTietMonAn : BasePage
{
    public string getPid()
    {
        return Request.QueryString["ID"] ?? "0";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string productId = getPid();
            var pr = DataAccess.Classes.MonAn.Single(productId);
            if (pr != null)
            {
                PopulateControls(pr);
            }
        }
    }
    protected void PopulateControls(MonAn pr)
    {
        ltrPrice.Text = showMoney(pr.Gia).ToString();


        if (Session["lang"].ToString().Equals("vn"))
        {
            ltrTenSanPham.Text = pr.TenMon_Vn;
            ltrCtTitle.Text = pr.TenMon_Vn;
            ltrMoTa.Text = pr.MoTa_Vn;
            ltrChiTietSanPham.Text = pr.ChiTiet_Vn;
            figureLarge.Title = pr.TenMon_Vn;
        }
        else if (Session["lang"].ToString().Equals("en"))
        {
            ltrTenSanPham.Text = pr.TenMon_En;
            ltrCtTitle.Text = pr.TenMon_En;
            ltrMoTa.Text = pr.MoTa_En;
            ltrChiTietSanPham.Text = pr.ChiTiet_En;
            figureLarge.Title = pr.TenMon_En;
        }
        else if (Session["lang"].ToString().Equals("ru"))
        {
            ltrTenSanPham.Text = pr.TenMon_Ru;
            ltrCtTitle.Text = pr.TenMon_Ru;
            ltrMoTa.Text = pr.MoTa_Ru;
            ltrChiTietSanPham.Text = pr.ChiTiet_Ru;
            figureLarge.Title = pr.TenMon_Ru;
        }

        List<Img> album = new List<Img>();
        int idimg = 0;
        string listimg = pr.HinhAnh;
        string[] str = listimg.Split('\'');
        foreach (var item in str)
        {
            if (item.ToString() != "")
            {
                Img dataimg = new Img();
                dataimg.ID = idimg;
                dataimg.HinhAnh = item.ToString();
                album.Add(dataimg);
                idimg++;
            }
        }
        rptListImg.DataSource = album;
        rptListImg.DataBind();

        figureLarge.HRef = str.First().Trim().ToString();
        figureThumb.Src = ToThumb(str.First().Trim().ToString());

        List<MonAn> listBV = MonAn.MonAn_LayTheoIDTheLoai(pr.MenuID);
        if (listBV != null && listBV.Count != 0)
        {
            rptRelatedProduct.DataSource = listBV;
            rptRelatedProduct.DataBind();
        }

    }
    public string ToThumb(string input)
    {
        return Helper.ToThumb(input);
    }
    protected string showMoney(decimal input)
    {
        return StringUltility.createMoneyString(input.ToString("#"));
    }

    protected string ShowArticleCat(object sender, string column)
    {
        MonAn baiviet = sender as MonAn;

        switch (column)
        {
            case "laytomtat":
                if (baiviet.MoTa_Vn.Length > 100)
                {
                    if (Session["lang"].ToString().Equals("vn")) { return StringUltility.GetStringByLenght(baiviet.MoTa_Vn, 100) + "..."; }
                    else if (Session["lang"].ToString().Equals("en")) { return StringUltility.GetStringByLenght(baiviet.MoTa_En, 100) + "..."; }
                    else if (Session["lang"].ToString().Equals("ru")) { return StringUltility.GetStringByLenght(baiviet.MoTa_Ru, 100) + "..."; }

                    return StringUltility.GetStringByLenght(baiviet.MoTa_Vn, 100) + "...";
                }
                else
                {
                    if (Session["lang"].ToString().Equals("vn")) { return baiviet.MoTa_Vn; }
                    else if (Session["lang"].ToString().Equals("en")) { return baiviet.MoTa_En; }
                    else if (Session["lang"].ToString().Equals("ru")) { return baiviet.MoTa_Ru; }
                    return baiviet.MoTa_Vn + "...";
                }

            case "ArticleCatDuongDan":
                if (Session["lang"].ToString().Equals("vn"))
                {
                    return "/vn/cuisine/" + Helper.RejectMarks(Eval("TenMon_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.MenuID + ".html";
                }
                else if (Session["lang"].ToString().Equals("en"))
                {
                    return "/en/cuisine/" + Helper.RejectMarks(Eval("TenMon_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.MenuID + ".html";
                }
                else if (Session["lang"].ToString().Equals("ru"))
                {
                    return "/ru/cuisine/" + Helper.RejectMarks(Eval("TenMon_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.MenuID + ".html";
                }

                return "/vn/cuisine/" + Helper.RejectMarks(Eval("TenMon_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.MenuID + ".html"; ;

            case "ArticleCatTenMon":
                if (Session["lang"].ToString().Equals("vn")) { return HttpUtility.HtmlEncode(Eval("TenMon_Vn").ToString()); }
                else if (Session["lang"].ToString().Equals("en")) { return HttpUtility.HtmlEncode(Eval("TenMon_En").ToString()); }
                else if (Session["lang"].ToString().Equals("ru")) { return HttpUtility.HtmlEncode(Eval("TenMon_Ru").ToString()); }
                return HttpUtility.HtmlEncode(Eval("TenMon_Vn").ToString()); ;

            default: return "";
        }
    }

}