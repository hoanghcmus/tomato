using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerGroupUser : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "3")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
                PopulateControls();
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        repProd.DataSource = NhomNguoiDung.LayTatCa();
        repProd.DataBind();
        Label1.Text = "Danh sách nhóm người dùng";
    }
    public string ShowData(object input, string colunmName)
    {
        NhomNguoiDung data = input as NhomNguoiDung;
        switch (colunmName)
        {
            case "NgayTao":
                return data.NgayTao.ToString();
            default:
                return "";
        }

    }
    #endregion
}