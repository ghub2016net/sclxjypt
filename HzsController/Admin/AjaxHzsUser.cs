using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMVC;
using System.IO;
using HzsModel.Models;
using HzsModel.Config;
using HzsCommon;
using XCode;
using ClownFish;
using HzsCommon.Common;
using System.Web;
namespace HzsController.Admin
{
    public class AjaxHzsUser : QuoteSiteConfig
    {
        #region 添加合作社会员++++++
        /// <summary>
        /// 添加合作社会员
        /// </summary>
        /// <param name="mo">HzsUser</param>
        /// <returns></returns>
        [Action]
        public void Add(HzsUser mo)
        {
            if (String.IsNullOrEmpty(mo.hname) || mo.htype == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            Int32 i = 0;
            try
            {
                mo.hpwd = Encryption.Encrypt(mo.hpwd);//加密
                //当传递的经营范围参数超出2个选项，则只添加前2项
                String[] sc = mo.scope.Substring(0, mo.scope.Length - 1).Split('|');
                if (sc.Length > 2) {
                    String scope = default(String);
                    for (int a = 0; a < 2; a++)//循环经营范围选项
                    {
                        scope += sc[a] + "|";
                    }
                    mo.scope = scope;
                }
                mo.corppic = new UpLoadClass().uploadpeopleimg("corpimg/icon/y/", "corpimg/icon/s/", "120", "120");//生成合作社头像
                i = HzsUser.Insert(mo);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogHzsUser(mo, HzsEnum.ActionEnum.Add);//日志
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/huser/huserlist.aspx");
            }
            else
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
        }
        #endregion

        #region 修改合作社会员++++++
        /// <summary>
        /// 修改合作社会员
        /// </summary>
        /// <param name="mo">HzsUser</param>
        /// <returns></returns>
        [Action]
        public void Update(HzsUser mo)
        {
            if (String.IsNullOrEmpty(mo.hname) || mo.htype == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HzsUser hzs = HzsUser.Find(String.Format("uid={0}", mo.uid));//根据用户ID获取相关信息
            if (hzs.hpwd == Encryption.Encrypt(mo.hpwd))
            {
                mo.hpwd = hzs.hpwd;
                HttpContext context = HttpContext.Current;
                context.Request.ContentType = "multipart/form-data";//此处设置enctype类型 获取图片
                Int32 i = 0;
                try
                {
                    //当传递的经营范围参数超出2个选项，则只添加前2项
                    String[] sc = mo.scope.Substring(0, mo.scope.Length - 1).Split('|');
                    if (sc.Length > 2)
                    {
                        String scope = default(String);
                        for (int a = 0; a < 2;a++ )//循环经营范围选项
                        {
                            scope += sc[a] + "|";
                        }
                        mo.scope = scope;
                    }
                    string img = new UpLoadClass().uploadpeopleimg("corpimg/icon/y/", "corpimg/icon/s/", "120", "120");//生成合作社头像
                    if (img != "")
                        mo.corppic = img;
                        
                    i = HzsUser.Update(mo);
                }
                catch
                {
                    AlertClass.AlertToBack("修改失败请重新尝试。");
                }
                if (i > 0)
                {
                    SystemLog.LogHzsUser(mo, HzsEnum.ActionEnum.Edit);//日志
                    context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/huser/huserlist.aspx");//跳转
                }
                else
                    AlertClass.AlertTo2Back("修改失败请重新尝试。");
            }
            else AlertClass.AlertTo2Back("密码错误请重新尝试。");
        }
        #endregion

        #region 根据ID集合删除合作社会员++++++
        /// <summary>
        /// 合作社会员删除操作
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
                    Int16 isverify = DbHelper.ExecuteScalar<Int16>(String.Format("select isverify from HzsUser where [uid]='{0}'", arr[i]), null, CommandKind.SqlTextNoParams);
                    if (isverify == 40)
                    {
                        zhi += " [uid]=" + arr[i] + " or ";
                        logzhi += arr[i] + ",";
                    }
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("Delete HzsUser where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                    SystemLog.LogHzsUserDel(logzhi, 0);
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

        #region 验证合作社登录名称是否存在++++++
        /// <summary>
        /// 验证合作社登录名称是否存在
        /// </summary>
        /// <returns></returns>
        [Action]
        public object IsYzName(string param)
        {
            Int32 i = DbHelper.ExecuteScalar<Int32>(String.Format("select uid from HzsUser where hname='{0}'", param), null, CommandKind.SqlTextNoParams);
            if (i > 0)
                return Utils.msg("用户存在", "n");
            return Utils.msg("验证成功", "y");
        } 
        #endregion

        #region 合作社会员登录++++++
        [Action]
        public object HzsUserLogin(HzsUser mo, Int16 t)
        {
            String sql = String.Format("select uid from HzsUser where hname='{0}' and hpwd='{1}'", mo.hname, Encryption.Encrypt(mo.hpwd));
            Int32 uid = DbHelper.ExecuteScalar<Int32>(sql, null, CommandKind.SqlTextNoParams);
            MyCookies.SetNameToCookie(uid.ToString(), HzsKey.COOKIE_ADMIN_HZSUSERID, 30);//Cookie保存管理员登录合作社的UID
            String tourl = "/huser/huserlist.aspx";
            try
            {
                switch (t)
                {
                    case 10:
                        tourl = "/trade/supply.aspx";
                        break;
                    case 20:
                        tourl = "/trade/demand.aspx";
                        break;
                    case 30:
                        tourl = "/trade/consulting.aspx";
                        break;
                }
            }
            catch
            {
                return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + tourl);//跳转到合作社会员页面
            }
            return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + tourl);//跳转到合作社会员页面
        } 
        #endregion
    }
}
