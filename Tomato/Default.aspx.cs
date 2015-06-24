using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultipleLanguage;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string lang = Session["lang"].ToString() ?? "vn";
        //Response.Redirect("/Oops.aspx");
        Response.Redirect("/" + lang + "/home-1.html");
    }
}