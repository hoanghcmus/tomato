using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccess.Connect
{
    public class GlobalConfiguration
    {
        private static int pageSize4;
        public static int PageSize4
        {
            get { return pageSize4; }
        }
        private static int pageSize3;
        public static int PageSize3
        {
            get { return pageSize3; }
        }
        private static int pageSize2;
        public static int PageSize2
        {
            get { return pageSize2; }
        }

        private static int pageSize1;
        public static int PageSize1
        {
            get { return pageSize1; }
        }

        private static int pageSize0;
        public static int PageSize0
        {
            get { return pageSize0; }
        }

        private static int pageSize;
        public static int PageSize
        {
            get { return pageSize; }
        }

        private static int imagesPerPage;
        public static int ImagesPerPage
        {
            get { return imagesPerPage; }
        }

        private static string siteName;
        public static string SiteName
        {
            get { return siteName; }
        }

        private static int descriptionLength;
        public static int DescriptionLength
        {
            get { return descriptionLength; }
        }

        static GlobalConfiguration()
        {
            pageSize4 = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize4"]);
            pageSize3 = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize3"]);
            pageSize2 = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize2"]);
            pageSize1 = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize1"]);
            pageSize0 = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize0"]);
            pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            descriptionLength = Convert.ToInt32(ConfigurationManager.AppSettings["DesLength"]);
            siteName = ConfigurationManager.AppSettings["SiteName"];
            imagesPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["ImagesPerPage"]);
        }
        public static int CartPersistDays
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CartPersistDays"]);
            }
        }
    }
}
