using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Vn_Vn_Control_UC_PhotoShow : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PopulateControls();
    }
    private void PopulateControls()
    {
        ImageAndClips dataimg = ImageAndClips.ImageAndClipsTop1("6");
        if (dataimg != null)
        {
            List<Img> showlistimgs = new List<Img>();
            string listimg = dataimg.ImgOrClip;
            string[] str = listimg.Split('\'');
            foreach (var item in str)
            {
                if (item.ToString() != "")
                {
                    Img itemimg = new Img();
                    itemimg.HinhAnh = item.ToString();
                    showlistimgs.Add(itemimg);
                }
            }
            dlNewsHot.DataSource = showlistimgs;
            dlNewsHot.DataBind();
        }
    }
}