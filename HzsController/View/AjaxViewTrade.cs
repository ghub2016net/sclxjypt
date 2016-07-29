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
using HzsController.Admin;
using HzsCommon.Common;
namespace HzsController.View
{
    public class AjaxViewTrade 
    {
        #region 添加供求信息++++++
        /// <summary>
        /// 添加供求信息
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Add(Trade mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                context.Response.Redirect("~/");//跳转
            Int32 i = 0;
            try
            {
                mo.tpic = new UpLoadClass().uploadpeopleimg("tradeimg/y/", "tradeimg/s/", "580", "1000");//生成图片大小
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = Trade.Insert(mo);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }

            if (i > 0)
            {
                SystemLog.ViewLogTrade(mo, HzsEnum.ActionEnum.Add);//日志
                //return Utils.msg("添加新闻成功.", "/info/", "y");
                String tourl = "/trade/supply.aspx";//跳转路径
                switch (mo.tradetype)
                {
                    case 10:
                        tourl = "/trade/supply.aspx";//供应信息列表
                        break;
                    case 20:
                        tourl = "/trade/demand.aspx";//需求信息列表
                        break;
                    case 30:
                        tourl = "/trade/cooperation.aspx";//合作信息列表
                        break;
                }
                context.Response.Redirect("~/user" + tourl);
            }
            else
                AlertClass.AlertToBack("添加失败请重新尝试。");
            //return Utils.msg("添加新闻失败,请刷新后重试.", "n");
        }
        #endregion

        #region 修改供求信息++++++
        /// <summary>
        /// 修改供求信息
        /// </summary>
        /// <param name="mo">Trade</param>
        /// <returns></returns>
        [Action]
        public void Update(Trade mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";//此处设置enctype类型 获取图片
            Int32 i = 0;
            try
            {
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE) == null)//判断uid cookie 是否存在
                    context.Response.Redirect("~/");//跳转
                if (mo.uid != Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)))
                    AlertClass.AlertTo2Back("当前登录的合作社用户ID与修改内容合作社ID不匹配！");
                if (mo.ptype2 == 0)
                    mo.ptype2 = 0;
                string img = new UpLoadClass().uploadpeopleimg("tradeimg/y/", "tradeimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.tpic = img;
                i = Trade.Update(mo);
            }
            catch
            {
                AlertClass.AlertToBack("修改失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.ViewLogTrade(mo, HzsEnum.ActionEnum.Edit);//日志
                String tourl = "/trade/supply.aspx";//跳转路径
                switch (mo.tradetype)
                {
                    case 10:
                        tourl = "/trade/supply.aspx";//供应信息列表
                        break;
                    case 20:
                        tourl = "/trade/demand.aspx";//需求信息列表
                        break;
                    case 30:
                        tourl = "/trade/cooperation.aspx";//合作信息列表
                        break;
                }
                context.Response.Redirect("~/user" + tourl);
            }
            else
                AlertClass.AlertToBack("修改失败请重新尝试。");
        }
        #endregion

        #region 删除 ++++++
        /// <summary>
        /// 根据ID删除供求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object Del(Int32 id)
        {
            if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) == null) { return new RedirectResult("~/"); }
            if (id > 0)
            {
                Trade mo = Trade.FindByid(id);

                if (mo.uid == int.Parse(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID).ToString()))
                {
                    int i = Trade.Delete(String.Format("id={0}", id));
                    if (i > 0)
                        return Utils.msg("", "y");
                    else
                        return Utils.msg("删除的信息不存在", "n");
                }
                else
                    return Utils.msg("跨用户删除信息，已经记录！", "n");
            }
            else
            {
                return Utils.msg("参数异常，请重新操作。", "n");
            }
        } 
        #endregion
    }
}
