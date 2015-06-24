using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;

public partial class En_TravelTour : System.Web.UI.Page
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

        TheLoai theLoaiLocalTour = TheLoai.LayTheoID("18");
        if (theLoaiLocalTour != null)
        {
            rptLocalTourList.DataSource = Tour.Tour_LayTheoTheLoai_NoPaggin("18");
            rptLocalTourList.DataBind();
        }

        TheLoai theLoaiGlobalTour = TheLoai.LayTheoID("19");
        if (theLoaiGlobalTour != null)
        {
            rptGlobalTour.DataSource = Tour.Tour_LayTheoTheLoai_NoPaggin("19");
            rptGlobalTour.DataBind();
        }


    }
}