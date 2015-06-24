using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerUser : System.Web.UI.Page
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
            {
                LoadDate();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        Label1.Text = "Danh sách người dùng";
        repProd.DataSource = NguoiDung.LayTatCa();
        repProd.DataBind();
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                NguoiDung.Xoa(id);
                CapNhatHanhDong("Xóa người dùng(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    #endregion

    #region Xu ly them
    public void LoadDate()
    {
        for (int ngay = 1; ngay < 32; ngay++)
        {
            ddlNgay.Items.Add(ngay.ToString());
        }
        for (int thang = 1; thang < 13; thang++)
        {
            ddlThang.Items.Add(thang.ToString());
        }
        for (int nam = 1960; nam < 2000; nam++)
        {
            ddlNam.Items.Add(nam.ToString());
        }
    }
    public int KiemTraDieuKien()
    {
        int kq = 0;
        if (txtNhapTenDangNhap.Text == "" || txtNhapMatKhau.Text == "")
        {
            lbtitle.Visible = true;
            lbtitle.Text = "Tên đăng nhập và mật khẩu không được bỏ trống!";
            return kq;
        }
        else if (txtNhapTenDangNhap.Text.Length > 200 || txtNhapMatKhau.Text.Length > 200)
        {
            lbtitle.Visible = true;
            lbtitle.Text = "(Tên đăng nhập phải < 200 ký tự và Mật khẩu phải < 200 ký tự)";
            return kq;
        }
        else
        {
            if (NguoiDung.DemTenDangNhap(txtNhapTenDangNhap.Text) > 0)
            {
                lbtitle.Visible = true;
                lbtitle.Text = "Tên đăng nhập đã tồn tại!";
                return kq;
            }
            else
            {
                if (txtNhapLaiMatKhau.Text.CompareTo(txtNhapMatKhau.Text) == 0)
                {
                    return kq = 1;
                }
                else
                {
                    lbtitle.Visible = true;
                    lbtitle.Text = "Mật khẩu không khớp!";
                    return kq;
                }
            }
        }
    }
    public int KiemTraDieuKienThongTin()
    {
        int kq = 0;
        if (txtHoTen.Text == "" || txtChucVu.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
        {
            lbtitle2.Visible = true;
            lbtitle2.Text = "Họ tên, chức vụ, địa chỉ, SĐT không được bỏ trống!";
            return kq;
        }
        else
        {
            if (txtHoTen.Text.Length > 100 || txtChucVu.Text.Length > 100 || txtDiaChi.Text.Length > 1000)
            {
                lbtitle2.Visible = true;
                lbtitle2.Text = "(Họ tên, chức vụ phải < 100 ký tự và Địa chỉ phải < 1000 ký tự)";
                return kq;
            }
            else if (ddlNgay.SelectedIndex == 0 || ddlThang.SelectedIndex == 0 || ddlNam.SelectedIndex == 0)
            {
                lbtitle2.Visible = true;
                lbtitle2.Text = "(Vui lòng chọn mục ngày sinh!)";
                return kq;
            }
            else
            {
                string sdt = txtSDT.Text.Trim();
                bool isnum = Helper.IsNumber(sdt);
                if (isnum == false)
                {
                    lbtitle2.Visible = true;
                    lbtitle2.Text = "(Số điện thoại phải nhập và bằng số)";
                    return kq;
                }
                else
                {
                    return kq = 1;
                }
            }
        }
    }
    protected void refesh()
    {
        txtNhapTenDangNhap.Text = "";
        txtNhapMatKhau.Text = "";
        txtNhapLaiMatKhau.Text = "";
        txtSDT.Text = "";
        txtHoTen.Text = "";
        txtChucVu.Text = "";
        txtDiaChi.Text = "";
        ddlNgay.SelectedIndex = 0;
        ddlThang.SelectedIndex = 0;
        ddlNam.SelectedIndex = 0;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        lbrs.Visible = true;
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (KiemTraDieuKien() == 1 && KiemTraDieuKienThongTin() == 1)
        {
            NguoiDung data = new NguoiDung();
            data.TenDangNhap = txtNhapTenDangNhap.Text;
            data.MatKhau = txtNhapMatKhau.Text;
            int rs = NguoiDung.Them(data);
            if (rs != 0)
            {
                CapNhatHanhDong("Thêm người dùng(id: " + rs + ")");
                lbrs.Text = "*Không thêm được thông tin người dùng!";
                ThongTinNguoiDung dataTTND = new ThongTinNguoiDung();
                dataTTND.IDNguoiDung = rs;
                dataTTND.TenNguoiDung = txtHoTen.Text;
                dataTTND.ChucVu = txtChucVu.Text;
                dataTTND.DiaChi = txtDiaChi.Text;
                dataTTND.NgaySinh = ddlNgay.SelectedValue + "/" + ddlThang.SelectedValue + "/" + ddlNam.SelectedValue;
                dataTTND.SoDT = txtSDT.Text;
                int rsTTND = ThongTinNguoiDung.Them(dataTTND);
                if (rsTTND > 0)
                {
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Thêm người dùng thành công!";
                    CapNhatHanhDong("Thêm thông tin người dùng(id: " + rs + ")");
                    lbrs.Text = "*Thêm dữ liệu thành công!";
                }
                else
                {
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Thêm thất bại!";
                }
                refesh();
                lbtitle.Visible = false;
                lbtitle2.Visible = false;
                PopulateControls();
            }
            else
            {
                lbtitle.Visible = true;
                lbtitle.Text = "Thêm thất bại!";
                lbrs.Text = "*Thêm dữ liệu thất bại!";
            }
        }
        else
            lbrs.Text = "*Không thêm được dữ liệu!";
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