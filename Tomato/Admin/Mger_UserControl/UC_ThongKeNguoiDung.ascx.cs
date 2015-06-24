using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_Mger_UserControl_UC_ThongKeNguoiDung : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    private void PopulateControls()
    {
        lbSoNguoiDung.Text = NguoiDung.Dem().ToString();
        lbQuanTri.Text = PhanNhom.DemTheoNhom("Nhom01").ToString();
        lbThanhPhan.Text = PhanNhom.DemTheoNhom("Nhom02").ToString();
        lbNguoiDung.Text = PhanNhom.DemTheoNhom("Nhom03").ToString();
        lbThongTin.Text = PhanNhom.DemTheoNhom("Nhom04").ToString();
    }
}