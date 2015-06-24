using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.Text;
using DataAccess.Connect;
using MultipleLanguage;
using DataAccess.Help;

public partial class Vn_Photos : BasePage
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
        int howManyPages = 0;
        string trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerFormat = "";
        dlListImg.DataSource = ImageAndClips.LayTheoTheLoai("6", trang, out howManyPages);
        dlListImg.DataBind();
        firstPageUrl = Link.Photos();
        pagerFormat = Link.Photos("{0}");
        pagerBottom.Show(int.Parse(trang), howManyPages, firstPageUrl, pagerFormat, true);
    }
    public string ShowImg(object input, string colunmName)
    {
        ImageAndClips data = input as ImageAndClips;
        switch (colunmName)
        {
            case "ImgOrClip":
                StringBuilder sb = new StringBuilder();
                string url01 = "";
                string listimg = data.ImgOrClip;
                string[] str = listimg.Split('\'');

                url01 = str[0].ToString();
                sb.Append(String.Format("<img id=\"photo1\" class=\"img\"  src='{1}' />", data.ID, url01));
                return sb.ToString();

            case "ImageDuongDan":
                if (Session["lang"].ToString().Equals("vn"))
                {
                    return "/vn/gallery/" + DataAccess.Help.Helper.RejectMarks(data.Ten_En) + "-" + data.ID + ".html";
                }
                else if (Session["lang"].ToString().Equals("en")) { return "/en/gallery/" + DataAccess.Help.Helper.RejectMarks(data.Ten_En) + "-" + data.ID + ".html"; }
                else if (Session["lang"].ToString().Equals("ru")) { return "/ru/gallery/" + DataAccess.Help.Helper.RejectMarks(data.Ten_En) + "-" + data.ID + ".html"; }
                else if (Session["lang"].ToString().Equals("cn")) { return "/cn/gallery/" + DataAccess.Help.Helper.RejectMarks(data.Ten_En) + "-" + data.ID + ".html"; }
                return "/vn/gallery/" + DataAccess.Help.Helper.RejectMarks(data.Ten_En) + data.ID + ".html";

            case "ImageTieuDe":
                if (Session["lang"].ToString().Equals("vn")) { return data.Ten_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { return data.Ten_En; }
                else if (Session["lang"].ToString().Equals("ru")) { return data.Ten_Ru; }
                else if (Session["lang"].ToString().Equals("cn")) { return data.Ten_Cn; }
                return data.Ten_Vn;

            default:
                return "";
        }
    }

}