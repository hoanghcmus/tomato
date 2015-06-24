using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Refresh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetNullAccount();
        Response.Redirect("~/Admin/Login.aspx");
    }
    protected void SetNullAccount()
    {
        Session["IDNguoiDung"] = "";
        Session["IDDangNhap"] = "";
        Session["TenNguoiDung"] = "";
        Session["QuyenHan"] = "";
    }
}