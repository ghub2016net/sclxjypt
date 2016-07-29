using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMVC;
using HzsModel.Models;
using HzsCommon;
using XCode;
using ClownFish;
using System.Web;
namespace HzsController.View
{
    public class AjaxViewCompany
    {
        #region 添加供合作社介绍++++++
        /// <summary>
        /// 添加合作社介绍
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void AddIntro(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                AlertClass.toPage("/",1);
            Int32 i = 0;
            try
            {
                mo.title = "合作社介绍";
                mo.isonepage = 1;//单页信息 就是总共1条信息
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = Company.Insert(mo);
                context.Response.Redirect("~/user/company/intro.aspx");
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }

        }
        #endregion

        #region 修改合作社介绍++++++
        /// <summary>
        /// 修改合作社介绍
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void UpdateIntro(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    AlertClass.toPage("/", 1);//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                i = Company.Update(mo);
                context.Response.Redirect("~/user/company/intro.aspx");
            }
            catch
            {
                AlertClass.AlertToBack("添加失败请重新尝试。");
            }
        }
        #endregion

        #region 添加合作社新闻++++++
        /// <summary>
        /// 添加合作社新闻
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Add(Company mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                AlertClass.toPage("/", 1);//跳转
            Int32 i = 0;
            try
            {
                mo.isonepage = 0;//非单页信息
                mo.pic = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小
                mo.click = 0;
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = Company.Insert(mo);
                context.Response.Redirect("/user/company/info.aspx?rid=" + mo.typeid);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }

        }
        #endregion

        #region 修改合作社新闻++++++
        /// <summary>
        /// 修改合作社新闻
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Update(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    AlertClass.toPage("/", 1);//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                string img = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.pic = img;
                i = Company.Update(mo);
                context.Response.Redirect("~/user/company/info.aspx?rid=" + mo.typeid);
            }
            catch
            {
                AlertClass.AlertToBack("修改失败请重新尝试。");
            }
        }
        #endregion

        #region 添加产品信息++++++
        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void AddProduct(Company mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                AlertClass.toPage("/", 1);//跳转
            Int32 i = 0;
            try
            {
                mo.isonepage = 0;//非单页信息
                mo.pic = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小
                mo.click = 0;
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = Company.Insert(mo);
                context.Response.Redirect("~/user/company/Product.aspx?rid=" + mo.typeid);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }

        }
        #endregion

        #region 修改产品信息++++++
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void UpdateProduct(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    AlertClass.toPage("/", 1);//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                string img = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.pic = img;
                i = Company.Update(mo);
                context.Response.Redirect("~/user/company/Product.aspx?rid=" + mo.typeid);
            }
            catch
            {
                AlertClass.AlertToBack("修改失败请重新尝试。");
            }
        }
        #endregion

        #region 添加联系我们++++++
        /// <summary>
        /// 添加合作社介绍
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void AddAbout(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                AlertClass.toPage("/", 1);//跳转
            Int32 i = 0;
            try
            {
                mo.title = "联系我们";
                mo.isonepage = 1;//单页信息 就是总共1条信息
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = Company.Insert(mo);
                context.Response.Redirect("~/user/company/about.aspx");
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }

        }
        #endregion

        #region 修改联系我们++++++
        /// <summary>
        /// 修改合作社介绍
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void UpdateAbout(Company mo)
        {
            if (String.IsNullOrEmpty(mo.content) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    AlertClass.toPage("/", 1);//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                i = Company.Update(mo);
                context.Response.Redirect("~/user/company/about.aspx");
            }
            catch
            {
                AlertClass.AlertToBack("添加失败请重新尝试。");
            }
        }
        #endregion

        #region 删除 ++++++
        /// <summary>
        /// 根据ID删除合作社新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public void Del(Int64 id)
        {
            if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) == null) { HttpContext.Current.Response.Redirect("~/"); }
            if (id > 0)
            {
                Company mo = Company.FindByid(id);
                
                if (mo.uid == int.Parse(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID).ToString()))
                {
                    int i = Company.Delete(String.Format("id={0}", id));
                    if (i > 0)
                    {
                        string zhi = default(string);
                        switch (mo.typeid)
                        {
                            case 2:
                                zhi = "~/user/company/info.aspx?rid=2";
                                break;
                            case 3:
                                zhi = "~/user/company/product.aspx?rid=3";
                                break;
                        }
                        HttpContext.Current.Response.Redirect(zhi);
                    }
                    else
                        AlertClass.AlertTo2Back("参数异常请重新刷新页面。"); 
                }
                else
                    AlertClass.AlertTo2Back("跨用户删除信息，已经记录！");
            }
            else
            {
                AlertClass.AlertTo2Back("参数异常请重新刷新页面。"); 
            }
        }
        #endregion
    }
}
