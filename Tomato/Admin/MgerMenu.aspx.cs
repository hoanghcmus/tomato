using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerMenu : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "2")
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
                LoadMenu();
                LoadModule();
                PopulateControls("","");
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void LoadMenu()
    {
        ddlLoadLoaiMenu.DataValueField = "ID";
        ddlLoadLoaiMenu.DataTextField = "TenLoai";
        ddlLoadLoaiMenu.DataSource = LoaiMenu.LayTatCa();
        ddlLoadLoaiMenu.DataBind();
    }
    private void LoadModule()
    {
        ddlLoadLoaimodule.DataValueField = "ID";
        ddlLoadLoaimodule.DataTextField = "TenLoai";
        ddlLoadLoaimodule.DataSource = Module.LayTatCa();
        ddlLoadLoaimodule.DataBind();
    }
    private void PopulateControls(string loaimenu, string loaimodule)
    {
        if (loaimenu != "")
        {
            Label1.Text = "Danh sách thể loại theo loại menu '" + loaimenu + "'";
            repProd.DataSource = TheLoai.LayTheoLoaiMenu(loaimenu);
            repProd.DataBind();
        }
        else if (loaimodule != "")
        {
            Label1.Text = "Danh sách thể loại theo loại module '" + loaimodule + "'";
            repProd.DataSource = TheLoai.LayTheoModule(loaimodule);
            repProd.DataBind();
        }
        else
        {
            Label1.Text = "Danh sách tất cả thể loại";
            repProd.DataSource = TheLoai.LayTatCa();
            repProd.DataBind();
        }
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        repProd.ItemCommand += new RepeaterCommandEventHandler(repProd_ItemCommand);
    }
    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "UpdateFooter")
        {
            string[] s = e.CommandArgument.ToString().Split('_');
            TheLoai.SuaFooter(Convert.ToInt32(s[0]), !Boolean.Parse(s[1]));
            CapNhatHanhDong("Sửa thể loại hiển thị footer (id: " + Convert.ToInt32(s[0]).ToString() + ")");
            PopulateControls("","");
        }
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            string danhsachxoa = "";
            foreach (string id in stringid.Split(','))
            {
                int rs = TheLoai.Xoa(id);
                if (rs>0)
                    danhsachxoa += "IDTheLoai=" + id + ";";
            }
            CapNhatHanhDong("Xóa danh sách thể loại(" + danhsachxoa + ")");
            PopulateControls("","");
        }
    }
    protected void ddlLoadLoaiMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idLoaiMenu = ddlLoadLoaiMenu.SelectedValue.ToString().Trim();
        if(idLoaiMenu!="")
            PopulateControls(idLoaiMenu, "");
    }
    protected void ddlLoadLoaimodule_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idLoaiModule = ddlLoadLoaimodule.SelectedValue.ToString().Trim();
        if (idLoaiModule != "")
            PopulateControls("", idLoaiModule);
    }
    public string ShowCategory(object input, string colunmName)
    {
        TheLoai data = input as TheLoai;
        switch (colunmName)
        {
            case "ID":
                if (data.ID == 16 || data.ID == 17 ||data.ID == 18 || data.ID == 1 )//Thuoc xu ly cua he thong
                    return String.Format("<input type='button' class='lock' title='Thể loại này thuộc quản lý của hệ thống' />");
                else
                    return String.Format("<input type='checkbox' name='cid' value='{0}'/>", data.ID);
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