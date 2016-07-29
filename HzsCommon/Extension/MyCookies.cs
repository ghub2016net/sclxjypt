using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;

namespace HzsCommon
{
    public static class MyCookies
    {

        #region  加密，解密cookie操作
        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="request">HttpContext.Current.request</param>
        /// <param name="cookieKey">key</param>
        /// <returns></returns>
        public static string GetNameFormRequest(HttpRequest request, string cookieKey)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            HttpCookie cookie = request.Cookies[cookieKey];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return null;
            try
            {
                return Encryption.Decrypt(cookie.Value);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 设置cookie值
        /// </summary>
        /// <param name="database">value</param>
        /// <param name="cookieKey">key</param>
        public static void SetNameToCookie(string database, string cookieKey)
        {
           
            if (HttpContext.Current == null)
                throw new InvalidOperationException();

            string cookieValue = Encryption.Encrypt(database);

            HttpCookie cookie = new HttpCookie(cookieKey, cookieValue);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 设置cookie值
        /// </summary>
        /// <param name="database">value</param>
        /// <param name="cookieKey">key</param>
        /// <param name="time">设置过期时间(分钟)</param>
        public static void SetNameToCookie(string database, string cookieKey,int time)
        {

            if (HttpContext.Current == null)
                throw new InvalidOperationException();

            string cookieValue = Encryption.Encrypt(database);

            HttpCookie cookie = new HttpCookie(cookieKey, cookieValue);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMinutes(time);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="request">HttpContext.Current.request</param>
        /// <param name="cookieKey">key</param>
        public static void DelNameFormRequest(HttpRequest request, string cookieKey)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            var coki= request.Cookies[cookieKey];
            if (coki != null)
            {
                HttpCookie cookie = coki;
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

        }
        #endregion


        /// <summary>
        /// 设置cookie值
        /// </summary>
        /// <param name="database">value</param>
        /// <param name="cookieKey">key</param>
        public static void SetCookie(string database, string cookieKey)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException();

            HttpCookie cookie = new HttpCookie(cookieKey, database);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="request">HttpContext.Current.request</param>
        /// <param name="cookieKey">key</param>
        /// <returns></returns>
        public static string GetCookie(HttpRequest request, string cookieKey)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            HttpCookie cookie = request.Cookies[cookieKey];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return null;
            try
            {
                return cookie.Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
