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
    public class UserManage : MyMVC.MyBasePage
    {
        public UserManage()
        {
            this.Load += new EventHandler(UserManage_Load);
        }

        public void UserManage_Load(object sender, EventArgs e)
        {
            if (!IsUserLogin())
            {
                Response.Write("<script>parent.location.href='/Default.aspx'</script>");
                Response.End();
            }
        }

        public bool IsUserLogin()
        {
            if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) != null)
            {
                if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_NAME) == null)
                {
                    String[] sarr = MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE).Split(new string[] { "{*}" }, StringSplitOptions.RemoveEmptyEntries);
                    DataCache.SetCache(HzsKey.CACHE_HZSUSER_UID, sarr[0], 480);
                    DataCache.SetCache(HzsKey.CACHE_HZSUSER_NAME, sarr[1], 480);
                    //DataCache.SetCache(HzsKey.CACHE_HTTYPE, sarr[2], 480);
                }
                else
                {
                    object a = DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID);
                    object b = DataCache.GetCache(HzsKey.CACHE_HZSUSER_NAME);
                }
                return true;
            }
            else
            {
                string coki = MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE);
                if (coki == null)
                {
                    if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) != null) DataCache.RemoveCache(HzsKey.CACHE_HZSUSER_UID);
                    if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_NAME) != null) DataCache.RemoveCache(HzsKey.CACHE_HZSUSER_NAME);
                    //if (DataCache.GetCache(HzsKey.CACHE_HTTYPE) != null) DataCache.RemoveCache(HzsKey.CACHE_HTTYPE);
                    return false;
                }
                else
                {
                    String[] sarr = coki.Split(new string[] { "{*}" }, StringSplitOptions.RemoveEmptyEntries);
                    DataCache.SetCache(HzsKey.CACHE_HZSUSER_UID, sarr[0], 480);
                    DataCache.SetCache(HzsKey.CACHE_HZSUSER_NAME, sarr[1], 480);
                    //DataCache.SetCache(HzsKey.CACHE_HTTYPE, sarr[2], 480);
                }
            }
            return true;
        }
    }
}
