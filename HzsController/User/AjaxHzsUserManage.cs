using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMVC;
using System.IO;
using HzsModel.Models;
using HzsCommon;
using XCode;
using ClownFish;
using HzsCommon.Common;
using System.Web;

namespace HzsController.User
{
    public class AjaxHzsUserManage : QuoteSiteConfig
    {
        #region 合作社会员登录++++++
        [Action]
        public object HzsUserLogin(HzsUser mo, Int16 t)
        {
            String sql = String.Format("select uid from HzsUser where hname='{0}' and hpwd='{1}'", mo.hname, Encryption.Encrypt(mo.hpwd));
            Int32 uid = DbHelper.ExecuteScalar<Int32>(sql, null, CommandKind.SqlTextNoParams);
            String tourl = "/huser/huserlist.aspx";
            if (uid > 0)
            {
                MyCookies.SetNameToCookie(uid.ToString(), HzsKey.COOKIE_ADMIN_HZSUSERID, 60);//Cookie保存管理员登录合作社的UID
            }
            try
            {
                switch (t)
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
            }
            catch
            {
            }
            return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + tourl);//跳转到合作社会员页面
        } 
        #endregion

        
    }
}
