using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditMenu : System.Web.UI.Page
{
    #region Load du lieu len web
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "2")
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
                LoadMenu();
                LoadModule();
                PopulateControls();
            }
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
                TheLoai data = TheLoai.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerMenu.aspx");
                lbtitle.Text = "Cập nhật thể loại";
                SetData(data);
            }
            else
                lbtitle.Text = "Thêm thể loại mới";
        }
        catch (Exception)
        {
        }
    }

    private void LoadTheLoai()
    {
        ddlParent.Items.Clear();
        ddlParent.Items.Add(new ListItem("-- Chọn thể loại bài viết cần thêm --", "0"));
        List<TheLoai> list = TheLoai.LayTheoModuleVaParentIsNull("1");
        foreach (var item in list)
        {
            ddlParent.Items.Add(new ListItem("* " + item.TieuDe_Vn, item.ID.ToString()));
            List<TheLoai> tl = TheLoai.LayTheoIDParent(item.ID.ToString());
            foreach (var itemtl in tl)
            {
                ddlParent.Items.Add(new ListItem("--- " + itemtl.TieuDe_Vn, itemtl.ID.ToString()));
            }
        }
    }

    private void LoadParent()
    {
        ddlParent.Items.Clear();
        ddlParent.Items.Add(new ListItem("-- Chọn thể loại bài viết cần thêm --", "0"));
        BuildParentList(0, 0);
    }

    protected void BuildParentList(int id, int count)
    {
        List<TheLoai> listTheLoai = TheLoai.TheLoai_GetByCategoryAndParentID("1", id);
        if (listTheLoai.Count() != 0)
        {
            foreach (TheLoai theLoai in listTheLoai)
            {

                if (hasRow(theLoai.ID))
                {
                    ddlParent.Items.Add(new ListItem(echoGach(count) + theLoai.TieuDe_Vn, theLoai.ID.ToString()));
                    BuildParentList(theLoai.ID, count++);
                }
                else
                {
                    ddlParent.Items.Add(new ListItem(echoGach(count) + theLoai.TieuDe_Vn, theLoai.ID.ToString()));
                }
            }
        }

    }

    private bool hasRow(int menuItemID)
    {

        bool value = false;
        List<TheLoai> theLoais = TheLoai.COUNT_ON_THELOAI(menuItemID);
        if (theLoais.Count() != 0)
        {
            value = true;
        }

        return value;
    }

    private string echoGach(int lenght)
    {
        string chuoiGach = "";
        for (int i = 0; i < lenght; i++)
        {
            chuoiGach += "-";
        }
        return chuoiGach;
    }

    private void LoadMenu()
    {
        ddlLoadMenu.DataValueField = "ID";
        ddlLoadMenu.DataTextField = "TenLoai";
        ddlLoadMenu.DataSource = LoaiMenu.LayTatCa();
        ddlLoadMenu.DataBind();
    }
    private void LoadParent(string idParent)
    {
        ddlParent.DataValueField = "ID";
        ddlParent.DataTextField = "TieuDe_Vn";
        ddlParent.DataSource = TheLoai.LayTheoLoaiMenuVaParentIsNull(idParent);
        ddlParent.DataBind();
    }
    private void LoadModule()
    {
        ddlModule.DataValueField = "ID";
        ddlModule.DataTextField = "TenLoai";
        ddlModule.DataSource = Module.LayTatCa();
        ddlModule.DataBind();
    }
    private void SetData(TheLoai data)
    {
        //LoadParent(data.IDLoaiMenu.ToString());
        //LoadTheLoai();
        LoadParent();
        lblId.Text = data.ID.ToString();
        txtTieuDeVn.Text = data.TieuDe_Vn;
        txtTieuDeEn.Text = data.TieuDe_En;
        txtTieuDeRu.Text = data.TieuDe_Ru;

        txtmoTaVn.Text = data.MoTa_Vn;
        txtmoTaEn.Text = data.MoTa_En;
        txtmoTaRu.Text = data.MoTa_Ru;

        txtHinhAnh.Text = data.HinhAnh;
        txtDuongDanVn.Text = data.DuongDan_Vn;
        txtDuongDanEn.Text = data.DuongDan_En;
        txtDuongDanRu.Text = data.DuongDan_Ru;

        if (data.ViTri < 0)
            txtViTri.Text = "0";
        txtViTri.Text = data.ViTri.ToString();
        ddlParent.SelectedValue = data.IDParent.ToString();
        ddlLoadMenu.SelectedValue = data.IDLoaiMenu.ToString();
        ddlModule.SelectedValue = data.IDModule.ToString();
    }
    #endregion

    #region Xu ly xu kien
    private void ResetForm()
    {
        txtTieuDeVn.Text = "";
        txtTieuDeEn.Text = "";
        txtTieuDeRu.Text = "";

        txtmoTaVn.Text = "";
        txtmoTaEn.Text = "";
        txtmoTaRu.Text = "";

        txtHinhAnh.Text = "";
        txtDuongDanVn.Text = "";
        txtDuongDanEn.Text = "";
        txtDuongDanRu.Text = "";
    }
    private TheLoai GetData()
    {
        TheLoai data = null;
        if (lblId.Text != "")
            data = TheLoai.LayTheoID(lblId.Text);//cap nhat voi thong tin cu
        else
            data = new TheLoai();//them moi
        data.TieuDe_Vn = txtTieuDeVn.Text;
        data.TieuDe_En = txtTieuDeEn.Text;
        data.TieuDe_Ru = txtTieuDeRu.Text;
        data.TieuDe_Cn = "";

        data.MoTa_Vn = txtmoTaVn.Text;
        data.MoTa_En = txtmoTaEn.Text;
        data.MoTa_Ru = txtmoTaRu.Text;
        data.MoTa_Cn = "";

        data.HinhAnh = txtHinhAnh.Text;
        data.DuongDan_Vn = txtDuongDanVn.Text;
        data.DuongDan_En = txtDuongDanEn.Text;
        data.DuongDan_Ru = txtDuongDanRu.Text;
        data.DuongDan_Cn = "";

        data.ViTri = ConvertType.ToInt32(txtViTri.Text.Trim());
        data.IDLoaiMenu = ConvertType.ToInt32(ddlLoadMenu.SelectedValue.Trim());
        data.IDModule = ConvertType.ToInt32(ddlModule.SelectedValue.Trim());
        int idparent = ConvertType.ToInt32(ddlParent.SelectedValue.Trim());
        if (idparent > 0)
            data.IDParent = idparent;
        data.Footer = true;
        return data;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        TheLoai data = GetData();
        int idparent = ConvertType.ToInt32(ddlParent.SelectedValue.Trim());
        int rst = 0;
        if (data.ID > 0)
        {
            if (idparent > 0)
                rst = TheLoai.SuaYesParent(data);
            else
                rst = TheLoai.SuaNoParent(data);
            if (rst > 0)
            {
                CapNhatHanhDong("Cập nhật thể loại (id: " + rst + ")");
                Label1.Text = "Cập nhật thể loại thành công!";
            }
            else
                Label1.Text = "Cập nhật thể loại thất bại!";
        }
        else
        {
            if (idparent > 0)
                rst = TheLoai.ThemYesIDParent(data);
            else
                rst = TheLoai.ThemNoIDParent(data);
            if (rst > 0)
            {
                CapNhatHanhDong("Thêm thể loại (id: " + rst + ")");
                Label1.Text = "Thêm thể loại thành công!";
                ResetForm();
            }
            else
                Label1.Text = "Thêm thể loại thất bại!";
        }
    }
    protected void ddlLoadMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idLoaiMenu = ddlLoadMenu.SelectedValue;
        if (idLoaiMenu.CompareTo("0") != 0)
        {
            ddlParent.Items.Clear();
            ddlParent.Items.Add(new ListItem("----- Chọn menu parent -----", "0"));
            ddlParent.DataValueField = "ID";
            ddlParent.DataTextField = "TieuDe_Vn";
            ddlParent.DataSource = TheLoai.LayTheoLoaiMenuVaParentIsNull(idLoaiMenu);
            ddlParent.DataBind();
        }
    }
    protected void valTieuDeVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 50)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTieuDeEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 50)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTieuDeRu_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 50)
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
    protected void valmotaEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
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
    protected void valDuongDanVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 200)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valDuongDanEn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 200)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valDuongDanRu_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 200)
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