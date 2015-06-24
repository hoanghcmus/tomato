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

public partial class Vn_DetailArticle : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    private void PopulateControls()
    {
        string id = Request.QueryString["ID"];
        BaiViet data = BaiViet.LayTheoID(id);
        if (data != null)
        {
            int luotxem = data.LuotXem + 1;
            BaiViet.SuaLuotXem(id, luotxem.ToString());

            if (Session["lang"].ToString().Equals("vn"))
            {
                lblTitle.Text = data.TieuDe_Vn;
                lblFullText.Text = HttpUtility.HtmlDecode(data.ChiTiet_Vn);
                lbLuotXem.Text = "Lượt xem: " + luotxem.ToString();
                ltrCtTitle.Text = data.TenTheLoai_Vn;
            }
            else if (Session["lang"].ToString().Equals("en"))
            {
                lblTitle.Text = data.TieuDe_En;
                lblFullText.Text = HttpUtility.HtmlDecode(data.ChiTiet_En);
                lbLuotXem.Text = "Views: " + luotxem.ToString();
                ltrCtTitle.Text = data.TenTheLoai_En;
            }
            else if (Session["lang"].ToString().Equals("ru"))
            {
                lblTitle.Text = data.TieuDe_Ru;
                lblFullText.Text = HttpUtility.HtmlDecode(data.ChiTiet_Ru);
                lbLuotXem.Text = "взгляды: " + luotxem.ToString();
                ltrCtTitle.Text = data.TenTheLoai_Ru;
            }



            if (data.IDParent != 0)
            {
                List<BaiViet> listBV = BaiViet.LayLienQuanIDParentTop10(data.IDTheLoai.ToString(), data.ID.ToString());

                if (listBV != null && listBV.Count > 0)
                {
                    dlarticlerang.DataSource = listBV;
                    dlarticlerang.DataBind();
                    RealtiveArticle.Visible = true;
                }
                else
                    RealtiveArticle.Visible = false;
            }
        }
    }

    protected string ShowRelatedArticle(object sender, string column)
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
                    else if (Session["lang"].ToString().Equals("cn")) { return StringUltility.GetStringByLenght(baiviet.TomTat_Cn, 100) + "..."; }
                    return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 100) + "...";
                }
                else
                {
                    if (Session["lang"].ToString().Equals("vn")) { return baiviet.TomTat_Vn; }
                    else if (Session["lang"].ToString().Equals("en")) { return baiviet.TomTat_En; }
                    else if (Session["lang"].ToString().Equals("ru")) { return baiviet.TomTat_Ru; }
                    else if (Session["lang"].ToString().Equals("cn")) { return baiviet.TomTat_Cn; }
                    return baiviet.TomTat_Vn + "...";
                }

            case "RelatedArticleDuongDan":
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
                else if (Session["lang"].ToString().Equals("cn"))
                {
                    return "/cn/article/" + Helper.RejectMarks(Eval("TieuDe_Cn").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html";
                }
                return "/vn/article/" + Helper.RejectMarks(Eval("TieuDe_En").ToString()) + "-" + baiviet.ID + "-" + baiviet.IDTheLoai + ".html"; ;

            case "RelatedArticleTieuDe":
                if (Session["lang"].ToString().Equals("vn")) { return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); }
                else if (Session["lang"].ToString().Equals("en")) { return HttpUtility.HtmlEncode(Eval("TieuDe_En").ToString()); }
                else if (Session["lang"].ToString().Equals("ru")) { return HttpUtility.HtmlEncode(Eval("TieuDe_Ru").ToString()); }
                else if (Session["lang"].ToString().Equals("cn")) { return HttpUtility.HtmlEncode(Eval("TieuDe_Cn").ToString()); }
                return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); ;

            default: return "";
        }
    }


}