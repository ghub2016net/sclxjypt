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
using HzsController.Admin;
namespace HzsController.View 
{
    public class AjaxViewHzsUserLogin
    {
        /// <summary>
        /// 合作社用户登录
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        [Action]
        public object ViewHzsUserLogin(HzsUser mo)
        {
            if (String.IsNullOrEmpty(mo.hname) || String.IsNullOrEmpty(mo.hpwd)) { return Utils.msg("用户名或密码为空！.", "n"); }
            String sql = String.Format("select * from HzsUser where hname='{0}' and hpwd='{1}'", mo.hname, Encryption.Encrypt(mo.hpwd));
            HzsUser usermodel = DbHelper.GetDataItem<HzsUser>(sql, null, CommandKind.SqlTextNoParams);
            if (usermodel != null)
            {
                MyCookies.SetNameToCookie(usermodel.uid + "{*}" + usermodel.hname + "{*}" + usermodel.htype, HzsKey.COOKIE_HZSUSER_MESSAGE, 60);//Cookie保存管理员登录合作社的UID
                StringBuilder str = new StringBuilder();
                str.Append("<div class='loginTxt'>泸县数字农经网</div>");
                str.Append("<div class='loginTxt'>欢迎您：" + usermodel.hname + "</div>");
                if (usermodel.htype > 1)
                    str.Append("<div style='padding-left:15px;'>[<a href='/lsadmin/' target='_blank'>理事会员专享</a>]</div>");
                if (usermodel.htype != 0)
                    str.Append("<div style='padding-left:15px; line-height:30px;'>[<a href='/user/' target='_blank'>管理</a>]</div>");
                else
                    str.Append("<div style='padding-left:15px; line-height:30px;'>审核中....</div>");
                str.Append("<div style='padding-left:15px; line-height:30px;'>[<a href='javascript:uout();' id='zhuxiao'> 安全注销 </a>]</div>");
                return Utils.msg(str.ToString(), "y");
            }
            else
                return Utils.msg("用户名或密码错误！.", "n");

        }

        #region 注册合作社会员++++++
        /// <summary>
        /// 注册合作社会员
        /// </summary>
        /// <param name="mo">HzsUser</param>
        /// <returns></returns>
        [Action]
        public void Reg(HzsUser mo)
        {
            if (String.IsNullOrEmpty(mo.hname) || mo.htype == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            //context.Request.ContentType = "multipart/form-data";
            Int32 i = 0;
            try
            {
                mo.hpwd = Encryption.Encrypt(mo.hpwd);//加密
                //当传递的经营范围参数超出2个选项，则只添加前2项
                String[] sc = mo.scope.Substring(0, mo.scope.Length - 1).Split('|');
                if (sc.Length > 2)
                {
                    String scope = default(String);
                    for (int a = 0; a < 2; a++)//循环经营范围选项
                    {
                        scope += sc[a] + "|";
                    }
                    mo.scope = scope;
                }
                mo.corppic = new UpLoadClass().uploadpeopleimg("corpimg/icon/y/", "corpimg/icon/s/", "120", "120");//生成合作社头像
                mo.isverify = 20;//内部验证审核
                mo.submitverify = 0;//外部验证审核
                i = HzsUser.Insert(mo);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                //SystemLog.LogHzsUser(mo, HzsEnum.ActionEnum.Add);//日志
                context.Response.Redirect("~/");
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
                        for (int a = 0; a < 2; a++)//循环经营范围选项
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
                    //SystemLog.LogHzsUser(mo, HzsEnum.ActionEnum.Edit);//日志
                    context.Response.Redirect("~/user/userinfo/Default.aspx");//跳转
                }
                else
                    AlertClass.AlertTo2Back("修改失败请重新尝试。");
            }
            else AlertClass.AlertTo2Back("密码错误请重新尝试。");
        }
        #endregion

        /// <summary>
        /// 会员退出登录
        /// </summary>
        /// <returns></returns>
        [Action]
        public object ViewHzsUserLoginOut()
        {
            MyCookies.DelNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE);
            return Utils.msg("right", "y");
        }
        [Action]
        public object ViewHzsUserLoginOutUrl()
        {
            MyCookies.DelNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE);
            return new RedirectResult("~/");
        }
    }
}
