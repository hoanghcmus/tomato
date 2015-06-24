using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerSupport : System.Web.UI.Page
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
        repProd.DataSource = HoTro.LayTatCa();
        repProd.DataBind();
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
        repProd.ItemCommand += new RepeaterCommandEventHandler(repProd_ItemCommand);
    }

    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Updata")
        {
            HoTro dataimg = new HoTro();
            TextBox txtfrmTenVn = (TextBox)e.Item.FindControl("txtfrmTenVn");
            dataimg.Ten_Vn = txtfrmTenVn.Text.Trim().ToString();
            TextBox txtfrmTenEn = (TextBox)e.Item.FindControl("txtfrmTenEn");
            dataimg.Ten_En = txtfrmTenEn.Text.Trim().ToString();
            TextBox txtfrmTenRu = (TextBox)e.Item.FindControl("txtfrmTenRu");
            dataimg.Ten_Ru = txtfrmTenRu.Text.Trim().ToString();

            TextBox txtfrmSDT = (TextBox)e.Item.FindControl("txtfrmSDT");
            dataimg.SDT = txtfrmSDT.Text.Trim().ToString();
            dataimg.ID = ConvertType.ToInt32(e.CommandArgument.ToString().Trim());
            HoTro.Sua(dataimg);
            CapNhatHanhDong("Sửa Hổ trợ (id: " + e.CommandArgument.ToString().Trim() + ")");
        }
        if (e.CommandName == "Delete")
        {
            string s = e.CommandArgument.ToString();
            HoTro.Xoa(s.ToString());
            CapNhatHanhDong("Xóa hỗ trợ (id: " + s[0].ToString() + ")");
        }
        PopulateControls();
    }
    #endregion

    #region Xu ly them
    public int KiemTraDieuKien()
    {
        int kq = 0;
        if (txtNhapTenVn.Text == "" || txtNhapTenEn.Text == "" || txtSDT.Text == "")
        {
            lbrs.Visible = true;
            lbrs.Text = "Cần nhập đầy đủ thông tin để thêm!";
            kq = 0;
        }
        else
        {
            if (txtNhapTenVn.Text.Length <= 100 || txtNhapTenEn.Text.Length <= 100 || txtNhapTenRu.Text.Length <= 100)
            {
                if (txtSDT.Text.Length <= 15)
                {
                    kq = 1;
                    lbrs.Visible = false;
                }
                else
                {
                    kq = 0;
                    lbrs.Visible = true;
                    lbrs.Text = "SĐT > 15 ký tự";
                }
            }
            else
            {
                kq = 0;
                lbrs.Visible = true;
                lbrs.Text = "Tên không được > 100 ký tự";
            }
        }
        return kq;
    }
    protected void refesh()
    {
        txtNhapTenVn.Text = "";
        txtNhapTenEn.Text = "";
        txtNhapTenRu.Text = "";

        txtSDT.Text = "";
        txtNhapMoTa.Text = "";
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        lbtitle.Visible = true;
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (KiemTraDieuKien() == 1)
        {
            bool rs = false;
            HoTro data = new HoTro();
            data.Ten_Vn = txtNhapTenVn.Text;
            data.Ten_En = txtNhapTenEn.Text;
            data.Ten_Ru = txtNhapTenRu.Text;
            data.Ten_Cn = "";

            data.SDT = txtSDT.Text;
            data.Khac = txtNhapMoTa.Text;
            rs = HoTro.Them(data);
            if (rs)
            {
                refesh();
                PopulateControls();
                lbtitle.Text = " *Thêm hỗ trợ thành công!";
                CapNhatHanhDong("Thêm hỗ trợ(id: " + data.ID + ")");
            }
            else
                lbtitle.Text = " *Thêm hỗ trợ thất bại!";
        }
        else
            lbtitle.Text = " *Không thêm được hỗ trợ";
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