using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace Language
{
    public class LangResource
    {
        CultureInfo culture;
        ResourceManager rm;

        public LangResource(string cultureName)
        {
            if (cultureName.Equals(""))
            {
                culture = CultureInfo.CurrentCulture;
            }
            else
            {
                culture = CultureInfo.CreateSpecificCulture(cultureName);
            }
            rm = new ResourceManager("DataAccess.Lang.LangResource", typeof(LangResource).Assembly);

        }

        public string getText(string key)
        {
            return rm.GetString(key, culture);
        }
    }
}
