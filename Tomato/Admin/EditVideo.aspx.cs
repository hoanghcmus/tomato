using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_EditVideo : System.Web.UI.Page
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
            if (id != "")
            {
                //lay Khao sat theo gia tri id
                ImageAndClips data = ImageAndClips.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerVideo.aspx");
                //Dat ten trang web
                lbTitle01.Text = "Cập nhật video";
                lbTitle02.Text = "Cập nhật video '" + id + "'";
                lbtitle.Text = "Cập nhật video '" + id + "'";
                SetData(data);
            }
            else
            {
                lbTitle01.Text = "Thêm video mới";
                lbtitle.Text = "Thêm video mới";
                lbTitle02.Text = "Thêm video mới";
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region Xu ly xu kien
    private void ResetForm()
    {
        txtTenVn.Text = "";
        txtmoTaVn.Text = "";
        txtTenEn.Text = "";
        txtmoTaEn.Text = "";
        txtTenRu.Text = "";
        txtmoTaRu.Text = "";
        txtAnhDaiDien.Text = "";
        txtHinhAnh.Text = "";
    }
    private void SetData(ImageAndClips data)
    {
        lblId.Text = data.ID.ToString();
        txtTenVn.Text = data.Ten_Vn;
        txtmoTaVn.Text = data.MoTa_Vn;
        txtTenEn.Text = data.Ten_En;
        txtmoTaEn.Text = data.MoTa_En;
        txtTenRu.Text = data.Ten_Ru;
        txtmoTaRu.Text = data.MoTa_Ru;
        txtAnhDaiDien.Text = data.HinhAnh;
        txtHinhAnh.Text = data.ImgOrClip;
    }
    private ImageAndClips GetData()
    {
        ImageAndClips data = null;
        if (lblId.Text != "")
        {
            //lay thong tin cu tu Database de cap nhat
            data = ImageAndClips.LayTheoID(lblId.Text);
            //cap nhat lai thoi gian chinh sua
            data.NgayTao = DateTime.Now.ToShortDateString();
        }
        else
        {
            data = new ImageAndClips();//them moi
            data.NgayTao = DateTime.Now.ToShortDateString();
        }
        data.Ten_Vn = txtTenVn.Text;
        data.MoTa_Vn = txtmoTaVn.Text;
        data.Ten_En = txtTenEn.Text;
        data.MoTa_En = txtmoTaEn.Text;
        data.Ten_Ru = txtTenRu.Text;
        data.MoTa_Ru = txtmoTaRu.Text;
        data.IDTheLoai = 18;
        data.NgayTao = DateTime.Now.ToShortDateString();
        data.HinhAnh = txtAnhDaiDien.Text;
        data.ImgOrClip = txtHinhAnh.Text;
        return data;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }

    void btnLuu_Click(object sender, EventArgs e)
    {
        bool rs = false;
        //lay du lieu tu form
        ImageAndClips data = GetData();
        //ID>0 ==> cap nhat va hien thong bao
        if (data.ID > 0)
        {
            rs = ImageAndClips.Sua(data);
            Label1.Text = rs ? "Cập nhật video thành công!" : "Cập nhật video thất bại!";
            if (rs)
            {
                //lay du lieu moi nhat Db
                data = ImageAndClips.LayTheoID(lblId.Text);
                SetData(data);
                //Cap nhat hanh dong dang nhap
                CapNhatHanhDong("Cập nhật video (id: " + lblId.Text + ")");
            }
        }
        else
        {
            int rst = ImageAndClips.Them(data);
            if (rst > 0)
            {
                //Cap nhat hanh dong dang nhap
                CapNhatHanhDong("Thêm video (id: " + rst + ")");
                //Thong bao them thanh cong
                Label1.Text = "Thêm video thành công!";
                ResetForm();
            }
            else
            {
                Label1.Text = "Thêm video thất bại!";
            }
        }
    }
    protected void valTenVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 100)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valmotaVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTenEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 100)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valmotaEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTenRu_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 100)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valmotaRu_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
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