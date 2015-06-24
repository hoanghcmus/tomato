using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using System.Text;

public partial class Admin_MgerPhoto : System.Web.UI.Page
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
        dlListImg.DataSource = ImageAndClips.LayTheoTheLoai("6", trang, out howManyPages);
        dlListImg.DataBind();
        firstPageUrl = Link.MgerPhoto();
        pagerFormat = Link.MgerPhoto("{0}");
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
                string url02 = "";
                string url03 = "";
                string listimg = data.ImgOrClip;
                string[] str = listimg.Split('\'');
                url01 = str[0].ToString();
                url02 = str[1].ToString();
                url03 = str[2].ToString();
                sb.Append(String.Format("<img id=\"photo1\" class=\"stackphotos\"  src='{1}' />", data.ID, url01));
                sb.Append(String.Format("<img id=\"photo2\" class=\"stackphotos\" src='{1}' />", data.ID, url02));
                sb.Append(String.Format("<img id=\"photo3\" class=\"stackphotos\" src='{1}' />", data.ID, url03));
                return sb.ToString();
            default:
                return "";
        }
    }
    #endregion

    #region Xu ly xu kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        dlListImg.ItemCommand += new DataListCommandEventHandler(dlListImg_ItemCommand);
    }
    void dlListImg_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAlbum")
        {
            string[] s = e.CommandArgument.ToString().Split('_');
            ImageAndClips.Xoa(s[0].ToString());
            CapNhatHanhDong("Xóa album (id: " + s[0].ToString() + ")");
            PopulateControls();
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