using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HzsCommon
{
    public static class GetIP
    {
        public static string GetIPs()
        {
            string ip = default(string);
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.
            else// not using proxy or can't get the Client IP
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
            return ip;
        }
    }
}
