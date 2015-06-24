using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class En_En_Control_UC_CheckRate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnReserv_Click(object sender, EventArgs e)
    {
        //lbBookingMess.Text = "Đặt bàn";
        int rs = 0;

        DatTiec data = new DatTiec();

        data.Ten = custumerName.Text;
        data.DiaChi = Address.Text;
        data.Email = Email.Text;
        data.SDT = Convert.ToInt32(Phone.Text.Trim());
        data.SoNguoi = Amount.Text;

        DateTime Ngay = DateTime.ParseExact(Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        data.Ngay = Ngay;
        data.Gio = Hour.Text;

        data.NgayGui = DateTime.Now;
        data.TrangThai = 0;

        rs = DatTiec.Them(data);
        if (rs > 0)
        {
            refesh();
            lbBookingMess.Text = "Đã đặt bàn, xin cảm ơn";
        }
        else
        {
            lbBookingMess.Text = "Không thể đặt bàn";
        }

    }
    
    protected void refesh()
    {
        custumerName.Text = String.Empty;
        Address.Text = String.Empty;
        Email.Text = String.Empty;
        Phone.Text = String.Empty;
        Amount.Text = String.Empty;
        Date.Text = String.Empty;
        Hour.Text = String.Empty;
        lbBookingMess.Text = string.Empty;
    }
}