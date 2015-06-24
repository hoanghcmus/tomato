using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Vn_Vn_Control_UC_Services : System.Web.UI.UserControl
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
        List<BaiViet> list = BaiViet.LayTheoIDTheLoaiTop2("3");
        if (list != null || list.Count > 0)
        {
            dlProdList.DataSource = list;
            dlProdList.DataBind();
        }
    }
}