﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerXuLyDatTour1 : System.Web.UI.Page
{
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
    protected void PopulateControls()
    {
        string id = Request.QueryString["ID"];
        lbID.Text = id;
        DatTiec dataTiec = DatTiec.LayTheoID(id);
        if (dataTiec != null)
            LoadDatTiec(dataTiec);
    }
    protected void LoadDatTiec(DatTiec data)
    {

        //Thong tin khach hang
        lbID.Text = data.ID.ToString();
        lbdiachi.Text = data.DiaChi;
        lbhoten.Text = data.Ten;
        lbemail.Text = data.Email;
        lbgio.Text = data.Gio;
        lbnguoi.Text = data.SoNguoi;
        lbngaydat.Text = String.Format("{0:dd/MM/yyyy}", data.Ngay);
        lbsdt.Text = data.SDT.ToString();
        lbngaygui.Text = String.Format("{0:dd/MM/yyyy}", data.NgayGui);
        lbtrangthai.Text = LoaiStatus(data.TrangThai);
        titletrangthai.Text = data.TrangThai.ToString();
    }
    public string LoaiStatus(int status)
    {
        switch (status)
        {
            case 0:
                return "Đợi duyệt";
            case 1:
                return "Đã duyệt";
            case 2:
                return "Đã hủy";
            default:
                return "?";
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnMarkPending.Click += new EventHandler(btnMarkPending_Click);
        btnMarkCompleted.Click += new EventHandler(btnMarkCompleted_Click);
        btnMarkCanceled.Click += new EventHandler(btnMarkCanceled_Click);
    }
    void UpdateStatus(string status)
    {
        bool rs = DatTiec.SuaTrangThai(ConvertType.ToInt32(lbID.Text.Trim()), status);
        if (rs)
        {
            succesfull.Visible = true;
            succesfull.Text = "Cập nhật trạng thái thành công";
            lbtrangthai.Text = LoaiStatus(ConvertType.ToInt32(status));
            titletrangthai.Text = status;
        }
        else
        {
            lbtitle.Visible = true;
            lbtitle.Text = "Cập nhật trạng thái thất bại";
        }
    }
    void btnMarkCanceled_Click(object sender, EventArgs e)
    {
        // Danh dau trang thai Order la Canceled 
        UpdateStatus("2");
    }
    void btnMarkCompleted_Click(object sender, EventArgs e)
    {
        // Danh dau trang thai Order la Completed 
        UpdateStatus("1");
    }
    void btnMarkPending_Click(object sender, EventArgs e)
    {
        // Danh dau trang thai Order la Pending 
        UpdateStatus("0");
    }
}