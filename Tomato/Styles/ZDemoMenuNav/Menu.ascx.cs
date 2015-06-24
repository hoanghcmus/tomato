using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.Text;

public partial class UserControl_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string LoadMenu()
    {
        List<TheLoai> list = TheLoai.LayTheoLoaiMenuVaParentIsNull("1");
        StringBuilder sb = new StringBuilder();
        BuildMenus(ref sb, list);
        return sb.ToString();
    }
    protected void BuildMenus(ref StringBuilder sb, List<TheLoai> menuItems)
    {
        sb.Append("<ul id=\"nav\">");
        sb.Append("<li id=\"selected\" class=\"home_li\"> <a href=\"../trang-chu.html\">TRANG CHỦ</a></li>");
        foreach (TheLoai item in menuItems)
        {
            sb.Append("<li >");
            sb.Append("<a href=" + item.DuongDan_Vn + ">" + item.TieuDe_Vn + "</a>");

            sb.Append("</li>");
        }
        sb.Append("</ul>");
    }
}