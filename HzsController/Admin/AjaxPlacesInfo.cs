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
    public class AjaxPlacesInfo : QuoteSiteConfig
    {
        #region 添加地方频道类型++++++
        /// <summary>
        /// 添加地方频道类型
        /// </summary>
        /// <param name="mo">PlacesInfo</param>
        /// <returns></returns>
        [Action]
        public void Add(PlacesInfo mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.typeid == 0 ) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            Int32 i = 0;
            try
            {
                mo.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
                mo.editor = DataCache.GetCache(HzsKey.CACHE_HTM).ToString();
                if (String.IsNullOrEmpty(mo.source)) mo.source = "站内信息";
                if (!String.IsNullOrEmpty(mo.content))
                    mo.intro = StringClass.CutString(StringClass.CutHTML(mo.content),510);
                mo.pic = new UpLoadClass().uploadpeopleimg("newsimg/y/", "newsimg/s/", "580", "1000");//生成图片大小
                i = PlacesInfo.Insert(mo);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加频道信息失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogPlacesInfo(mo, HzsEnum.ActionEnum.Add);//日志
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/local.aspx");
            }
            else
                AlertClass.AlertToBack("添加频道信息失败请重新尝试。");
        }
        #endregion

        #region 修改地方频道类型++++++
        /// <summary>
        /// 修改地方频道类型
        /// </summary>
        /// <param name="mo">PlacesInfo</param>
        /// <returns></returns>
        [Action]
        public void Update(PlacesInfo mo)
        {
            if (String.IsNullOrEmpty(mo.title) || mo.typeid == 0) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";//此处设置enctype类型 获取图片
            Int32 i = 0;
            try
            {
                mo.adminid = Int32.Parse(DataCache.GetCache(HzsKey.CACHE_HTUID).ToString());
                string img = new UpLoadClass().uploadpeopleimg("newsimg/y/", "newsimg/s/", "580", "1000");//生成图片大小
                if (img != "")
                    mo.pic = img;
                if (String.IsNullOrEmpty(mo.editor)) mo.editor = "站内信息";
                i = PlacesInfo.Update(mo);
            }
            catch
            {
                AlertClass.AlertToBack("添加频道信息失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogPlacesInfo(mo, HzsEnum.ActionEnum.Edit);//日志
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/local.aspx");
            }
            else
                AlertClass.AlertToBack("添加频道信息失败请重新尝试。");
        }
        #endregion

        #region 根据ID集合删除地方频道内容++++++
        /// <summary>
        /// 删除操作(地方频道)
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
                    zhi += " [id]=" + arr[i] + " or ";
                    logzhi += arr[i] + ",";
                }
                int y = 0;
                try
                {
                    y = DbHelper.ExecuteNonQuery("Delete PlacesInfo where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                    SystemLog.LogPlacesInfoDel(logzhi);
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

        #region 页面跳转 ToListUrl ++++++
        /// <summary>
        /// 地方频道跳转url 
        /// </summary>
        /// <param name="l">areaid</param>
        /// <returns></returns>
        [Action]
        public object ToListUrl(string l)
        {
            return new RedirectResult("~" + siteConfig.webpath + siteConfig.webadminpath + "/info/local.aspx?aid=" + l);
        }
        #endregion
    }
}
