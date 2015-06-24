using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using DataAccess.StringUtil;
using MultipleLanguage;

public partial class Vn_Contact : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            captchaImage.ImageUrl = new CaptchaProvider().CreateCaptcha();

            //int howManyPages = 0;
            //string tinhTrang = "1";
            //string firstPageUrl = "";
            //string pagerFormat = "";
            //string Trang = Request.QueryString["Page"] ?? "1";
            //List<LienHe> listHoiDap = LienHe.LayTheoTrangThai(tinhTrang, Trang, out howManyPages);

            //if (listHoiDap != null)
            //{
            //    rptHoiDap.DataSource = listHoiDap;
            //    rptHoiDap.DataBind();

            //    firstPageUrl = DataAccess.Connect.Link.HoiDap_Vn(tinhTrang);
            //    pagerFormat = DataAccess.Connect.Link.HoiDap_Vn(tinhTrang, "{0}");
            //}


            //pagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerFormat, true);
        }
    }
    protected void refesh()
    {
        txtDiaChi.Text = "";
        txtHoTen.Text = "";
        txtEmail.Text = "";
        txtTieuDe.Text = "";
        txtNoiDung.Text = "";
        txtInputString.Text = "";
    }
    protected void btnbtnGui_Click(object sender, EventArgs e)
    {
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (Page.IsValid)
        {
            CaptchaProvider captchaPro = new CaptchaProvider();
            if (captchaPro.IsValidCode(txtInputString.Text))
            {
                lbcapcha.Visible = false;
                bool rs = false;
                LienHe data = new LienHe();
                data.HoTen = txtHoTen.Text;
                data.Email = txtEmail.Text;
                data.TieuDe = txtTieuDe.Text;
                data.NoiDung = txtNoiDung.Text;
                data.DiaChi = txtDiaChi.Text;
                data.NgayGui = DateTime.Now;
                data.TrangThai = 0;
                data.TheLoai = 1;
                rs = LienHe.Them(data);
                if (rs)
                {
                    succesfull.Visible = true;
                    refesh();
                    succesfull.Text = "Sent Successfull!";
                }
                else
                {
                    succesfull.Visible = true;
                    succesfull.Text = "Failed send!";
                }
            }
            else
            {
                lbcapcha.Visible = true;
                succesfull.Visible = false;
                lbcapcha.Text = "Incorrect code!";
            }
        }
    }
    protected void btnRedefine_Click(object sender, EventArgs e)
    {
        //Response.Redirect(this.Request.Url.AbsoluteUri);
        captchaImage.ImageUrl = new CaptchaProvider().CreateCaptcha();
    }

    public string Showinfo(object input, string colunmName)
    {
        LienHe data = input as LienHe;
        switch (colunmName)
        {
            case "ngaygui":
                return data.NgayGui.ToString().Split(' ').First().ToString();
            case "hienthilink":
                return "/hoi-dap/chi-tiet-hoi-dap-" + data.ID.ToString() + ".html";
            case "laytomtat":
                if (data.NoiDung.Length < 300) { return Regex.Replace(data.NoiDung, "<img.*?>", ""); }
                else
                {
                    return StringUltility.GetStringByLenght(Regex.Replace(data.NoiDung, "<img.*?>", ""), 300) + "...";
                }
            default:
                return "";
        }
    }
}