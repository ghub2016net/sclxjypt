using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.IO;
using System.Net;

namespace HzsCommon
{
    public class CreateHtml
    {
        public static void CreateFile(string savePath, string strFileName, string saveFileContent)
        {
            CreateFile(savePath, saveFileContent, "utf-8");
        }

        public static void CreateFile(string savePath, string strFileName, string saveFileContent, string strEncoding)
        {
            //Page p = (Page)HttpContext.Current.Handler;
            
            //string localpath = p.Server.MapPath(savePath);
            string localpath = HttpContext.Current.Server.MapPath(savePath);
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }
            StreamWriter sw = new StreamWriter(localpath + strFileName, false, Encoding.GetEncoding(strEncoding));
            sw.WriteLine(saveFileContent);
            sw.Flush();
            sw.Close();
        }

        public static void CteateHTML(string strurl, string savepath, string filename)
        {
            string strHtml = new StreamReader(WebRequest.Create(strurl).GetResponse().GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            //Page p = (Page)HttpContext.Current.Handler;
            //string localpath = p.Server.MapPath(savepath);
            string localpath = HttpContext.Current.Server.MapPath(savepath);
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }
            StreamWriter sw = new StreamWriter(localpath + filename, false, Encoding.GetEncoding("utf-8"));
            sw.WriteLine(strHtml);
            sw.Flush();
            sw.Close();
        }

        public static void SetPageMessage(string htmlpath)
        {
            Page p = (Page)HttpContext.Current.Handler;
            StreamWriter sw = new StreamWriter(p.Server.MapPath(htmlpath), false, Encoding.GetEncoding("utf-8"));
            sw.WriteLine("该信息未通过审核或已删除！<a href='/'>返回首页</a>");
            sw.Flush();
            sw.Close();
        }
    }
}
