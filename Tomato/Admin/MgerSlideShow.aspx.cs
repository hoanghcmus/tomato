using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerSlideShow : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "4")
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
        string Trang = Request.QueryString["Trang"] ?? "1";
        Label1.Text = "Danh sách tất cả hình ảnh chuyển động";
        repProd.DataSource = SlideShow.LayTatCa();
        repProd.DataBind();
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        repProd.ItemCommand += new RepeaterCommandEventHandler(repProd_ItemCommand);
    }

    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string s = e.CommandArgument.ToString();
            SlideShow.Xoa(s.ToString());
            CapNhatHanhDong("Xóa hình ảnh hiển thị trang chủ (id: " + s[0].ToString() + ")");
        }
        PopulateControls();
    }
    public string ShowContact(object input, string colunmName)
    {
        SlideShow data = input as SlideShow;
        switch (colunmName)
        {
            case "HienThi":
                if (data.HienThi == 1)
                    return String.Format("Hiển thị trang trong");
                else
                    return String.Format("Hiển thị trang ngoài");
            default:
                return "";
        }
    }
    #endregion

    #region Cap nhat hanh dong
    private void CapNhatHanhDong(string hanhDong)
    {
        if (Session["IDNguoiDung"] != "" || Session["IDDangNhap"] != "")
        {
            string maDangNhap = Session["IDDangNhap"].ToString();
            string maNguoiDung = Session["IDNguoiDung"].ToString();
            string hanhDongDangNhap = Session["HanhDongDangNhap"].ToString();
            hanhDongDangNhap += "<br /> - " + hanhDong + " (giờ: " + DateTime.Now.ToShortTimeString() + ")";
            Session["HanhDongDangNhap"] = hanhDongDangNhap;
            DangNhap.SuaHanhDong(maDangNhap, maNguoiDung, hanhDongDangNhap);
        }
    }
    #endregion
}