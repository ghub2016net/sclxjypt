using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MyMVC;
using System.IO;
using HzsModel.Models;
using HzsModel.Config;
using HzsCommon;
using XCode;
using ClownFish;
using HzsCommon.Common;
namespace HzsController.Admin
{
    public class AjaxTrade : QuoteSiteConfig
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
            if (String.IsNullOrEmpty(mo.title) || mo.uid == 0 ) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
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
                SystemLog.LogTrade(mo, HzsEnum.ActionEnum.Add);//日志
                //return Utils.msg("添加新闻成功.", "/info/", "y");
                String tourl = "/trade/supply.aspx" ;//跳转路径
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
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + tourl);
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
                if (MyCookies.GetCookie(HttpContext.Current.Request, HzsKey.COOKIE_ADMIN_HZSUSERID) == null)//判断uid cookie 是否存在
                    context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/huser/login.aspx");//跳转
                if (mo.uid != int.Parse(MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_ADMIN_HZSUSERID)))
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
                AlertClass.AlertToBack("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogTrade(mo, HzsEnum.ActionEnum.Edit);//日志
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
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + tourl);//跳转
            }
            else
                AlertClass.AlertToBack("添加失败请重新尝试。");
        }
        #endregion

        #region 根据ID集合删除供求信息++++++
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string Del(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("Delete Trade where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                    SystemLog.LogTrade(logzhi, 0);
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("删除操作成功", "y");
            }
            return Utils.msg("参数错误！", "n");
        }
        #endregion

        #region 通过审核操作 VerifyNews ++++++
        /// <summary>
        /// 通过审核操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string VerifyNews(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    //审核  10：通过  20：待审 40：未通过
                    y = DbHelper.ExecuteNonQuery("Update [Trade]  set isverify=10 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("审核操作失败！", "n");
                    SystemLog.LogTrade(logzhi, 10);
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("审核操作成功", "y");
            }
            return Utils.msg("参数错误！", "n");
        }
        #endregion

        #region 未通过审核操作 VerifyNewsFalse ++++++
        /// <summary>
        /// 未通过审核操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string VerifyNewsFalse(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    //审核  10：通过  20：待审 40：未通过
                    y = DbHelper.ExecuteNonQuery("Update [Trade]  set isverify=40 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("未通过审核操作失败！", "n");
                    SystemLog.LogTrade(logzhi, 40);
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("未通过审核操作成功", "y");
            }
            return Utils.msg("参数错误！", "n");
        }
        #endregion

        #region 页面跳转 ToListUrl ++++++
        //[Action]
        //public object ToListUrl(string l)
        //{
        //    SiteConfig siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
        //    if (siteConfig == null)
        //    {
        //        DataCache.Insert(HzsKey.CACHE_SITE_CONFIG, BllFactory.GetISiteConfigBLL().LoadConfig("Configpath"), Utils.GetXmlMapPath("Configpath"));
        //        siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
        //    }
        //    return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + "/trade/supply.aspx?nid=" + l);
        //}
        #endregion
    }
}
