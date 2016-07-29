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
    public class AjaxViewHzsGlory
    {
        #region 添加荣誉证书++++++
        /// <summary>
        /// 添加荣誉证书
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Add(HzsGlory mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                context.Response.Redirect("~/");//跳转
            Int32 i = 0;
            try
            {
                mo.pic = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小

                i = HzsGlory.Insert(mo);
                context.Response.Redirect("~/user/company/glory.aspx");
            }
            catch
            {
                AlertClass.AlertTo2Back("修改失败请重新尝试。");
            }

        }
        #endregion

        #region 修改荣誉证书++++++
        /// <summary>
        /// 修改荣誉证书
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Update(HzsGlory mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    context.Response.Write("<script>parent.location.href='/Default.aspx'</script>");//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                string img = new UpLoadClass().uploadpeopleimg("corpimg/y/", "corpimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.pic = img;
                i = HzsGlory.Update(mo);
                context.Response.Redirect("~/user/company/glory.aspx");
            }
            catch
            {
                AlertClass.AlertToBack("修改失败请重新尝试。");
            }
        }
        #endregion

        #region 删除 ++++++
        /// <summary>
        /// 根据ID删除荣誉证书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public void Del(Int32 id)
        {
            if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) == null) { HttpContext.Current.Response.Redirect("~/"); }
            if (id > 0)
            {
                HzsGlory mo = HzsGlory.FindByid(id);

                if (mo.uid == int.Parse(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID).ToString()))
                {
                    int i = HzsGlory.Delete(String.Format("id={0}", id));
                    if (i > 0)
                        HttpContext.Current.Response.Redirect("~/user/company/glory.aspx");
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
