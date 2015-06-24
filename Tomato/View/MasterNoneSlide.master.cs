using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using DataAccess.Classes;
using DataAccess.Language;
using Language;

public partial class En_MasterNoneSlide : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load first album
            LoadAlbum();
        }
    }

    private void LoadFirstAlbum()
    {
        ImageAndClips data = ImageAndClips.LayTheoID("10");
        if (data != null)
        {
            List<Img> listimgs = new List<Img>();
            string listimg = data.ImgOrClip;
            string[] str = listimg.Split('\'');
            int i = 1;
            foreach (var item in str)
            {
                if (item.ToString() != "")
                {
                    if (i <= 6)
                    {
                        Img dataimg = new Img();
                        dataimg.HinhAnh = item.ToString();
                        listimgs.Add(dataimg);
                    }
                    i++;
                }
            }
            //dlListimages.DataSource = listimgs;
            //dlListimages.DataBind();
        }
    }

    private void LoadAlbum()
    {
        ImageAndClips data = ImageAndClips.LayTheoID("2");
        if (data != null)
        {
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

            int j = 1;
            foreach (Img img in listimgs)
            {
                if (j == 1)
                {
                    ltrListImages.Text += "<li>";
                }
                ltrListImages.Text += "<div class='gallery-item'>"
                             + "<a class='highslide imgshow link' rel='main-gallery' href='" + img.HinhAnh + "'>"
                                 + "<img src='" + img.HinhAnh + "' alt='Picture' class='img' />"
                             + "</a>"
                          + "</div>";

                if (j == 2)
                {
                    ltrListImages.Text += "</li>";
                    j = 1;
                    continue;
                }
                j++;

            }
        }
    }

    public static int ImageAndClips_GetLastID()
    {
        try
        {
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("ImageAndClips_GetLastID"));
        }
        catch
        {
            return 0;
        }
    }

}
