using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditSlideShow : System.Web.UI.Page
{
    #region Load du lieu len web
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
        try
        {
            string id = Request.QueryString["ID"] ?? "";
            //new co QueryString cid=> cap nhat Article
            if (id != "")
            {
                SlideShow data = SlideShow.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerLink.aspx");
                lbtitle.Text = "Cập nhật hình ảnh hiển thị trang chủ";
                SetData(data);
            }
            else
                lbtitle.Text = "Thêm mới hình ảnh hiển thị trang chủ";
        }
        catch (Exception)
        {
        }
    }
    private void SetData(SlideShow data)
    {
        lblId.Text = data.ID.ToString();
        txtTieuDeVn.Text = data.TieuDe_Vn;
        txtMota.Text = data.MoTa;
        txtHinhAnh.Text = data.HinhAnh;
        txtViTri.Text = data.ViTri.ToString();
        ddlLoadMenu.SelectedValue = data.HienThi.ToString();
    }
    #endregion

    #region Xu ly xu kien
    private void ResetForm()
    {
        txtTieuDeVn.Text = "";
        txtHinhAnh.Text = "";
        txtMota.Text = "";
        txtViTri.Text = "";
    }
    private SlideShow GetData()
    {
        SlideShow data = null;
        if (lblId.Text != "")
            data = SlideShow.LayTheoID(lblId.Text);//cap nhat voi thong tin cu
        else
            data = new SlideShow();//them moi
        data.TieuDe_Vn = txtTieuDeVn.Text;
        data.TieuDe_En = txtTieuDeVn.Text;
        data.TieuDe_Ru = txtTieuDeVn.Text;
        data.HinhAnh = txtHinhAnh.Text;
        data.MoTa = txtMota.Text;
        data.ViTri = ConvertType.ToInt32(txtViTri.Text);
        data.HienThi = ConvertType.ToInt32(ddlLoadMenu.SelectedValue.Trim());
        return data;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        SlideShow data = GetData();
        bool rst = false;
        int rs = 0;
        if (data.ID > 0)
        {
            rst = SlideShow.Sua(data);
            if (rst)
            {
                CapNhatHanhDong("Cập nhật hình ảnh hiển thị trang chủ (id: " + rst + ")");
                Label1.Text = "Cập nhật hình ảnh thành công!";
            }
            else
                Label1.Text = "Cập nhật hình ảnh thất bại!";
        }
        else
        {

            rs = SlideShow.Them(data);
            if (rs > 0)
            {
                CapNhatHanhDong("Thêm hình ảnh (id: " + rst + ")");
                Label1.Text = "Thêm hình ảnh thành công!";
                ResetForm();
            }
            else
                Label1.Text = "Thêm hình ảnh thất bại!";
        }
    }
    protected void valTieuDeVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valMoTa_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 300)
            args.IsValid = false;
        else
            args.IsValid = true;
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