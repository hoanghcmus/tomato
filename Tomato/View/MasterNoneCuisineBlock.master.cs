using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_MasterNoneCuisineBlock : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<TheLoai> listTL = TheLoai.LayTheoIDParent("3");
            if (listTL != null && listTL.Count != 0)
            {
                rptProduct.DataSource = listTL;
                rptProduct.DataBind();
            }
        }
    }
    protected string ShowMainMenu(object sender, string column)
    {
        TheLoai theloai = sender as TheLoai;

        switch (column)
        {
            case "MenuDuongDan":
                if (Session["lang"].ToString().Equals("vn")) { return theloai.DuongDan_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { return theloai.DuongDan_En; }
                else if (Session["lang"].ToString().Equals("ru")) { return theloai.DuongDan_Ru; }
                return theloai.DuongDan_Vn;

            case "MenuTieuDe":
                if (Session["lang"].ToString().Equals("vn")) { return theloai.TieuDe_Vn; }
                else if (Session["lang"].ToString().Equals("en")) { return theloai.TieuDe_En; }
                else if (Session["lang"].ToString().Equals("ru")) { return theloai.TieuDe_Ru; }
                return theloai.DuongDan_Vn;

            default: return "";
        }
    }
}
