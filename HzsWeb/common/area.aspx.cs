using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using HzsModel.Models;
using System.Text;
using ClownFish;
using System.Diagnostics;
using HzsCommon;
using System.Collections.Generic;
public partial class common_area : MyMVC.MyBasePage
{
    public string zhi;
    public string tt = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //t 为空时 返回正常的新闻类型id及名称
        if (Request.QueryString["t"] != null)
        {
            if (Request.QueryString["t"] == "hik")
                tt = "hik";
        }
        if (!IsPostBack)
        {
            //Stopwatch s = Stopwatch.StartNew();
            if (DataCache.GetCache(HzsKey.CACHE_HZSAREA_JSON) == null)
            {
                //根据查询的父类ID显示所有子类
                string sql = "WITH t AS(select[areaid],[fid],[sortarea] from HzsArea as a where fid=13 " +
                    "union all select c.[areaid],c.[fid],c.[sortarea] from HzsArea as c join t as b on c.fid=b.areaid) SELECT[areaid],[fid],[sortarea] from t";
                List<HzsArea> List = DbHelper.FillList<HzsArea>(sql, null, CommandKind.SqlTextNoParams);//查询所有类别信息
                zhi = "[" + GetHzsAreaByPId(List, 1303) + "]";
                DataCache.SetCache(HzsKey.CACHE_HZSAREA_JSON, zhi, 60);/*缓存60分钟,频道地区基本固定*/
            }
            else
                zhi = DataCache.GetCache(HzsKey.CACHE_HZSAREA_JSON).ToString();
            //s.Stop();
            //Response.Write(s.ElapsedMilliseconds + "毫秒");
        }
    }

    public String GetHzsAreaByPId(List<HzsArea> nlist, Int64 pid)
    {
        string json = "";
        HzsArea parameters = new HzsArea { fid = pid };
        List<HzsArea> linqData = nlist.Where(e => e.fid == parameters.fid).ToList(); ;//查询所有类别信息

        if (linqData.Count > 0)
        {
            json += SortTreeListJason(nlist, linqData, linqData[0]).ToString();
        }
        return json;
    }

    private StringBuilder SortTreeListJason(List<HzsArea> list, List<HzsArea> linqData, HzsArea datas)
    {
        StringBuilder treeList = new StringBuilder();

        for (int i = 0; i < linqData.Count; i++)
        {
            if (list.Where(s => s.fid == linqData[i].areaid).ToList().Count > 0)
            {
                treeList.Append("{\"id\":" + linqData[i].areaid + ",\"pid\":" + linqData[i].fid + ",\"name\":\"" + linqData[i].sortarea + "\", \"open\":\"true\",  " + "\"children\":" + "[");
                treeList.Append(GetHzsAreaByPId(list, linqData[i].areaid));
                treeList.Append("]},");
            }
            else
            {
                treeList.Append("{\"id\":" + linqData[i].areaid + ",\"pid\":" + linqData[i].fid + ",\"name\":\"" + linqData[i].sortarea + "\"},");
            }
        }
        return treeList;
    }
}