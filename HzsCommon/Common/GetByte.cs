using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

namespace HzsCommon
{
    /// <summary>
    ///Common 的摘要说明
    /// </summary>
    public static class GetByte
    {


        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="FileUpload1">The file upload1.</param>
        /// <returns></returns>
        public static byte[] getByte(HttpPostedFile FileUpload1)
        {
            //获得转化后的字节数组
            //得到用户要上传的文件名
            string strFilePathName = FileUpload1.FileName;
            string strFileName = Path.GetFileName(strFilePathName);
            int FileLength = FileUpload1.ContentLength;
            //上传文件
            Byte[] FileByteArray = new Byte[FileLength]; //图象文件临时储存Byte数组
            Stream StreamObject = FileUpload1.InputStream; //建立数据流对像
            //读取图象文件数据，FileByteArray为数据储存体，0为数据指针位置、FileLnegth为数据长度
            StreamObject.Read(FileByteArray, 0, FileLength);
            return FileByteArray;
        }

    }


    public class AlertClass
    {
        /// <summary>
        /// 提示后返回前一页面
        /// </summary>
        /// <param name="message"></param>
        public static void AlertToBack(string message)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + message + "');window.history.back();</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 提示后返回2个页面
        /// </summary>
        /// <param name="message"></param>
        public static void AlertTo2Back(string message)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + message + "');window.history.back(2);</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 提示后跳转到新页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertToPage(string message, string url)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + message + "');window.location='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 提示后关闭页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertToClose(string message)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + message + "');;window.opener=null;window.close();</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 提示后父页跳转到新页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertParentToPage(string message, string url)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + message + "');top.window.location='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 转向新页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="istop"></param>
        public static void toPage(string url, int istop)
        {
            if (istop == 0)
            {
                HttpContext.Current.Response.Write("<script type=\"text/javascript\">window.location='" + url + "';</script>");
            }
            else
            {
                HttpContext.Current.Response.Write("<script type=\"text/javascript\">top.window.location='" + url + "';</script>");
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 提示后父页跳转到新页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void WriteInfo(string message)
        {
            HttpContext.Current.Response.Write("" + message + "");
            HttpContext.Current.Response.End();
        }
    }
}