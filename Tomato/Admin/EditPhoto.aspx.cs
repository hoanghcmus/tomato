using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_EditPhoto : System.Web.UI.Page
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
            {
                album = new List<Img>();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        string id = Request.QueryString["ID"] ?? "";
        if (id != "")
        {
            ImageAndClips data = ImageAndClips.LayTheoID(id);
            if (data == null)
                Response.Redirect("~/Admin/MgerPhoto.aspx");
            lbTitle01.Text = "Cập nhật album";
            lbTitle02.Text = "Cập nhật album '" + id + "'";
            lbtitle.Text = "Cập nhật album '" + id + "'";
            SetData(data);
        }
        else
        {
            lbtitle.Text = "Thêm album mới";
        }
    }
    #endregion

    #region Det Data - Set Data
    private void SetData(ImageAndClips data)
    {
        txtTenVn.Text = data.Ten_Vn;
        txtTenEn.Text = data.Ten_En;
        txtTenRu.Text = data.Ten_Ru;


        txtmoTaVn.Text = data.MoTa_Vn;
        txtmoTaEn.Text = data.MoTa_En;
        txtmoTaRu.Text = data.MoTa_Ru;


        lblId.Text = data.ID.ToString();
        int idimg = 0;
        string listimg = data.ImgOrClip;
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
    private ImageAndClips GetData()
    {
        ImageAndClips data = null;
        if (lblId.Text != "")
            data = ImageAndClips.LayTheoID(lblId.Text);//lay thong tin cu cap nhat
        else
            data = new ImageAndClips();//Them moi
        data.Ten_Vn = txtTenVn.Text;
        data.Ten_En = txtTenEn.Text;
        data.Ten_Ru = txtTenRu.Text;
        data.Ten_Cn = "";

        data.MoTa_Vn = txtmoTaVn.Text;
        data.MoTa_En = txtmoTaEn.Text;
        data.MoTa_Ru = txtmoTaRu.Text;
        data.MoTa_Cn = "";

        data.IDTheLoai = 6;
        data.NgayTao = DateTime.Now.ToShortDateString();
        string datalistimg = "";
        foreach (var item in album)
            datalistimg += item.HinhAnh + "'";
        data.ImgOrClip = datalistimg;
        return data;
    }
    #endregion

    #region Xu ly xu kien
    private void ResetForm()
    {
        txtTenVn.Text = "";
        txtTenEn.Text = "";
        txtTenRu.Text = "";

        txtmoTaVn.Text = "";
        txtmoTaEn.Text = "";
        txtmoTaRu.Text = "";


        txtHinhAnh.Text = "";
        dlListImg.DataSource = null;
        dlListImg.DataBind();
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
        btnaddimg.Click += new EventHandler(btnaddimg_Click);
        dlListImg.ItemCommand += new DataListCommandEventHandler(dlListImg_ItemCommand);
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
    void btnLuu_Click(object sender, EventArgs e)
    {
        lbhinhanh.Visible = false;
        if (album.Count <= 2 || album == null)
            Label1.Text = "Vui lòng chọn ít nhất 3 ảnh cho album";
        else
        {
            bool rs = false;
            //lay du lieu tu form
            ImageAndClips data = GetData();
            //ID>0 ==> cap nhat va hien thong bao
            if (data.ID > 0)
            {
                rs = ImageAndClips.Sua(data);
                Label1.Text = rs ? "Cập nhật album thành công!" : "Cập nhật album thất bại!";
                if (rs)
                {
                    album = new List<Img>();
                    //lay du lieu moi nhat Db
                    data = ImageAndClips.LayTheoID(lblId.Text);
                    SetData(data);
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Cập nhật album (id: " + lblId.Text + ")");
                }
            }
            else
            {
                int rst = ImageAndClips.Them(data);
                if (rst > 0)
                {
                    album = new List<Img>();
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Thêm album (id: " + rst + ")");
                    //Thong bao them thanh cong
                    Label1.Text = "Thêm album thành công!";
                    ResetForm();
                }
                else
                {
                    Label1.Text = "Thêm album thất bại!";
                }
            }
        }
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