using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerDatTour : System.Web.UI.Page
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
            SelectDateTime();
            if (!IsPostBack)
                PopulateControls();
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        int howManyPages = 0;
        string tinhTrang = Request.QueryString["TinhTrang"] ?? "";
        string Trang = Request.QueryString["Trang"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";
        if (tinhTrang != "")
        {
            repProd.DataSource = DatTour.LayTheoTrangThai(tinhTrang, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerDatTourState(tinhTrang);
            pagerUrl = DataAccess.Connect.Link.MgerDatTourState(tinhTrang, "{0}");
            switch (int.Parse(tinhTrang))
            {
                case 0:
                    Label1.Text = "Danh sách hóa đơn đặt tour đang đợi duyệt";
                    break;
                case 1:
                    Label1.Text = "Danh sách hóa đơn đặt tour đã duyệt";
                    break;
                case 2:
                    Label1.Text = "Danh sách hóa đơn đặt tour đã hủy";
                    break;
                default:
                    Label1.Text = "Không tim thấy trang thái hóa đơn đặt Tour!";
                    break;
            }
        }
        else
        {
            repProd.DataSource = DatTour.LayTatCa(Trang, out howManyPages);
            repProd.DataBind();
            Label1.Text = "Danh sách đặt tour từ khách hàng";
            firstPageUrl = DataAccess.Connect.Link.MgerDatTour();
            pagerUrl = DataAccess.Connect.Link.MgerDatTour("{0}");
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    private void SelectDateTime()
    {
        string script = "$(function(){$('#" + txtStartDate.ClientID + "').datepicker();});"
    + "$(function(){$('#" + txtEndDate.ClientID + "').datepicker();});";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), this.ID, script, true);
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnGetByDate.Click += new EventHandler(btnGetByDate_Click);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                DatTour.Xoa(id);
                CapNhatHanhDong("Xóa đặt Tour(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnGetByDate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && (txtStartDate.Text + txtEndDate.Text != ""))
            repProd.DataSource = DatTour.ByDate(txtStartDate.Text, txtEndDate.Text);
        else
            lblStatus.Text = "Xin vui lòng nhập ngày hộp lệ (dd/mm/yyyy)!";
        repProd.DataBind();
    }
    public string ShowDatTour(object input, string colunmName)
    {
        DatTour data = input as DatTour;
        switch (colunmName)
        {
            case "HoTen":
                if (data.TrangThai == 0)
                    return String.Format("<a href=\"javascript:void(0)\" target=\"_blank\" class=\"red\" onclick='window.open(\"MgerXuLyDatTour1.aspx?ID={0}\",\"Upload\",\"height=630,width=640,\");return false;'>{1}</a>", data.ID, data.HoTen);
                else if (data.TrangThai == 1)
                    return String.Format("<p>{0}</p>", data.HoTen);
                else
                    return String.Format("<p class='textoverline'>{0}</p>", data.HoTen);
            case "TenTour":
                if (data.TrangThai == 0)
                    return String.Format("<a href=\"javascript:void(0)\" target=\"_blank\" class=\"red\" onclick='window.open(\"MgerXuLyDatTour1.aspx?ID={0}\",\"Upload\",\"height=630,width=640,\");return false;'>{1}</a>", data.ID, data.TenTour);
                else if (data.TrangThai == 1)
                    return String.Format("<p>{0}</p>", data.TenTour);
                else
                    return String.Format("<p class='textoverline'>{0}</p>", data.TenTour);
            case "NgayGui":
                return data.NgayGui.ToShortDateString();
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
                Response.Redirect("~/Admin/MgerDatTour.aspx?TinhTrang=0");
                break;
            case 1:
                Response.Redirect("~/Admin/MgerDatTour.aspx?TinhTrang=1");
                break;
            case 2:
                Response.Redirect("~/Admin/MgerDatTour.aspx?TinhTrang=2");
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