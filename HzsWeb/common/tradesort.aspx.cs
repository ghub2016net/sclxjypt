using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using System.Text;
using ClownFish;
using System.Diagnostics;
using HzsCommon;

public partial class common_tradesort : MyMVC.MyBasePage
{
    public string zhi;
    public string tt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //t 为空时 返回正常的新闻类型id及名称
        if (Request.QueryString["t"] != null)
        {
            if (Request.QueryString["t"] == "hik")/*新闻列表页面传参查询 直接跳转url */
                tt = "hik";
            else if (Request.QueryString["t"] == "info")/*编辑新闻类型页面传参 返回input id=pid*/
                tt = "info";
        }
        if (!IsPostBack)
        {
            //Stopwatch s = Stopwatch.StartNew();
            if (DataCache.GetCache(HzsKey.CACHE_NEWSTYPE_JSON) == null)
            {
                List<NewsType> List = DbHelper.FillList<NewsType>("select * from NewsType where isdel=0 order by array", null, CommandKind.SqlTextNoParams);//查询所有类别信息
                zhi = "[" + GetNewsTypeByPId(List, 0) + "]";
                DataCache.SetCache(HzsKey.CACHE_NEWSTYPE_JSON, zhi, 30);/*缓存30分钟*/
            }
            else
                zhi = DataCache.GetCache(HzsKey.CACHE_NEWSTYPE_JSON).ToString();
            //s.Stop();
            //Response.Write(s.ElapsedMilliseconds + "毫秒");
        }
    }

    public string GetNewsTypeByPId(List<NewsType> nlist, int pid)
    {
        string json = "";
        NewsType parameters = new NewsType { pid = pid };
        List<NewsType> linqData = nlist.Where(e => e.pid == parameters.pid).ToList(); ;//查询所有类别信息

        if (linqData.Count > 0)
        {
            json += SortTreeListJason(nlist, linqData, linqData[0]).ToString();
        }
        return json;
    }

    private StringBuilder SortTreeListJason(List<NewsType> list, List<NewsType> linqData, NewsType datas)
    {
        StringBuilder treeList = new StringBuilder();

        for (int i = 0; i < linqData.Count; i++)
        {
            if (list.Where(s => s.pid == linqData[i].ntypeid).ToList().Count > 0)
            {
                treeList.Append("{\"id\":" + linqData[i].ntypeid + ",\"pid\":" + linqData[i].pid + ",\"name\":\"" + linqData[i].name + "\", \"open\":\"true\",  " + "\"children\":" + "[");
                treeList.Append(GetNewsTypeByPId(list, linqData[i].ntypeid));
                treeList.Append("]},");
            }
            else
            {
                treeList.Append("{\"id\":" + linqData[i].ntypeid + ",\"pid\":" + linqData[i].pid + ",\"name\":\"" + linqData[i].name + "\"},");
            }
        }
        return treeList;
    }
}