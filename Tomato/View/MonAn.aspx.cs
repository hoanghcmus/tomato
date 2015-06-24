﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;
using DataAccess.StringUtil;
using MultipleLanguage;

public partial class View_MonAn : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        string MenuID = Request.QueryString["catID"] ?? "0";
        List<MonAn> listBV = MonAn.MonAn_LayTheoIDTheLoai(Convert.ToInt32(MenuID));

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
    public string showMoney(decimal input)
    {
        return StringUltility.createMoneyString(input.ToString("#"));
    }
}