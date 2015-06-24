using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditTour : System.Web.UI.Page
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
    protected void LoadEditor()
    {
        //Load CKFinder vao CKEditor
        txtckeditor.Language = "vi";
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "ckfinder";
        _FileBrowser.SetupCKEditor(txtckeditor);
        _FileBrowser.SetupCKEditor(txtckeditor_En);
        _FileBrowser.SetupCKEditor(txtckeditor_Ru);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            LoadEditor();
            if (!IsPostBack)
            {
                //Load du lieu form
                LoadTour();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void LoadTour()
    {
        ddlTour.Items.Clear();
        ddlTour.Items.Add(new ListItem("-- Chọn theo thể loại --", "0"));
        var list = TheLoai.LayTheoModuleVaParentIsNull("5");
        foreach (var item in list)
        {
            ddlTour.Items.Add(new ListItem(item.TieuDe_Vn, item.ID.ToString()));
            var tl = TheLoai.LayTheoIDParent(item.ID.ToString());
            foreach (var itemtl in tl)
            {
                ddlTour.Items.Add(new ListItem("--- " + itemtl.TieuDe_Vn, itemtl.ID.ToString()));
            }
        }
    }
    private void PopulateControls()
    {
        try
        {
            string id = Request.QueryString["ID"] ?? "";
            //new co QueryString cid=> cap nhat Article
            if (id != "")
            {
                //lay Khao sat theo gia tri id
                Tour data = Tour.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerTour.aspx");
                //Dat ten trang web
                lbTitle01.Text = "Cập nhật tour";
                lbTitle02.Text = "Cập nhật tour '" + id + "'";
                SetData(data);
            }
            else
            {
                lbTitle01.Text = "Thêm tour mới";
                lbTitle02.Text = "Thêm tour mới";
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region Kiem tra du lieu
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    public int KiemTraDieuKien()
    {
        int kq = 1;
        if (Page.IsValid)
        {
            if (txtckeditor.Text == "")
            {
                Label1.Text = "Chưa nhập chi tiết tour (Tiếng Việt)!";
                kq = 0;
            }

            if (txtckeditor_En.Text == "")
            {
                Label1.Text = "Chưa nhập chi tiết tour (Tiếng Anh)!";
                kq = 0;
            }

            if (txtckeditor_Ru.Text == "")
            {
                Label1.Text = "Chưa nhập chi tiết tour (Tiếng Nga)!";
                kq = 0;
            }

            return kq;
        }
        else
            return kq = 0;
    }
    protected void valComments_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 60)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void vallichtrinh_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 100)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    #endregion

    #region Luu Bai Viet
    private void ResetForm()
    {
        txtTieuDe.Text = "";
        txtTieuDe_En.Text = "";
        txtTieuDe_Ru.Text = "";

        txtGiaTour.Text = "";

        txtPhuongTien.Text = "";
        txtPhuongTien_En.Text = "";
        txtPhuongTien_Ru.Text = "";

        txtKhuyenMai.Text = "";
        txtKhuyenMai_En.Text = "";
        txtKhuyenMai_Ru.Text = "";

        txtlichtrinh.Text = "";
        txtlichtrinh_En.Text = "";
        txtlichtrinh_Ru.Text = "";

        txtngaykhoihanh.Text = "";
        txtThoiGian.Text = "";

        txtKhachSan.Text = "";
        txtKhachSan_En.Text = "";
        txtKhachSan_Ru.Text = "";

        txtckeditor.Text = "";
        txtckeditor_En.Text = "";
        txtckeditor_Ru.Text = "";
        txtHinhAnh.Text = "";
        ckbTrangChu.Checked = false;
        ckbKhuyenMai.Checked = false;
    }
    private void SetData(Tour data)
    {
        lblId.Text = data.ID.ToString();
        txtTieuDe.Text = data.TenTour;
        txtTieuDe_En.Text = data.TenTour_En;
        txtTieuDe_Ru.Text = data.TenTour_Ru;

        txtGiaTour.Text = data.GiaTour.ToString();

        txtPhuongTien.Text = data.PhuongTien;
        txtPhuongTien_En.Text = data.PhuongTien_En;
        txtPhuongTien_Ru.Text = data.PhuongTien_Ru;

        txtKhuyenMai.Text = data.KhuyenMai;
        txtKhuyenMai_En.Text = data.KhuyenMai_En;
        txtKhuyenMai_Ru.Text = data.KhuyenMai_Ru;

        txtlichtrinh.Text = data.LichTrinh;
        txtlichtrinh_En.Text = data.LichTrinh_En;
        txtlichtrinh_Ru.Text = data.LichTrinh_Ru;

        txtngaykhoihanh.Text = data.NgayKhoiHanh;
        txtThoiGian.Text = data.ThoiGian;

        txtKhachSan.Text = data.KhachSan;
        txtKhachSan_En.Text = data.KhachSan_En;
        txtKhachSan_Ru.Text = data.KhachSan_Ru;

        txtHinhAnh.Text = data.HinhAnh;
        txtckeditor.Text = data.ChiTiet;
        txtckeditor_En.Text = data.ChiTiet_En;
        txtckeditor_Ru.Text = data.ChiTiet_Ru;
        ddlTour.SelectedValue = data.IDTheLoai.ToString();
        if (data.TrangChu == true)
            ckbTrangChu.Checked = true;
        if (data.HienKhuyenMai == true)
            ckbKhuyenMai.Checked = true;
    }
    private Tour GetData()
    {
        Tour data = null;
        if (lblId.Text != "")
        {
            //lay thong tin cu tu Database de cap nhat
            data = Tour.LayTheoID(lblId.Text);
        }
        else
        {
            data = new Tour();//them moi
            data.NgayTao = DateTime.Now.ToShortDateString();
            data.NguoiTao = Session["TenDangNhap"].ToString();

        }
        data.TenTour = txtTieuDe.Text;
        data.TenTour_En = txtTieuDe_En.Text;
        data.TenTour_Ru = txtTieuDe_Ru.Text;

        data.GiaTour = ConvertType.ToInt32(txtGiaTour.Text);

        data.PhuongTien = txtPhuongTien.Text;
        data.PhuongTien_En = txtPhuongTien_En.Text;
        data.PhuongTien_Ru = txtPhuongTien_Ru.Text;

        data.KhuyenMai = txtKhuyenMai.Text;
        data.KhuyenMai_En = txtKhuyenMai_En.Text;
        data.KhuyenMai_Ru = txtKhuyenMai_Ru.Text;

        data.LichTrinh = txtlichtrinh.Text;
        data.LichTrinh_En = txtlichtrinh_En.Text;
        data.LichTrinh_Ru = txtlichtrinh_Ru.Text;

        data.NgayKhoiHanh = txtngaykhoihanh.Text;
        data.ThoiGian = txtThoiGian.Text;

        data.KhachSan = txtKhachSan.Text;
        data.KhachSan_En = txtKhachSan_En.Text;
        data.KhachSan_Ru = txtKhachSan_Ru.Text;

        data.HinhAnh = txtHinhAnh.Text;
        data.ChiTiet = txtckeditor.Text;
        data.ChiTiet_En = txtckeditor_En.Text;
        data.ChiTiet_Ru = txtckeditor_Ru.Text;
        data.HinhAnh = txtHinhAnh.Text;
        if (ckbTrangChu.Checked)
            data.TrangChu = true;
        else
            data.TrangChu = false;
        if (ckbKhuyenMai.Checked)
            data.HienKhuyenMai = true;
        else
            data.HienKhuyenMai = false;
        data.IDTheLoai = ConvertType.ToInt32(ddlTour.SelectedValue.Trim());
        return data;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        //neu tat ca du lieu duoc nhap la hop le
        if (KiemTraDieuKien() == 1)
        {
            bool rs = false;
            //lay du lieu tu form
            Tour data = GetData();
            //ID>0 ==> cap nhat va hien thong bao
            if (data.ID > 0)
            {
                rs = Tour.Sua(data);
                Label1.Text = rs ? "Cập nhật tour thành công!" : "Cập nhật tour thất bại!";
                if (rs)
                {
                    //lay du lieu moi nhat Db
                    data = Tour.LayTheoID(lblId.Text);
                    SetData(data);
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Cập nhật Tour (id: " + lblId.Text + ")");
                }
            }
            else
            {
                int rst = Tour.Them(data);
                if (rst > 0)
                {
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Thêm tour (id: " + rst + ")");
                    //Thong bao them thanh cong
                    Label1.Text = "Thêm tour thành công!";
                    ResetForm();
                }
                else
                {
                    Label1.Text = "Thêm tour thất bại!";
                }
            }
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