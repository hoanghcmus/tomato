using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Help;
using DataAccess.Classes;

public partial class Admin_EditProduct : System.Web.UI.Page
{
    #region Load du lieu len web
    public static List<Img> album;
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "4" || item.ToString() == "5")
                kq = 1;
        }
        return kq;
    }
    protected void LoadEditor()
    {
        //Load CKFinder vao CKEditor
        txtChiTietVn.Language = "vi";
        txtChiTietEn.Language = "vi";
        txtChiTietRu.Language = "vi";
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "ckfinder";
        _FileBrowser.SetupCKEditor(txtChiTietVn);
        _FileBrowser.SetupCKEditor(txtChiTietEn);
        _FileBrowser.SetupCKEditor(txtChiTietRu);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            LoadEditor();
            if (!IsPostBack)
            {
                album = new List<Img>();
                //Load du lieu form
                LoadLoaiMenu();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void LoadLoaiMenu()
    {
        ddlLoaiMenu.DataValueField = "ID";
        ddlLoaiMenu.DataTextField = "TieuDe_Vn";
        ddlLoaiMenu.DataSource = TheLoai.LayTheoModule("4");
        ddlLoaiMenu.DataBind();
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
                MonAn data = MonAn.Single(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerProduct.aspx");
                //Dat ten trang web
                lbTitle01.Text = "Cập nhật món ăn ";
                lbTitle02.Text = "Cập nhật món ăn '" + id + "'";
                SetData(data);
            }
            else
            {
                lbTitle01.Text = "Thêm mới món ăn";
                lbTitle02.Text = "Thêm mới món ăn";
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region Luu San Pham
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
        btnaddimg.Click += new EventHandler(btnaddimg_Click);
        dlListImg.ItemCommand += new DataListCommandEventHandler(dlListImg_ItemCommand);
    }
    void dlListImg_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Deleteimg")
        {
            string s = e.CommandArgument.ToString();
            foreach (var item in album)
            {
                if (item.ID.ToString().CompareTo(s) == 0)
                {
                    album.Remove(item);
                    break;
                }
            }
            dlListImg.DataSource = album;
            dlListImg.DataBind();
        }
    }
    void btnaddimg_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        if (txtHinhAnh.Text != "")
        {
            int stt;
            if (album == null)
            {
                stt = 0;
                album = new List<Img>();
            }
            else
                stt = album.Count;
            Img dataimg = new Img();
            dataimg.ID = stt;
            dataimg.HinhAnh = txtHinhAnh.Text.Trim();
            album.Add(dataimg);
            dlListImg.DataSource = album;
            dlListImg.DataBind();
            txtHinhAnh.Text = "";
        }
        else
            lbhinhanh.Visible = true;
    }
    public int KiemTraDieuKien()
    {
        int kq = 0;
        lbNhapMoTa.Visible = false;
        if (Page.IsValid)
            kq = 1;
        else
            kq = 0;
        return kq;
    }
    private void ResetForm()
    {
        txtTieuDe_Vi.Text = "";
        txtTomTatVn.Text = "";
        txtChiTietVn.Text = "";

        txtTieuDe_En.Text = "";
        txtTieuDe_Ru.Text = "";
        txtTomTatEn.Text = "";

        txtTomTatRu.Text = "";
        txtChiTietEn.Text = "";
        txtChiTietRu.Text = "";

        txtHinhNho.Text = "";
        txtDonGia.Text = "";

        dlListImg.DataSource = album;
        dlListImg.DataBind();
    }
    private void SetData(MonAn data)
    {
        lblId.Text = data.ID.ToString();

        txtTieuDe_Vi.Text = data.TenMon_Vn;
        txtChiTietVn.Text = data.ChiTiet_Vn;
        txtTomTatVn.Text = data.MoTa_Vn;

        txtTieuDe_En.Text = data.TenMon_En;
        txtChiTietEn.Text = data.ChiTiet_En;
        txtTomTatEn.Text = data.MoTa_En;

        txtTieuDe_Ru.Text = data.TenMon_Ru;
        txtChiTietRu.Text = data.ChiTiet_Ru;
        txtTomTatRu.Text = data.MoTa_Ru;

        txtHinhNho.Text = data.AnhDaiDien;
        if (data.Gia <= 0)
            txtDonGia.Text = "0";
        else
            txtDonGia.Text = String.Format("{0:#.##}", data.Gia);
        ddlLoaiMenu.SelectedValue = data.MenuID.ToString();

        int idimg = 0;
        string listimg = data.HinhAnh;
        string[] str = listimg.Split('\'');
        foreach (var item in str)
        {
            if (item.ToString() != "")
            {
                Img dataimg = new Img();
                dataimg.ID = idimg;
                dataimg.HinhAnh = item.ToString();
                album.Add(dataimg);
                idimg++;
            }
        }
        dlListImg.DataSource = album;
        dlListImg.DataBind();
    }
    private MonAn GetData()
    {
        MonAn data = null;
        if (lblId.Text != "")
            data = MonAn.Single(lblId.Text);
        else
            data = new MonAn();

        data.TenMon_Vn = txtTieuDe_Vi.Text;
        data.MoTa_Vn = txtTomTatVn.Text;
        data.ChiTiet_Vn = txtChiTietVn.Text;

        data.TenMon_En = txtTieuDe_En.Text;
        data.MoTa_En = txtTomTatEn.Text;
        data.ChiTiet_En = txtChiTietEn.Text;

        data.TenMon_Ru = txtTieuDe_Ru.Text;
        data.MoTa_Ru = txtTomTatRu.Text;
        data.ChiTiet_Ru = txtChiTietRu.Text;

        data.AnhDaiDien = txtHinhNho.Text;
        data.Gia = Convert.ToDecimal(txtDonGia.Text);

        data.MenuID = ConvertType.ToInt32(ddlLoaiMenu.SelectedValue.Trim());
        string datalistimg = "";
        foreach (var item in album)
            datalistimg += item.HinhAnh + "'";
        data.HinhAnh = datalistimg;
        return data;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        //neu tat ca du lieu duoc nhap la hop le
        if (KiemTraDieuKien() == 1)
        {
            bool rs = false;
            //lay du lieu tu form
            MonAn data = GetData();
            //ID>0 ==> cap nhat va hien thong bao
            if (data.ID > 0)
            {
                rs = MonAn.Update(data);
                Label1.Text = rs ? "Cập nhật món ăn thành công!" : "Cập nhật món ăn thất bại!";
                if (rs)
                {
                    album = new List<Img>();
                    //lay du lieu moi nhat Db
                    data = MonAn.Single(lblId.Text);
                    SetData(data);
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Cập nhật món ăn (id: " + lblId.Text + ")");
                }
            }
            else
            {
                bool rst = MonAn.Add(data);
                if (rst)
                {
                    album = new List<Img>();
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Thêm món ăn (id: " + rst + ")");
                    //Thong bao them thanh cong
                    Label1.Text = "Thêm món ăn thành công!";
                    ResetForm();
                }
                else
                {
                    Label1.Text = "Thêm món ăn thất bại!";
                }
            }
        }
    }
    protected void valTieuDeVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTieuDeEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTieuDeRu_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTomTatVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 300)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTomTatEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 300)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTomTatRu_ServerValidate(object source, ServerValidateEventArgs args)
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