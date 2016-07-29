using System;
using System.Collections.Generic;
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
    ///upLoadClass 的摘要说明
    /// </summary>
    public class UpLoadClass
    {
        private string longFileName, fileType, fileName, fileExtension;//缩略属性

        /// <summary>
        /// 图片上传帮助类
        /// </summary>
        /// <param name="y">原始图片存放地址xx/xx/</param>
        /// <param name="s">缩略图片存放地址ss/ss/</param>
        /// <param name="w">生成图片宽度</param>
        /// <param name="h">生成图片高度</param>
        /// <returns>返回生成图片名称</returns>
        public string uploadpeopleimg(string y, string s, string w, string h)
        {
            string strFileName = DateTime.Now.ToString("yymmddHHmmssffff");
            string strFileName_pic = strFileName;
            string strFileDate = strFileName;
            string path1 = String.Empty;
            string path4 = String.Empty;
            string returnpath = "";
            int pcount = HttpContext.Current.Request.Files.Count;
            if (pcount > 0)
            {
                HttpPostedFile hf = HttpContext.Current.Request.Files[0];//获取上传图片对象
                if (hf.ContentLength > 0)
                {

                    string tW = w;
                    string tH = h;
                    int fileSize = 0;
                    fileSize = hf.ContentLength;

                    if (fileSize < 2097152)
                    {
                        longFileName = hf.FileName;
                        fileName = Path.GetFileName(longFileName);
                        fileExtension = Path.GetExtension(longFileName);
                        strFileName_pic = strFileName_pic + fileExtension;
                        fileType = hf.ContentType;
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/"+y)))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/"+y));
                        }
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/" + s)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + s));
                            }
                            path4 = "~/" + s + strFileName_pic;
                        }
                        else path4 = "";
                        path1 = "~/"+y + strFileName_pic;
                        
                        //returnpath = s + strFileName_pic; ;
                        returnpath = strFileName_pic;
                        byte[] byts = GetByte.getByte(hf);
                        string flag = SavePicOfSuoLue(byts, path4, path1, Int32.Parse(tH), Int32.Parse(tW));
                    }
                    else
                    {
                        AlertClass.AlertToBack("图片大小不能超过2M");
                    }
                    return returnpath;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Saves the pic.
        /// </summary>
        /// <param name="savethumbnailpath">The savethumbnailpath.</param>
        /// <param name="saveoriginalpath">The saveoriginalpath.</param>
        /// <param name="picname">The picname.</param>
        /// <param name="file">The file.</param>
        /// <param name="th">The th.</param>
        /// <param name="tw">The tw.</param>
        /// <param name="isthor">启用缩略</param>
        /// <returns></returns>
        public string SavePicOfSuoLue(byte[] fs, string savethumbnailpath, string saveoriginalpath, int th, int tw)
        {
            try
            {
                string info = SavePic(fs, saveoriginalpath);
                if ("true".Equals(info))
                {

                    if (!"".Equals(savethumbnailpath) && !"".Equals(saveoriginalpath))
                    {
                        MakeThumbnails.MakePic(HttpContext.Current.Server.MapPath(saveoriginalpath), HttpContext.Current.Server.MapPath(savethumbnailpath), tw, th);
                    }
                    return "true";//成功
                }
                else
                {
                    return "false";//失败
                }
            }
            catch
            {
                return "false";//失败
            }
        }

        public string SavePic(byte[] fs, string filepath)
        {
            try
            {
                ///定义并实例化一个内存流，以存放提交上来的字节数组。
                MemoryStream m = new MemoryStream(fs);
                ///定义实际文件对象，保存上载的文件。
                FileStream f = new FileStream(HttpContext.Current.Server.MapPath(filepath), FileMode.Create);
                ///把内内存里的数据写入物理文件
                m.WriteTo(f);
                m.Close();
                f.Close();
                f = null;
                m = null;
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
}