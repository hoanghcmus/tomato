using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_Mger_UserControl_UC_ThongKeBaiViet : System.Web.UI.UserControl
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
        lbTongBaiViet.Text = BaiViet.DemTheoModule("1").ToString();
        lbnotice.Text = Phong.Count().ToString();
        lbalbum.Text = ImageAndClips.DemTheoTheLoai("14").ToString();
        lbletter.Text = LienHe.DemTheoTheLoai(2).ToString();
    }
}