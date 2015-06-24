using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using DataAccess.Classes;

public partial class Admin_Login : System.Web.UI.Page
{
    #region xu ly dang nhap
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDangNhap.Click += new EventHandler(btnDangNhap_Click);
    }
    void btnDangNhap_Click(object sender, EventArgs e)
    {
        if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            NguoiDung data = NguoiDung.KiemTraDangNhap(tenDangNhap, matKhau);
            if (data != null)
            {
                NguoiDung dataThongTin = NguoiDung.LayThongTinDangNhap(data.IDNguoiDung.ToString());
                Session["IDNguoiDung"] = dataThongTin.IDNguoiDung;
                Session["TenDangNhap"] = dataThongTin.TenDangNhap;
                Session["TenNguoiDung"] = dataThongTin.TenNguoiDung;
                string quyenHan = "";
                List<PhanNhom> listphannhom = PhanNhom.LayTheoMaNguoiDung(data.IDNguoiDung.ToString());
                if (listphannhom.Count != 0)
                {
                    foreach (var item in listphannhom)
                    {
                        quyenHan += item.QuyenHan.ToString() + ",";
                    }
                    Session["QuyenHan"] = quyenHan;
                    //Them thong tin dang nhap
                    DangNhap dangNhap = new DangNhap();
                    dangNhap.IDNguoiDung = dataThongTin.IDNguoiDung;
                    dangNhap.DiaChiIP = GetIPAddress();
                    dangNhap.ThoiGian = DateTime.Now.ToLongDateString();
                    dangNhap.HanhDong = "Hành động đăng nhập: ";
                    int rs = DangNhap.Them(dangNhap);
                    if (rs > 0)
                    {
                        Session["IDDangNhap"] = rs;
                        Session["HanhDongDangNhap"] = "Hành động đăng nhập: ";
                    }
                    Response.Redirect("~/Admin/Admin.aspx");
                }
                else
                    Response.Redirect("~/Default.aspx");
            }
            else
                lbtitle.Text = "Kiểm tra lại tên đăng nhập hoặc mật khẩu!";
        }
        else
            lbtitle.Text = "Vui lòng đăng nhập để sử dụng hệ thống!";
    }
    #endregion

    #region Get Ip
    private static string GetIPAddress()
    {
        try
        {
            string host = "";
            if (System.ServiceModel.OperationContext.Current != null)
            {
                var endpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                return endpoint.Address;
            }
            if (System.Web.HttpContext.Current != null)
            {
                // Check proxied IP address
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    return host += HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] + " via " +
                        HttpContext.Current.Request.UserHostAddress;
                else
                    return host += HttpContext.Current.Request.UserHostAddress;

            }
        }
        catch { }
        return "Unknown";
    }
    public static string Toipaddress()
    {
        try
        {
            int nIP = 0;
            string ip = "HostName: ";
            // Get host name
            String strHostName = Dns.GetHostName();
            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            ip += strHostName + " && IP";
            // Enumerate IP addresses
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                ip += ++nIP + ": " + ipaddress.ToString();
            }
            return ip;
        }
        catch (Exception)
        {
            return "Unknown";
        }
    }
    #endregion
}