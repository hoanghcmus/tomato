using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerTour : System.Web.UI.Page
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
        string menuID = Request.QueryString["ID"] ?? "";
        string chuoiTimKiem = Request.QueryString["ChuoiTimKiem"] ?? "";
        string Trang = Request.QueryString["Trang"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";
        if (chuoiTimKiem != "")
        {
            Label1.Text = "Kết quả tìm kiếm tin tức cho chuỗi '" + chuoiTimKiem + "'";
            txtTimKiem.Text = chuoiTimKiem.ToString();
            repProd.DataSource = Tour.TimKiem(chuoiTimKiem, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerTourToSreach(chuoiTimKiem);
            pagerUrl = DataAccess.Connect.Link.MgerTourToSreach(chuoiTimKiem, "{0}");
        }
        else if (menuID != "")
        {
            Label1.Text = "Tour theo thể loại ID là " + menuID;
            repProd.DataSource = Tour.LayTheoTheLoai(menuID, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerTourToMenu(menuID);
            pagerUrl = DataAccess.Connect.Link.MgerTourToMenu(menuID, "{0}");
        }
        else
        {
            Label1.Text = "Danh sách Tour ";
            repProd.DataSource = Tour.LayTatCa(Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerTour();
            pagerUrl = DataAccess.Connect.Link.MgerTour("{0}");
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    private void LoadTheLoai()
    {
        ddlTheLoai.Items.Clear();
        ddlTheLoai.Items.Add(new ListItem("-- Chọn theo thể loại --", "0"));
        var list = TheLoai.LayTheoModuleVaParentIsNull("3");
        foreach (var item in list)
        {
            ddlTheLoai.Items.Add(new ListItem(item.TieuDe_Vn, item.ID.ToString()));
            var tl = TheLoai.LayTheoIDParent(item.ID.ToString());
            foreach (var itemtl in tl)
            {
                ddlTheLoai.Items.Add(new ListItem("--- " + itemtl.TieuDe_Vn, itemtl.ID.ToString()));
            }
        }
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
                Tour.Xoa(id);
                CapNhatHanhDong("Xóa tour(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnTimKiem_Click(object sender, EventArgs e)
    {
        string chuoiTimKiem = txtTimKiem.Text.Trim();
        if (chuoiTimKiem != "")
        {
            CapNhatHanhDong("Tìm kiếm tour(chuổi tìm kiếm: " + chuoiTimKiem + ")");
            Response.Redirect("MgerTour.aspx?ChuoiTimKiem=" + chuoiTimKiem);
        }
    }
    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "UpdateTrangChu")
        {
            string[] s = e.CommandArgument.ToString().Split('_');
            Tour.SuaTrangChu(Convert.ToInt32(s[0]), !Boolean.Parse(s[1]));
            CapNhatHanhDong("Sửa tour hiển thị trang chủ (id: " + Convert.ToInt32(s[0]).ToString() + ")");
            PopulateControls();
        }
    }
    protected void ddlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        int chon = Convert.ToInt32(ddlTheLoai.SelectedValue);
        if (chon != 0)
            Response.Redirect("~/Admin/MgerTour.aspx?ID=" + chon.ToString());
    }
    public string ShowPrice(object input, string colunmName)
    {
        Tour data = input as Tour;
        switch (colunmName)
        {
            case "GiaTour":
                if (data.GiaTour == 0)
                    return "liên hệ";
                else
                    return String.Format("<span class='spct'>{0:0,0}</span>", data.GiaTour);
            default:
                return "Vui lòng liên hệ!";
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