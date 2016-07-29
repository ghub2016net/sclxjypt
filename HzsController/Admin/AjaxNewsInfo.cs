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
    public class AjaxNewsInfo : QuoteSiteConfig
    {
        #region 添加新闻内容++++++
        /// <summary>
        /// 添加新闻内容
        /// </summary>
        /// <param name="mo">NewsInfo</param>
        /// <returns></returns>
        [Action]
        public void Add(NewsInfo mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.ntypeid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            
            Int32 i = 0;
            try
            {
                mo.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
                mo.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
                mo.nimg = new UpLoadClass().uploadpeopleimg("newsimg/y/", "newsimg/s/", "580", "1000");//生成图片大小
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content), 510);
                i = NewsInfo.Insert(mo);    
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogNewsInfo(mo, HzsEnum.ActionEnum.Add);//日志
                //return Utils.msg("添加新闻成功.", "/info/", "y");
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/Default.aspx");
            }
            else
                AlertClass.AlertToBack("添加失败请重新尝试。");
                //return Utils.msg("添加新闻失败,请刷新后重试.", "n");
        } 
        #endregion

        #region 修改新闻内容++++++
        /// <summary>
        /// 修改新闻内容
        /// </summary>
        /// <param name="mo">NewsInfo</param>
        /// <returns></returns>
        [Action]
        public void Update(NewsInfo mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.ntypeid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";//此处设置enctype类型 获取图片
            Int32 i = 0;
            try
            {
                mo.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
                string img = new UpLoadClass().uploadpeopleimg("newsimg/y/", "newsimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.nimg = img;
                i = NewsInfo.Update(mo);
            }
            catch
            {
                AlertClass.AlertToBack("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogNewsInfo(mo, HzsEnum.ActionEnum.Edit);//日志
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/Default.aspx");//跳转
            }
            else
                AlertClass.AlertToBack("添加失败请重新尝试。");
        }
        #endregion

        #region 根据ID集合删除新闻内容++++++
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string DelNews(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("Delete NewsInfo where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                    SystemLog.LogNewsInfo(logzhi, 0);
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

        #region 通过审核操作 VerifyNews ++++++
        /// <summary>
        /// 通过审核操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string VerifyNews(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    //审核  10：通过  20：待审 40：未通过
                    y = DbHelper.ExecuteNonQuery("Update [NewsInfo]  set isverify=10 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("审核操作失败！", "n");
                    SystemLog.LogNewsInfo(logzhi, 10);
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("审核操作成功", "y");
            }
            return Utils.msg("参数错误！", "n");
        } 
        #endregion

        #region 未通过审核操作 VerifyNewsFalse ++++++
        /// <summary>
        /// 未通过审核操作
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Action]
        public static string VerifyNewsFalse(string param)
        {
            String[] arr = param.Split(':');
            string logzhi = "";
            string zhi = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    //审核  10：通过  20：待审 40：未通过
                    y = DbHelper.ExecuteNonQuery("Update [NewsInfo]  set isverify=40 where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("未通过审核操作失败！", "n");
                    SystemLog.LogNewsInfo(logzhi, 40);
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
                return Utils.msg("未通过审核操作成功", "y");
            }
            return Utils.msg("参数错误！", "n");
        }
        #endregion
    }
}
