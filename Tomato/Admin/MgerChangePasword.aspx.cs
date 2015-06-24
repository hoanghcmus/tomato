using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerChangePasword : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string nguoiDung = Session["IDNguoiDung"].ToString();
        if (nguoiDung != "")
            kq = 1;
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
        if (Session["IDNguoiDung"].ToString() != "")
        {
            string maNguoiDung = Request.QueryString["IDNguoiDung"] ?? "";
            if (maNguoiDung.CompareTo(Session["IDNguoiDung"].ToString().Trim()) == 0)
                lbMaNguoiDung.Text = maNguoiDung.ToString();
            else
                Response.Redirect("~/Admin/MgerChangePasword.aspx?IDNguoiDung=" + Session["IDNguoiDung"]);

        }
        else
            Response.Redirect("~/Admin/Login.aspx");
    }
    #endregion

    #region Xu ly su kien
    private void unlock()
    {
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
    }
    private void onlock()
    {
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
    }
    private void setNull()
    {
        txtMatKhauHienTai.Text = "";
        txtMatKhauMoi.Text = "";
        txtNhapLai.Text = "";
    }
    public int KiemTraDieuKien()
    {
        int kq = 0;
        if (txtMatKhauHienTai.Text == "" || txtNhapLai.Text == "" || txtMatKhauMoi.Text == "")
        {
            lbtbmk.Visible = true;
            onlock();
            lbtbmk.Text = "Không được bỏ trống bất kỳ trường nào";
            kq = 0;
        }
        else
        {
            unlock();
            NguoiDung data = NguoiDung.KiemTraMatKhau(lbMaNguoiDung.Text.Trim(), txtMatKhauHienTai.Text);
            if (data != null)
            {
                if (txtMatKhauMoi.Text.Trim().CompareTo(txtNhapLai.Text.Trim()) == 0)
                    kq = 1;
                else
                {
                    kq = 0;
                    lbtbmk.Visible = true;
                    Label4.Visible = true;
                    lbtbmk.Text = "Nhập lại mật khẩu không khớp";
                }
            }
            else
            {
                kq = 0;
                lbtbmk.Visible = true;
                Label2.Visible = true;
                lbtbmk.Text = "Mật khẩu hiện tại không đúng";
            }
        }
        return kq;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnUpdataMatKhau.Click += new EventHandler(btnUpdataMatKhau_Click);
    }
    void btnUpdataMatKhau_Click(object sender, EventArgs e)
    {
        if (KiemTraDieuKien() == 1)
        {
            unlock();
            lbtbmk.Visible = true;
            bool rs = NguoiDung.SuaMatKhau(lbMaNguoiDung.Text.Trim(), txtNhapLai.Text.Trim());
            if (rs)
            {
                lbtbmk.Text = "Cập nhật mật khẩu thành công!";
                setNull();
                CapNhatHanhDong("Cập nhật mật khẩu");
            }
            else
                lbtbmk.Text = "Cập nhật mật khẩu thất bại!";
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