using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.StringUtil;
using Language;

public partial class En_En_Control_UC_Choose_Language : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVn_Click(object sender, EventArgs e)
    {
        Response.Redirect(getNewURL("vn"));
    }
    protected void btnEn_Click(object sender, EventArgs e)
    {
        Response.Redirect(getNewURL("en"));
    }
    protected void btnRus_Click(object sender, EventArgs e)
    {
        Response.Redirect(getNewURL("ru"));
    }
    

    protected string getNewURL(string lang)
    {
        Session["lang"] = lang;

        string OldUrl = Request.Url.ToString().Split('?').First().ToString();
        string newURL = "";

        string[] urlPat = OldUrl.Split('/');
        for (int i = 0; i < urlPat.Length; i++)
        {
            if (i == 3)
            {
                newURL += lang + "/";
                continue;
            }
            if (i == urlPat.Length - 1)
            {
                newURL += urlPat[i];
            }
            else
            {
                newURL += urlPat[i] + "/";
            }
        }
        return newURL;
    }

}