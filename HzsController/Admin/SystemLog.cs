using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsModel.Models;
using HzsCommon.Common;
using HzsCommon;

namespace HzsController.Admin
{
    public class SystemLog
    {
        #region 管理员操作日志 LogAdminUser ++++++
        /// <summary>
        /// 管理员操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae"></param>
        public static void LogAdminUser(AdminUser mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加管理员" + mo.name + "成功";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改管理员信息" + mo.name + "成功";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = mo.adminid.ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        } 
        #endregion

        #region 供求类型表操作日志 LogNewsType ++++++
        /// <summary>
        /// 供求类型操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae"></param>
        public static void LogNewsType(NewsType mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加供求类型 " + mo.name + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改供求类型 " + mo.name + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }

        /// <summary>
        /// 供求类型删除操作日志
        /// </summary>
        /// <param name="val"></param>
        public static void LogNewsTypeDel(string val)
        {
            SysLog s = new SysLog();
            s.logValue = "软删除供求类型ntypeid: " + val + " 成功.";
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = HzsEnum.ActionEnum.Delete.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }  
        #endregion

        #region 供求内容表操作日志 LogNewsInfo ++++++
        /// <summary>
        /// 供求操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae">enum</param>
        public static void LogNewsInfo(NewsInfo mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加供求 " + mo.title + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改供求 " + mo.title + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }

        /// <summary>
        /// 供求审核、删除操作日志
        /// </summary>
        /// <param name="val"></param>
        /// <param name="verify">0为不操作审核  10通过审核 40未通过审核</param>
        public static void LogNewsInfo(string val,Int16 verify)
        {
            SysLog s = new SysLog();
            switch (verify)
            { 
                case 0:
                    s.logValue = "删除供求id: " + val + " 成功.";
                    s.operate = HzsEnum.ActionEnum.Delete.ToString();
                    break;
                case 10:
                    s.logValue = "通过审核供求信息id: " + val ;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
                case 40:
                    s.logValue = "未通过审核供求信息id: " + val;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
            }
            
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }   
        #endregion

        #region 地方频道内容表操作日志 LogPlacesInfo ++++++
        /// <summary>
        /// 地方频道供求操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae">enum</param>
        public static void LogPlacesInfo(PlacesInfo mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加地方频道信息 " + mo.title + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改地方频道信息 " + mo.title + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }

        /// <summary>
        /// 地方频道供求审核、删除操作日志
        /// </summary>
        /// <param name="val"></param>
        public static void LogPlacesInfoDel(string val)
        {
            SysLog s = new SysLog();
            s.logValue = "删除地方频道id: " + val + " 成功.";
            s.operate = HzsEnum.ActionEnum.Delete.ToString();
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }
        #endregion

        #region 合作社会员表操作日志 HzsUser ++++++
        /// <summary>
        /// 编辑合作社会员操作日志
        /// </summary>
        public static void LogHzsUser(HzsUser mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加合作社会员 " + mo.hname + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改合作社会员 " + mo.hname + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }
        /// <summary>
        /// 合作社会员审核、删除操作日志
        /// </summary>
        /// <param name="val"></param>
        public static void LogHzsUserDel(string val, Int16 verify)
        {
            SysLog s = new SysLog();
            switch (verify)
            {
                case 0:
                    s.logValue = "删除合作社会员id: " + val + " 成功.";
                    s.operate = HzsEnum.ActionEnum.Delete.ToString();
                    break;
                case 10:
                    s.logValue = "通过审核合作社会员id: " + val;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
                case 40:
                    s.logValue = "未通过审核合作社会员id: " + val;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
            }

            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        } 
        #endregion

        #region 供求内容表操作日志 LogTrade ++++++
        /// <summary>
        /// 供求操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae">enum</param>
        public static void LogTrade(Trade mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加" + tradetypename(mo.tradetype) + " " + StringClass.CutString(mo.title, 80) + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改" + tradetypename(mo.tradetype) + " " + StringClass.CutString(mo.title,80) + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }

        /// <summary>
        /// 供求审核、删除操作日志
        /// </summary>
        /// <param name="val"></param>
        /// <param name="verify">0为不操作审核  10通过审核 40未通过审核</param>
        public static void LogTrade(string val, Int16 verify)
        {
            SysLog s = new SysLog();
            switch (verify)
            {
                case 0:
                    s.logValue = "删除供求信息id: " + val + " 成功.";
                    s.operate = HzsEnum.ActionEnum.Delete.ToString();
                    break;
                case 10:
                    s.logValue = "通过审核供求信息id: " + val;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
                case 40:
                    s.logValue = "未通过审核供求信息id: " + val;
                    s.operate = HzsEnum.ActionEnum.Audit.ToString();
                    break;
            }

            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }

        /// <summary>
        /// 返回对应的供应类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string tradetypename(Int16 t)
        {
            string zhi = default(string);
            switch (t)
            {
                case 10:
                    zhi = "供应信息";
                    break;
                case 20:
                    zhi = "求购信息";
                    break;
                case 30:
                    zhi = "合作信息";
                    break;
            }
            return zhi;
        }

        /// <summary>
        /// 用户供求操作日志
        /// </summary>
        /// <param name="mo"></param>
        /// <param name="ae">enum</param>
        public static void ViewLogTrade(Trade mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加" + tradetypename(mo.tradetype) + " " + StringClass.CutString(mo.title, 80) + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改" + tradetypename(mo.tradetype) + " " + StringClass.CutString(mo.title, 80) + " 成功.";
                    break;
            }
            s.logType = 2;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID).ToString();
            s.adminid = 0;
            SysLog.Insert(s);
        }
        #endregion

        #region 链接表操作日志 HzsUser ++++++
        /// <summary>
        /// 编辑链接表操作日志
        /// </summary>
        public static void LogLink(Link mo, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Add:
                    s.logValue = "添加链接 " + mo.linkName + " 成功.";
                    break;
                case HzsEnum.ActionEnum.Edit:
                    s.logValue = "更改链接 " + mo.linkName + " 成功.";
                    break;
            }
            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.operate = ae.ToString();
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }
        /// <summary>
        /// 链接审核、删除操作日志
        /// </summary>
        /// <param name="val"></param>
        public static void LogLinkDel(string val, HzsEnum.ActionEnum ae)
        {
            SysLog s = new SysLog();
            switch (ae)
            {
                case HzsEnum.ActionEnum.Delete:
                    s.logValue = "删除链接id: " + val.LastIndexOf("or") + " 成功.";
                    s.operate = HzsEnum.ActionEnum.Delete.ToString();
                    break;
              
            }

            s.logType = 1;//操作日志类型：1：代表管理员操作日志，2：合作社操作日志，3：其他操作日志
            s.ip = Utils.GetIP();
            s.addtime = DateTime.Now;
            s.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
            s.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
            SysLog.Insert(s);
        }
        #endregion
    }
}
