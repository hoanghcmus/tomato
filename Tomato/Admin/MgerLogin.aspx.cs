using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerLogin : System.Web.UI.Page
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
    private void LoadNguoiDung()
    {
        ddlCategory.DataValueField = "IDNguoiDung";
        ddlCategory.DataTextField = "TenDangNhap";
        ddlCategory.DataSource = NguoiDung.LayTatCa();
        ddlCategory.DataBind();
    }
    private void PopulateControls()
    {
        LoadNguoiDung();
        int howManyPages = 0;
        string maNguoiDung = Request.QueryString["User"] ?? "";
        string Trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";
        if (maNguoiDung != "")
        {
            repProd.DataSource = DangNhap.LayTheoIDNguoiDung(maNguoiDung, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerLoginUser(maNguoiDung);
            pagerUrl = DataAccess.Connect.Link.MgerLoginUser(maNguoiDung, "{0}");
            Label1.Text = "Danh sách đăng nhập của người dùng có ID '" + maNguoiDung.ToString() + "'";
        }
        else
        {
            repProd.DataSource = DangNhap.LayTatCa(Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerLogin();
            pagerUrl = DataAccess.Connect.Link.MgerLogin("{0}");
            Label1.Text = "Danh sách đăng nhập của tất cả người dùng";
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                if (id.CompareTo(Session["IDDangNhap"].ToString()) != 0)
                {
                    CapNhatHanhDong("Xóa đăng nhập(id: " + id + ")");
                    DangNhap.Xoa(id);
                }
            }
            PopulateControls();
        }
    }
    public string ShowData(object input, string colunmName)
    {
        DangNhap data = input as DangNhap;
        switch (colunmName)
        {
            case "ThoiGian":
                return data.ThoiGian.ToString();
            default:
                return "";
        }

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nguoiDung = ddlCategory.SelectedValue.ToString().Trim();
        Response.Redirect("~/Admin/MgerLogin.aspx?User=" + nguoiDung);
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