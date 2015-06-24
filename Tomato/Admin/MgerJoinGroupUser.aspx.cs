using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerJoinGroupUser : System.Web.UI.Page
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
                LoadPhanNguoiDung();
                LoadPhanNhomNguoiDung();
                LoadNguoiDung();
                LoadNhomNguoiDung();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void LoadNguoiDung()
    {
        ddlNguoiDung.DataValueField = "IDNguoiDung";
        ddlNguoiDung.DataTextField = "TenDangNhap";
        ddlNguoiDung.DataSource = NguoiDung.LayTatCa();
        ddlNguoiDung.DataBind();
    }
    private void LoadNhomNguoiDung()
    {
        ddlNhomQuyen.DataValueField = "IDNhom";
        ddlNhomQuyen.DataTextField = "TenNhom";
        ddlNhomQuyen.DataSource = NhomNguoiDung.LayTatCa();
        ddlNhomQuyen.DataBind();
    }
    private void PopulateControls()
    {
        string maNguoiDung = Request.QueryString["NguoiDung"] ?? "";
        string maNhom = Request.QueryString["NhomQuyen"] ?? "";
        if (maNguoiDung != "")
        {
            Label1.Text = "Danh sách phân nhóm theo người dùng '" + maNguoiDung + "'";
            repProd.DataSource = PhanNhom.LayTheoMaNguoiDung(maNguoiDung);
            repProd.DataBind();
        }
        else if (maNhom != "")
        {
            Label1.Text = "Danh sách phân nhóm theo nhóm quyền '" + maNhom + "'";
            repProd.DataSource = PhanNhom.LayTheoMaNhom(maNhom);
            repProd.DataBind();
        }
        else
        {
            Label1.Text = "Danh sách phân nhóm người dùng";
            repProd.DataSource = PhanNhom.LayTatCa();
            repProd.DataBind();
        }
    }
    #endregion

    #region Xu ly du lieu
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
                PhanNhom.Xoa(id);
                CapNhatHanhDong("Xóa phân nhóm người dùng (id : " + id + ")");
            }
            PopulateControls();
        }
    }
    public string ShowData(object input, string colunmName)
    {
        PhanNhom data = input as PhanNhom;
        switch (colunmName)
        {
            case "NgayTao":
                return data.NgayTao.ToString();
            default:
                return "";
        }

    }
    protected void ddlNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maNguoiDung = ddlNguoiDung.SelectedValue.ToString().Trim();
        Response.Redirect("~/Admin/MgerJoinGroupUser.aspx?NguoiDung=" + maNguoiDung);
    }
    protected void ddlNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maNhom = ddlNhomQuyen.SelectedValue.ToString().Trim();
        Response.Redirect("~/Admin/MgerJoinGroupUser.aspx?NhomQuyen=" + maNhom);
    }
    #endregion

    #region Xu ly them
    private void LoadPhanNguoiDung()
    {
        ddlChonNguoiDung.DataValueField = "IDNguoiDung";
        ddlChonNguoiDung.DataTextField = "TenDangNhap";
        ddlChonNguoiDung.DataSource = NguoiDung.LayTatCa();
        ddlChonNguoiDung.DataBind();
    }
    private void LoadPhanNhomNguoiDung()
    {
        ddlChonNhomQuyen.DataValueField = "IDNhom";
        ddlChonNhomQuyen.DataTextField = "TenNhom";
        ddlChonNhomQuyen.DataSource = NhomNguoiDung.LayTatCa();
        ddlChonNhomQuyen.DataBind();
    }
    public int KiemTraDieuKien()
    {
        int kq = 0;
        if (ddlChonNguoiDung.SelectedIndex == 0 || ddlChonNhomQuyen.SelectedIndex == 0)
        {
            lbtitle.Visible = true;
            lbtitle.Text = "Cần chọn người dùng và nhóm quyền để cấp quyền!";
            return kq;
        }
        else
        {
            return kq = 1;
        }
    }
    protected void refesh()
    {
        ddlChonNguoiDung.SelectedIndex = 0;
        ddlChonNhomQuyen.SelectedIndex = 0;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        lbrs.Visible = true;
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (KiemTraDieuKien() == 1)
        {
            int rs;
            PhanNhom data = new PhanNhom();
            data.IDNguoiDung = ConvertType.ToInt32(ddlChonNguoiDung.SelectedValue);
            data.IDNhom = ddlChonNhomQuyen.SelectedValue;
            data.NgayTao = "Giờ: " + DateTime.Now.ToShortTimeString() + " - Ngày: " + DateTime.Now.ToShortDateString();
            rs = PhanNhom.Them(data);
            if (rs > 0)
            {
                lbtitle.Visible = true;
                refesh();
                lbtitle.Text = "Phân quyền người dùng thành công!";
                CapNhatHanhDong("Thêm phân nhóm người dùng(id: " + rs + ")");
                lbrs.Text = "*Thêm Phân quyền thành công!";
                PopulateControls();
            }
            else
            {
                lbtitle.Visible = true;
                lbtitle.Text = "Phân quyền người dùng thất bại!";
                lbrs.Text = "*Thêm Phân quyền thất bại!";
            }
        }
        else
            lbrs.Text = "*Không thêm được phân quyền!";
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