using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsCommon;
using System.Web;
using ClownFish;
using HzsModel.Config;
using HzsController;

namespace HzsWebUI
{
    public class AdminManage : MyMVC.MyBasePage
    {
        protected internal SiteConfig siteConfig;
        public AdminManage()
        {
            this.Load += new EventHandler(AdminManage_Load);
            GetSiteConfig();              
        }

        public void AdminManage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webadminpath + "/login.htm'</script>");
                Response.End();
            }
        }

        public bool IsAdminLogin()
        {
            if (DataCache.GetCache(HzsKey.CACHE_HTM) != null)
            {
                if (DataCache.GetCache(HzsKey.CACHE_HTUID) == null)
                {
                    String[] sarr = MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_ADMIN_MESSAGE).Split(new string[] { "{*}" }, StringSplitOptions.RemoveEmptyEntries);
                    DataCache.SetCache(HzsKey.CACHE_HTUID, sarr[0], 480);
                    DataCache.SetCache(HzsKey.CACHE_HTM, sarr[1], 480);
                    DataCache.SetCache(HzsKey.CACHE_HTTYPE, sarr[2], 480);
                }
                else 
                {
                    object a = DataCache.GetCache(HzsKey.CACHE_HTUID);
                    object b = DataCache.GetCache(HzsKey.CACHE_HTM);
                }
                return true;
            }
            else
            {
                string coki = MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_ADMIN_MESSAGE);
                if (coki == null)
                {
                    if (DataCache.GetCache(HzsKey.CACHE_HTUID) != null) DataCache.RemoveCache(HzsKey.CACHE_HTUID);
                    if (DataCache.GetCache(HzsKey.CACHE_HTM) != null) DataCache.RemoveCache(HzsKey.CACHE_HTM);
                    if (DataCache.GetCache(HzsKey.CACHE_HTTYPE) != null) DataCache.RemoveCache(HzsKey.CACHE_HTTYPE);
                    return false;
                }
                else
                {
                    String[] sarr = coki.Split(new string[] { "{*}" }, StringSplitOptions.RemoveEmptyEntries);
                    DataCache.SetCache(HzsKey.CACHE_HTUID, sarr[0], 480);
                    DataCache.SetCache(HzsKey.CACHE_HTM, sarr[1], 480);
                    DataCache.SetCache(HzsKey.CACHE_HTTYPE, sarr[2], 480);
                }
            }
            return true;
        }

        public void GetSiteConfig()
        {
            siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            if (siteConfig == null)
            {
                DataCache.Insert(HzsKey.CACHE_SITE_CONFIG, BllFactory.GetISiteConfigBLL().LoadConfig("Configpath"), Utils.GetXmlMapPath("Configpath"));
                siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            }
        }
    }
}
