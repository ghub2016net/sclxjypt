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
    public class AjaxLink:QuoteSiteConfig
    {

        #region 添加链接++++++
        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="mo">Link</param>
        /// <returns></returns>
        [Action]
        public void Add(Link mo)
        {
            if (String.IsNullOrEmpty(mo.linkName)) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");
            HttpContext context = HttpContext.Current;
            context.Request.ContentType = "multipart/form-data";
            Int32 i = 0;
            try
            {
               
                mo.linkImgurl = new UpLoadClass().uploadpeopleimg("linkimg/icon/y/", "linkimg/icon/s/", "120", "120");//生成链接图片
                i = Link.Insert(mo);
            }
            catch
            {
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
            }
            if (i > 0)
            {
                SystemLog.LogLink(mo, HzsEnum.ActionEnum.Add);//日志
                context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/link/linklist.aspx");
            }
            else
                AlertClass.AlertTo2Back("添加失败请重新尝试。");
        }
        #endregion

        #region 修改链接++++++
        /// <summary>
        /// 修改链接
        /// </summary>
        /// <param name="mo">Link</param>
        /// <returns></returns>
        [Action]
        public void Update(Link mo)
        {
            //更新需要前台用隐藏域，name的属性要对应id，才能更新
            if (String.IsNullOrEmpty(mo.linkName) ) AlertClass.AlertTo2Back("参数异常请重新刷新页面。");

         
                HttpContext context = HttpContext.Current;
                context.Request.ContentType = "multipart/form-data";//此处设置enctype类型 获取图片
                Int32 i = 0;
                try
                {
                    
                   
                    string img = new UpLoadClass().uploadpeopleimg("linkimg/icon/y/", "linkimg/icon/s/", "120", "120");//生成链接图片
                    //img为空时，就用隐藏域中的linkImgurl
                    if (img != "")
                        mo.linkImgurl = img;
                  //有问题？
                    i = Link.Update(mo);
                    //i = DbHelper.ExecuteNonQuery("update Link set linkImgurl='" + img + "' where id="+mo.id,null,CommandKind.SqlTextNoParams);
                }
                catch
                {
                    AlertClass.AlertToBack("修改失败请重新尝试。");
                }
                if (i > 0)
                {
                    SystemLog.LogLink(mo, HzsEnum.ActionEnum.Edit);//日志
                    context.Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/link/linklist.aspx");//跳转
                }
                else
                    AlertClass.AlertTo2Back("修改失败请重新尝试。");
            }
           
        
        #endregion

        #region 删除链接+++
        /// <summary>
        /// 删除链接信息
        /// </summary>
        /// <returns></returns>
        [Action]
        public static string DeleteLink(string param)
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

                    y = DbHelper.ExecuteNonQuery("delete from [Link]  where " + zhi.Substring(0, zhi.LastIndexOf("or")), null, CommandKind.SqlTextNoParams);
                    if (y <= 0)
                        return Utils.msg("删除操作失败！", "n");
                    SystemLog.LogLinkDel(zhi, HzsEnum.ActionEnum.Delete);
                    
                }
                catch (Exception ex)
                {
                    return Utils.msg(ex.Message, "n");
                }
              
                return Utils.msg("删除操作成功", "y");
            }
            else
                return Utils.msg("您无权删除！", "n");
       
        }
        #endregion

    }
}
