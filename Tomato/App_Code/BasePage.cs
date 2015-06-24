using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

namespace MultipleLanguage
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {
                Session["lang"] = Request["lang"];
            }

            string lang = Convert.ToString(Session["lang"]);
            string culture = string.Empty;
            if (lang.ToLower().CompareTo("vn") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "vi-VN";
            }
            if (lang.ToLower().CompareTo("en") == 0)
            {
                culture = "en-US";
            }
            if (lang.ToLower().CompareTo("ru") == 0)
            {
                culture = "ru-RU";
            }
            if (lang.ToLower().CompareTo("cn") == 0)
            {
                culture = "zh-CN";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }
}