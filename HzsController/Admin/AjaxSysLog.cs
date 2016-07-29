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
  public  class AjaxSysLog
    {
        #region 删除系统操作日志信息+++
        /// <summary>
        /// 删除用户登录日志信息
        /// </summary>
        /// <returns></returns>
        [Action]
        public static string DeleteSysLog(string param)
        {
            if (Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTTYPE).ToString()) <= 1)
            {
                String[] arr = param.Split(':');
                string zhi = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("delete from [SysLog]  where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("删除操作成功", "y");
            }
            else
                return Utils.msg("您无权删除！", "n");
        #endregion
        }
    }
}
