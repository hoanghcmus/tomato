using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_Mger_UserControl_UC_ThongKeKhac : System.Web.UI.UserControl
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
        //lbshopping.Text = LienHe.Dem().ToString();
        lbOrder1.Text = DatPhong.DemTheoTrangThai("0").ToString();
        lbOrder2.Text = DatPhong.DemTheoTrangThai("1").ToString();
        lbOrder.Text = DatPhong.Dem().ToString();
    }
}