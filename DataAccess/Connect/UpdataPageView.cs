using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DataAccess.Connect
{
    public class UpdataPageView
    {
        public static void UpdataMetagOpenGraph(System.Web.UI.Control PageView, string title, string des, string url, string img, string type)
        {
            if (title.Trim() == "")
                PageView.Page.Title = ConfigurationManager.AppSettings["title"];
            else
                PageView.Page.Title = title + " | " + ConfigurationManager.AppSettings["title"];

            HtmlMeta tagTitle = new HtmlMeta();
            tagTitle.Attributes.Add("property", "og:title");
            if (title.Trim() == "")
                title = ConfigurationManager.AppSettings["og_title"];
            tagTitle.Content = title;
            PageView.Page.Header.Controls.Add(tagTitle);

            HtmlMeta tagDes = new HtmlMeta();
            tagDes.Attributes.Add("property", "og:description");
            if (des.Trim() == "")
                des = ConfigurationManager.AppSettings["og_description"];
            tagDes.Content = des;
            PageView.Page.Header.Controls.Add(tagDes);

            HtmlMeta tagurl = new HtmlMeta();
            tagurl.Attributes.Add("property", "og:url");
            if (url.Trim() == "")
                url = ConfigurationManager.AppSettings["og_url"];
            tagurl.Content = url;
            PageView.Page.Header.Controls.Add(tagurl);

            HtmlMeta tagimg = new HtmlMeta();
            tagimg.Attributes.Add("property", "og:image");
            if (img.Trim() == "")
                img = ConfigurationManager.AppSettings["og_img"];
            else
                img = ".." + img;
            tagimg.Content = img;
            PageView.Page.Header.Controls.Add(tagimg);

            HtmlMeta tagtype = new HtmlMeta();
            tagtype.Attributes.Add("property", "og:type");
            if (type.Trim() == "")
                type = ConfigurationManager.AppSettings["og_type"];
            tagtype.Content = type;
            PageView.Page.Header.Controls.Add(tagtype);
        }
        public static void UpdataMetagMainNoTitle(System.Web.UI.Control PageView)
        {
            HtmlMeta tagAuthor = new HtmlMeta();
            tagAuthor.Attributes.Add("name", "author");
            tagAuthor.Content = ConfigurationManager.AppSettings["author"];
            PageView.Page.Header.Controls.Add(tagAuthor);

            HtmlMeta tagKeywords = new HtmlMeta();
            tagKeywords.Attributes.Add("name", "Keywords");
            tagKeywords.Content = ConfigurationManager.AppSettings["keywords"];
            PageView.Page.Header.Controls.Add(tagKeywords);

            HtmlMeta tagDescription = new HtmlMeta();
            tagDescription.Attributes.Add("name", "description");
            tagDescription.Content = ConfigurationManager.AppSettings["description"];
            PageView.Page.Header.Controls.Add(tagDescription);

            HtmlMeta tagImage = new HtmlMeta();
            tagImage.Attributes.Add("name", "image");
            tagImage.Content = ConfigurationManager.AppSettings["image"];
            PageView.Page.Header.Controls.Add(tagImage);
        }
        public static void UpdataMetagMainTitle(System.Web.UI.Control PageView, string title)
        {
            if (title.Trim() == "")
                title = ConfigurationManager.AppSettings["title"];
            else
                title = title + " | " + ConfigurationManager.AppSettings["title"];
            PageView.Page.Title = title;

            HtmlMeta tagAuthor = new HtmlMeta();
            tagAuthor.Attributes.Add("name", "author");
            tagAuthor.Content = ConfigurationManager.AppSettings["author"];
            PageView.Page.Header.Controls.Add(tagAuthor);

            HtmlMeta tagKeywords = new HtmlMeta();
            tagKeywords.Attributes.Add("name", "Keywords");
            tagKeywords.Content = ConfigurationManager.AppSettings["keywords"];
            PageView.Page.Header.Controls.Add(tagKeywords);

            HtmlMeta tagDescription = new HtmlMeta();
            tagDescription.Attributes.Add("name", "description");
            tagDescription.Content = ConfigurationManager.AppSettings["description"];
            PageView.Page.Header.Controls.Add(tagDescription);

            HtmlMeta tagImage = new HtmlMeta();
            tagImage.Attributes.Add("name", "image");
            tagImage.Content = ConfigurationManager.AppSettings["image"];
            PageView.Page.Header.Controls.Add(tagImage);
        }
    }
}
