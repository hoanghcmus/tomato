using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.Text;

public partial class Vn_Vn_Control_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string LoadMenu()
    {
        return BuildMenu(0).ToString();
    }

    protected StringBuilder BuildMenu(int id)
    {
        List<TheLoai> listTheLoai = TheLoai.TheLoai_GetByCategoryAndParentID("1", id);
        string activeMenuID = Request.QueryString["MenuItemID"] ?? "";
        if (activeMenuID.Equals("")) { activeMenuID = "12"; }

        StringBuilder sb = new StringBuilder();

        if (listTheLoai.Count() != 0)
        {
            sb.Append("<ul>");
            foreach (TheLoai theLoai in listTheLoai)
            {
                if (hasRow(theLoai.ID))
                {
                    if (theLoai.ID.ToString().Equals(activeMenuID))
                    {
                        sb.Append("<li class='has-sub active'>");
                    }
                    else
                    {
                        sb.Append("<li class='has-sub'>");
                    }

                }
                else
                {
                    if (theLoai.ID.ToString().Equals(activeMenuID))
                    {
                        sb.Append("<li class='active'>");
                    }
                    else
                    {
                        sb.Append("<li>");
                    }
                }

                if (Session["lang"].ToString().Equals("vn"))
                {
                    sb.Append("<a href='" + theLoai.DuongDan_Vn + "'> <span>" + theLoai.TieuDe_Vn + "</span></a>");
                }
                else if (Session["lang"].ToString().Equals("en"))
                {
                    sb.Append("<a href='" + theLoai.DuongDan_En + "'> <span>" + theLoai.TieuDe_En + "</span></a>");
                }
                else if (Session["lang"].ToString().Equals("ru"))
                {
                    sb.Append("<a href='" + theLoai.DuongDan_Ru + "'> <span>" + theLoai.TieuDe_Ru + "</span></a>");
                }
                else if (Session["lang"].ToString().Equals("cn"))
                {
                    sb.Append("<a href='" + theLoai.DuongDan_Cn + "'> <span>" + theLoai.TieuDe_Cn + "</span></a>");
                }


                sb.Append(BuildMenu(theLoai.ID));

                sb.Append("</li>");
            }
            sb.Append("</ul>");
        }

        return sb;
    }

    private bool hasRow(int menuItemID)
    {

        bool value = false;
        List<TheLoai> theLoais = TheLoai.COUNT_ON_THELOAI(menuItemID);
        if (theLoais.Count() != 0)
        {
            value = true;
        }

        return value;
    }

}