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
    public class AjaxAdminUser
    {

        #region 添加管理员信息+++
        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <returns></returns>
        [Action]
        public static string AddAdmin(AdminUser mo)
        {
            Int32 n = DbHelper.ExecuteScalar<Int32>(String.Format("select count(0) from AdminUser where name='{0}'", mo.name.Trim()), null, CommandKind.SqlTextNoParams);
            if (n > 0)
                return Utils.msg("管理员名称已经存在,请重新填写.", "n");
            else
            {
                mo.addtime = DateTime.Now;
                mo.apwd = Encryption.Encrypt(mo.apwd);
                int i = AdminUser.Insert(mo);
                if (i > 0)
                {
                    SystemLog.LogAdminUser(mo, HzsEnum.ActionEnum.Add);//日志
                    return Utils.msg("添加理员信息成功.", "/manager/managerlist.aspx", "y");
                }
                else
                    return Utils.msg("添加管理员信息失败,请刷新后重试.", "n");
            }
        } 
        #endregion

        #region 修改管理员信息+++
        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <returns></returns>
        [Action]
        public static string UpdateAdmin(AdminUser mo)
        {
            mo.addtime = DateTime.Now;
            mo.apwd = Encryption.Encrypt(mo.apwd);
            int i = AdminUser.Update(mo);
            if (i > 0)
            {
                //别忘了写入系统日志
                SystemLog.LogAdminUser(mo, HzsEnum.ActionEnum.Edit);//日志
                return Utils.msg("更新管理员信息成功,将重新登录.", "/AjaxLogin/Logout.ashx", "y");
            }
            else
                return Utils.msg("更新管理员信息失败,请刷新后重试.", "n");
        } 
        #endregion

        #region 禁用操作+++
        /// <summary>
        /// 禁用操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string UpdateOperate(string param)
        {
            if (Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTTYPE).ToString()) <= 1)
            {
                String[] arr = param.Split(':');
                string zhi = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [adminid]=" + arr[i] + " or ";
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("update [AdminUser] set isdel =1 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("禁用操作失败！", "n");
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("禁用操作成功", "y");
            }
            else
                return Utils.msg("您无权操作！", "n");
        } 
        #endregion

        
    }
}
