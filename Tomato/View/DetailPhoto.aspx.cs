using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using MultipleLanguage;

public partial class Vn_DetailPhoto : BasePage
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
        string id = Request.QueryString["ID"];
        ImageAndClips data = ImageAndClips.LayTheoID(id);
        if (data != null)
        {
            if (Session["lang"].ToString().Equals("vn")) { ltrCtTitle.Text = data.Ten_Vn; }
            else if (Session["lang"].ToString().Equals("en")) { ltrCtTitle.Text = data.Ten_En; }
            else if (Session["lang"].ToString().Equals("ru")) { ltrCtTitle.Text = data.Ten_Ru; }

            List<Img> listimgs = new List<Img>();
            string listimg = data.ImgOrClip;
            string[] str = listimg.Split('\'');
            foreach (var item in str)
            {
                if (item.ToString() != "")
                {
                    Img dataimg = new Img();
                    dataimg.HinhAnh = item.ToString();
                    listimgs.Add(dataimg);
                }
            }
            dlListimages.DataSource = listimgs;
            dlListimages.DataBind();
        }
    }
}