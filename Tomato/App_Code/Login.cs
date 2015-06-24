using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccess.Classes;

/// <summary>
/// Summary description for Login
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Login : System.Web.Services.WebService
{

    public Login()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public bool KiemTraTenDangNhap(string tenDangNhap)
    {
        bool strResul = false;
        int test = NguoiDung.DemTenDangNhap(tenDangNhap);
        if (test != 0)
            strResul = true;
        return strResul;
    }

    [WebMethod]
    public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
    {
        bool strResul = false;
        NguoiDung data = NguoiDung.KiemTraDangNhap(tenDangNhap, matKhau);
        if (data != null)
        {
            strResul = true;
        }
        return strResul;
    }

}
