using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerContact : System.Web.UI.Page
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
        string tinhTrang = Request.QueryString["Status"] ?? "";
        string Trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";
        if (tinhTrang != "")
        {

            repProd.DataSource = LienHe.LayTheoTrangThaiVaTheLoai(tinhTrang,"1", Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerContact(tinhTrang);
            pagerUrl = DataAccess.Connect.Link.MgerContact(tinhTrang, "{0}");
            switch (int.Parse(tinhTrang))
            {
                case 0:
                    Label1.Text = "Danh sách các thư đợi duyệt";
                    btnDang.Visible = true;
                    break;
                case 1:
                    Label1.Text = "Danh sách các thư đã duyệt";
                    break;
                default:
                    Label1.Text = "Không tim thấy trang thái thư này!";
                    break;
            }
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnDang.Click += new EventHandler(btnDang_Click);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                LienHe.Xoa(id);
                CapNhatHanhDong("Xóa hợp thư(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnDang_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                if (LienHe.SuaTrangThai(id, "1") == true)
                {
                    Label1.Text = "Duyệt thư thành công!";
                    CapNhatHanhDong("Duyệt thư(id: " + id + ")");
                }
            }
            PopulateControls();
        }
    }

    public string ShowContact(object input, string colunmName)
    {
        LienHe data = input as LienHe;
        switch (colunmName)
        {
            case "HoTen":
                if (data.TrangThai == 0)
                    return String.Format("<p class=\"red\">{0}</p>", data.HoTen);
                else
                    return String.Format("<p>{0}</p>", data.HoTen);
            case "Email":
                if (data.TrangThai == 0)
                    return String.Format("<p class=\"red\">{0}</p>", data.Email);
                else
                    return String.Format("<p>{0}</p>", data.Email);
            case "NgayGui":
                if (data.TrangThai == 0)
                    return String.Format("<p class=\"red\">{0}</p>", data.NgayGui.ToShortDateString());
                else
                    return String.Format("<p>{0}</p>", data.NgayGui.ToShortDateString());
            case "ID":
                if (data.TrangThai == 0)
                    return String.Format("<p class=\"red\">{0}</p>", data.ID);
                else
                    return String.Format("<p>{0}</p>", data.ID);
            default:
                return "";
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int chon = Convert.ToInt32(ddlCategory.SelectedValue);
        switch (chon)
        {
            case 0:
                Response.Redirect("~/Admin/MgerContact.aspx?Status=0");
                break;
            case 1:
                Response.Redirect("~/Admin/MgerContact.aspx?Status=1");
                break;
            default:
                PopulateControls();
                break;
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