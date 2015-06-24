using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerProduct : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "4" || item.ToString() == "5")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
            {
                LoadTheLoai();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        int howManyPages = 0;
        string menuID = Request.QueryString["MenuID"] ?? "";
        string chuoiTimKiem = Request.QueryString["Search"] ?? "";
        string Trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";
        if (menuID != "")
        {
            Label1.Text = "Món ăn theo thể loại ID là " + menuID;
            repProd.DataSource = MonAn.InMenu(menuID, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerProductToMenu(menuID);
            pagerUrl = DataAccess.Connect.Link.MgerProductToMenu(menuID, "{0}");
        }
        else if (chuoiTimKiem != "")
        {
            Label1.Text = "Kết quả tìm kiếm món ăn cho chuỗi '" + chuoiTimKiem + "'";
            txtTimKiem.Text = chuoiTimKiem.ToString();
            repProd.DataSource = MonAn.Search(chuoiTimKiem, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerProductToSreach(chuoiTimKiem);
            pagerUrl = DataAccess.Connect.Link.MgerProductToSreach(chuoiTimKiem, "{0}");
        }
        else
        {
            Label1.Text = "Danh sách tất cả các món ăn";
            repProd.DataSource = MonAn.Paging(Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerProduct();
            pagerUrl = DataAccess.Connect.Link.MgerProduct("{0}");
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    private void LoadTheLoai()
    {
        ddlTheLoai.DataValueField = "ID";
        ddlTheLoai.DataTextField = "TieuDe_Vn";
        ddlTheLoai.DataSource = TheLoai.LayTheoModuleVaParentNoNull("4");
        ddlTheLoai.DataBind();
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnTimKiem.Click += new EventHandler(btnTimKiem_Click);
        repProd.ItemCommand += new RepeaterCommandEventHandler(repProd_ItemCommand);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                MonAn.Delete(id);
                CapNhatHanhDong("Xóa món ăn(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnTimKiem_Click(object sender, EventArgs e)
    {
        string chuoiTimKiem = txtTimKiem.Text.Trim();
        if (chuoiTimKiem != "")
        {
            CapNhatHanhDong("Tìm kiếm món ăn(chuổi tìm kiếm: " + chuoiTimKiem + ")");
            Response.Redirect("MgerProduct.aspx?Search=" + chuoiTimKiem);
        }
    }
    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
    }
    protected void ddlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        int chon = Convert.ToInt32(ddlTheLoai.SelectedValue);
        if (chon != 0)
            Response.Redirect("~/Admin/MgerProduct.aspx?MenuID=" + chon.ToString());
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