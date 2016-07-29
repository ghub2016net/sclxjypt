using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MyMVC;
using ClownFish;
using System.IO;
using HzsModel.Config;
using HzsCommon;
namespace HzsController.Admin
{
    public class AjaxBackup
    {
        protected internal SiteConfig siteConfig;
        // 定义设置配置备份的ＸＭＬ文件
        static string xmlpath = Utils.GetXmlMapPath("BackUpPath");

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <returns></returns>
        [Action]
        public string BackupBak(string val)
        {
            siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            if (string.IsNullOrEmpty(siteConfig.dbname))
                throw new Exception("系统缓存参数异常，请重新刷新页面！");
            string zhi = "";
            val = HttpContext.Current.Server.UrlDecode(val);
            string nn = val.Substring(0, val.LastIndexOf("\\"));
            if (!Directory.Exists(nn))
            {
                Directory.CreateDirectory(nn);
            }
            string SqlStr2 = "backup database " + siteConfig.dbname + " to disk='" + val + "'";
            try
            {
                if (File.Exists(val))
                {
                    zhi = "此文件已存在，请从新输入！";
                    return zhi;
                }
                DbHelper.ExecuteNonQuery(SqlStr2, null, CommandKind.SqlTextNoParams);
                zhi = "备份数据成功！";
            }
            catch
            {
                zhi = "备份数据失败！";
            }
            return zhi;
        }

        /// <summary>
        /// 自动设置备份
        /// </summary>
        /// <param name="val"></param>
        /// <param name="settime"></param>
        /// <returns></returns>
        [Action]
        public string SetBackupBak(string val, string settime)
        {
            BackUpConfig st = new BackUpConfig();
            st.address = HttpContext.Current.Server.UrlDecode(val).Trim();
            st.settime = HttpContext.Current.Server.UrlDecode(settime).Trim();
            try
            {
                if (File.Exists(xmlpath))
                {
                    File.Delete(xmlpath);
                    CreateBackUpXml(xmlpath, st);
                }
                else
                {
                    CreateBackUpXml(xmlpath, st);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "更改成功！请重新启动IIS站点，重启后生效！";

        }

        #region XML操作+++
        /// <summary>
        /// 创建配置XML
        /// </summary>
        public void CreateBackUpXml(string xmlpath, BackUpConfig st)
        {
            XmlHelper.XmlSerializeToFile(st, xmlpath, Encoding.UTF8);
        }

        #endregion

        #region Quartz定时备份+++
        /// <summary>
        /// Quartz定时备份
        /// </summary>
        /// <param name="val">备份盘符地址全路径</param>
        /// <returns></returns>
        public void BackupBakQuartz(string val)
        {
            siteConfig = DataCache.Get<SiteConfig>(HzsKey.CACHE_SITE_CONFIG);
            if (string.IsNullOrEmpty(siteConfig.dbname))
                throw new Exception("系统缓存参数异常，请重新刷新页面！");
            string zhi = "";
            string nn = val.Substring(0, val.LastIndexOf("\\"));
            if (!Directory.Exists(nn))
                Directory.CreateDirectory(nn);
            string SqlStr2 = "backup database " + siteConfig.dbname + " to disk='" + val + "'";
            try
            {
                if (File.Exists(val))
                    zhi = "此文件已存在，请从新输入！";

                DbHelper.ExecuteNonQuery(SqlStr2, null, CommandKind.SqlTextNoParams);
                zhi = "备份数据成功！";
            }
            catch (Exception error)
            {
                zhi = error.Message;
            }
        }
        #endregion
    }
}
