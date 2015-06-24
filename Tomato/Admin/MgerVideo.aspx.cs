using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using DataAccess.Help;

public partial class Admin_MgerVideo : System.Web.UI.Page
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
        int howManyPages = 0;
        string trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerFormat = "";
        dlListVideo.DataSource = ImageAndClips.LayTheoTheLoai("18", trang, out howManyPages);
        dlListVideo.DataBind();
        firstPageUrl = Link.MgerVideo();
        pagerFormat = Link.MgerVideo("{0}");
        pagerBottom.Show(int.Parse(trang), howManyPages, firstPageUrl, pagerFormat, true);
    }
    #endregion

    #region Xu ly xu kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        dlListVideo.ItemCommand += new DataListCommandEventHandler(dlListImg_ItemCommand);
    }
    void dlListImg_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteVideo")
        {
            string s = e.CommandArgument.ToString();
            ImageAndClips.Xoa(s.ToString());
            CapNhatHanhDong("Xóa video (id: " + s[0].ToString() + ")");
        }
        PopulateControls();
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