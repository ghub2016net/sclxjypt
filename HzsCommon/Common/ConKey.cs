using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HzsCommon
{
    public class ConKey
    {
        public static string SiteNameUrl()
        {
            return ConfigurationManager.AppSettings["Configpath"];
        }

        public static string BakNameUrl()
        {
            return ConfigurationManager.AppSettings["BackUpPath"];
        }

        public static string SqlConfigValue(string sqlclientname)
        {
            return ConfigurationManager.ConnectionStrings[sqlclientname].ToString();
        }
    }
}
