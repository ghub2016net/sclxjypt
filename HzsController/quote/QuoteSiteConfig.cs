using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsCommon;
using System.Web;
using ClownFish;
using HzsModel.Config;


namespace HzsController
{
    public class QuoteSiteConfig
    {
        protected internal SiteConfig siteConfig;
        public QuoteSiteConfig()
        {
            //this.Load += new EventHandler(QuoteSiteConfig_Load);
            GetSiteConfig();              
        }

        //public void QuoteSiteConfig_Load(object sender, EventArgs e)
        //{
        //    //判断管理员是否登录
        //    if (!IsAdminLogin())
        //    {
        //        Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webadminpath + "/login.htm'</script>");
        //        Response.End();
        //    }
        //}

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
