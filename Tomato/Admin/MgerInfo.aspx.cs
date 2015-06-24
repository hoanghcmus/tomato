using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerInfo : System.Web.UI.Page
{
    #region Load du lieu
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }
    private void PopulateControls()
    {
        if (Session["IDNguoiDung"].ToString() != "")
        {
            string maNguoiDung = Request.QueryString["IDNguoiDung"] ?? "";
            if (maNguoiDung.CompareTo(Session["IDNguoiDung"].ToString()) == 0)
            {

                ThongTinNguoiDung data = ThongTinNguoiDung.LayTheoIDTTND(maNguoiDung);
                if (data != null)
                {
                    lbMaNguoiDung.Text = data.IDNguoiDung.ToString();
                    lbHoTen.Text = data.TenNguoiDung;
                    lbChucVu.Text = data.ChucVu;
                    lbDiaChi.Text = data.DiaChi;
                    lbNgaySinh.Text = data.NgaySinh;
                    lbSDT.Text = data.SoDT;
                    lbNgayCapNhat.Text = data.NgayCapNhat;
                }
                else
                {
                    lbMaNguoiDung.Text = maNguoiDung.ToString();
                }
            }
            else
                Response.Redirect("~/Admin/MgerInfo.aspx?IDNguoiDung=" + Session["IDNguoiDung"]);

        }
        else
            Response.Redirect("~/Admin/Login.aspx");
    }
    #endregion

    #region Xu ly su kien

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnEdit.Click += new EventHandler(btnEdit_Click);
        btnCancel.Click += new EventHandler(btnCancel_Click);
        btnUpdate.Click += new EventHandler(btnUpdate_Click);
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
        UnLock();
    }

    void btnEdit_Click(object sender, EventArgs e)
    {
        OnLock();
    }

    private void UnLock()
    {
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = true;
        lbHoTen.Enabled = false;
        lbChucVu.Enabled = false;
        lbDiaChi.Enabled = false;
        lbNgayCapNhat.Enabled = false;
        lbNgaySinh.Enabled = false;
        lbSDT.Enabled = false;
    }
    private void OnLock()
    {
        btnCancel.Visible = true;
        btnUpdate.Visible = true;
        lbHoTen.Enabled = true;
        lbChucVu.Enabled = true;
        lbDiaChi.Enabled = true;
        lbNgayCapNhat.Enabled = true;
        lbNgaySinh.Enabled = true;
        lbSDT.Enabled = true;
        btnEdit.Visible = false;
    }
    void btnUpdate_Click(object sender, EventArgs e)
    {
        bool rs = false;
        lbred.Visible = true;
        //Cập nhật tên loại
        ThongTinNguoiDung data = new ThongTinNguoiDung();
        data.IDNguoiDung = Convert.ToInt32(lbMaNguoiDung.Text);
        data.TenNguoiDung = lbHoTen.Text;
        data.ChucVu = lbChucVu.Text;
        data.DiaChi = lbDiaChi.Text;
        data.SoDT = lbSDT.Text;
        data.NgaySinh = ConvertType.ToDateTime(lbNgaySinh.Text).ToShortDateString();
        data.NgayCapNhat = DateTime.Now.ToShortDateString();
        rs = ThongTinNguoiDung.Sua(data);
        if (rs)
        {
            lbred.Text = "Cập nhật thông tin thành công";
            CapNhatHanhDong("Cập nhật thông tin cá nhân");
            UnLock();
        }
        else
            lbred.Text = "Cập nhật thông tin thất bại";
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