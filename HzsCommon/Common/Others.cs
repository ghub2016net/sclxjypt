using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HzsCommon
{
    /// <summary>
    /// 一些其他函数
    /// </summary>
    public class Others
    {
        /// <summary>
        /// Request获取传参
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns></returns>
        public static string request(string strName)
        {
            if (HttpContext.Current.Request.Params[strName] == null || HttpContext.Current.Request.Params[strName] == "")
            {
                return "";
            }
            else
            {
                return NoHtml.HTML(HttpContext.Current.Request.Params[strName].ToString(), 4);
            }
        }
        /// <summary>
        /// Request.Form获取传参
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns></returns>
        public string requestform(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null || HttpContext.Current.Request.Form[strName] == "")
            {
                return "";
            }
            else
            {
                return NoHtml.HTML(HttpContext.Current.Request.Form[strName].ToString(), 4);
            }
        }

        /// <summary>
        /// 获取ip
        /// </summary>
        /// <returns></returns>
        public string ip = HttpContext.Current.Request.UserHostAddress.ToString();
        /// <summary>
        /// 获取域名url
        /// </summary>
        /// <returns></returns>
        public string url = HttpContext.Current.Request.Url.ToString();

        /// <summary>
        /// 获取session
        /// </summary>
        /// <param name="key">key值</param>
        /// <returns></returns>
        public string getsession(string key)
        {
            try
            {
                return HttpContext.Current.Session[key].ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
        /// <summary>
        /// 保存session
        /// </summary>
        /// <param name="key">key值</param>
        /// <param name="value">value值</param>
        /// <returns></returns>
        public void setsession(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        #region 格式转换
        /// <summary>
        /// 转换时间格式[如果转换失败则返回现在时间]
        /// </summary>
        /// <param name="times">要转换的字符</param>
        /// <returns></returns>
        public static DateTime times(string times)
        {
            try
            {
                return Convert.ToDateTime(times);
            }
            catch (Exception)
            {

                return DateTime.Now;
            }
        }
        /// <summary>
        /// 转换int格式[如果转换失败则返回0]
        /// </summary>
        /// <param name="ints">要转换的字符</param>
        /// <returns></returns>
        public static int ints(string ints)
        {
            try
            {
                return Convert.ToInt32(ints);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        /// <summary>
        /// 转换小数格式[如果转换失败则返回0]
        /// </summary>
        /// <param name="Decimals">要转换的字符</param>
        /// <returns></returns>
        public static Decimal Decimals(string Decimals)
        {
            try
            {
                return Convert.ToDecimal(Decimals);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        /// <summary>
        /// 转换字符格式[如果转换失败则返回空]
        /// </summary>
        /// <param name="str">要转换的字符</param>
        /// <returns></returns>
        public static string str(object str)
        {
            try
            {
                return Convert.ToString(str);
            }
            catch (Exception)
            {

                return "";
            }
        }
        #endregion
    }
}