using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess.Connect
{
    public class ConnectData
    {
        public static SqlConnection GetConnect()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection(ConnectionString);
        }
        public static string ConnectExcel(string filePath, string extension, string isHDR)
        {
            string conStr = "";
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            return conStr = String.Format(conStr, filePath, isHDR);
        }
    }
}
