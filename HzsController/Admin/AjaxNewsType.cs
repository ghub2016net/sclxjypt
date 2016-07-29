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
    public class AjaxNewsType
    {
        #region 添加新闻类型++++++
        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <param name="mo">NewsType</param>
        /// <returns></returns>
        [Action]
        public static string Add(NewsType mo)
        {
            if (String.IsNullOrEmpty(mo.name) || String.IsNullOrEmpty(mo.pid.ToString())) return Utils.msg("添加新闻类型失败,请稍后重试.", "n");
            Int32 n = DbHelper.ExecuteScalar<Int32>("select max(ntypeid) from NewsType", null, CommandKind.SqlTextNoParams);
            Int32 i = 0;
            Int16 ispublic = 0;
            if (mo.pid > 0)
                 ispublic = DbHelper.ExecuteScalar<Int16>("select ispublic from NewsType where ntypeid=" + mo.pid, null, CommandKind.SqlTextNoParams);
            mo.ntypeid = n + 1;
            if (mo.array == 0)
                mo.array = n + 1;
            NewsType.Meta.BeginTrans();//开始事物
            try
            {
                i = NewsType.Insert(mo);
                if(ispublic==0)
                    NewsType.Update("ispublic=1", "ntypeid=" + mo.pid);
                NewsType.Meta.Commit();//事物提交
            }
            catch
            {
                NewsType.Meta.Rollback();//事物回滚
                return Utils.msg("添加新闻类型失败,请稍后重试.", "n");
            }
            if (i > 0)
            {
                SystemLog.LogNewsType(mo, HzsEnum.ActionEnum.Add);//日志
                if (DataCache.GetCache(HzsKey.CACHE_NEWSTYPE_JSON) != null)//删除缓存新闻树
                    DataCache.RemoveCache(HzsKey.CACHE_NEWSTYPE_JSON);
                return Utils.msg("添加新闻类型成功.", "/info/infotype.aspx", "y");
            }
            else
                return Utils.msg("添加新闻类型失败,请刷新后重试.", "n");
        } 
        #endregion

        #region 更新新闻类型++++++
        /// <summary>
        /// 更新新闻类型
        /// </summary>
        /// <param name="mo">NewsType</param>
        [Action]
        public static string Update(NewsType mo)
        {
            if (String.IsNullOrEmpty(mo.name) || String.IsNullOrEmpty(mo.pid.ToString())) return Utils.msg("添加新闻类型失败,请稍后重试.", "n");
            if (mo.array == 0)
                mo.array = mo.ntypeid;
            Int32 i = 0;
            Int16 ispublic = 0;
            if (mo.pid > 0)
                ispublic = DbHelper.ExecuteScalar<Int16>("select ispublic from NewsType where ntypeid=" + mo.pid, null, CommandKind.SqlTextNoParams);
            NewsType.Meta.BeginTrans();//开始事物
            try
            {
                i = NewsType.Update(mo);
                if (ispublic == 0)
                    NewsType.Update("ispublic=1", "ntypeid=" + mo.pid);
                NewsType.Meta.Commit();//事物提交
            }
            catch
            {
                NewsType.Meta.Rollback();//事物回滚
            }
            if (i > 0)
            {
                SystemLog.LogNewsType(mo, HzsEnum.ActionEnum.Edit);//日志
                if (DataCache.GetCache(HzsKey.CACHE_NEWSTYPE_JSON) != null)//删除缓存新闻树
                    DataCache.RemoveCache(HzsKey.CACHE_NEWSTYPE_JSON);
                return Utils.msg("更新新闻类型成功.", "/info/infotype.aspx", "y");
            }
            else
                return Utils.msg("更新新闻类型失败,请刷新后重试.", "n");
        } 
        #endregion

        #region 软删除新闻类型及其子类型，只删除当前类及子类。++++++
        /// <summary>
        /// 删除新闻类别
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [Action]
        public static string DelNewsTypeByArray(string param)
        {
            if (Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTTYPE).ToString()) <= 1)
            {
                String[] arr = param.Split(':');
                String zhi = default(String);
                String log = default(String);
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [ntypeid]=" + arr[i] + " or ";
                    log += arr[i] + ",";
                    try
                    {
                        DbHelper.ExecuteNonQuery(String.Format(" update [NewsType] set isdel=1 where pid={0}", arr[i]), null, CommandKind.SqlTextNoParams);
                    }
                    catch (Exception ex)
                    {
                        if(log.Length>0)
                            SystemLog.LogNewsTypeDel(log);//日志
                        return Utils.msg(ex.Message, "n");
                    }
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("update [NewsType] set isdel=1 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                    {
                        SystemLog.LogNewsTypeDel(log);//日志
                        return Utils.msg("删除操作失败！", "n");
                    }
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("删除操作成功", "y");
            }
            else
                return Utils.msg("您无权操作！", "n");
        } 
        #endregion

        #region 页面跳转 ToListUrl ++++++
        [Action]
        public object ToListUrl(string l)
        {

            SiteConfig siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            if (siteConfig == null)
            {
                DataCache.Insert(HzsKey.CACHE_SITE_CONFIG, BllFactory.GetISiteConfigBLL().LoadConfig("Configpath"), Utils.GetXmlMapPath("Configpath"));
                siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            }
            return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/Default.aspx?nid=" + l);
        } 
        #endregion
    }
}
