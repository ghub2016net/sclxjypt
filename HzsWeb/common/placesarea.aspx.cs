using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HzsModel.Models;
using System.Text;
using ClownFish;
using System.Diagnostics;
using HzsCommon;
using System.Collections.Generic;
/// <summary>
/// 地方频道对应的省市县联级
/// </summary>
public partial class common_placesarea : MyMVC.MyBasePage
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
            if (DataCache.GetCache(HzsKey.CACHE_PLACEAREA_JSON) == null)
            {
                //根据查询的父类ID显示所有子类
                //string sql = "WITH t AS(select[areaid],[fid],[sortarea] from HzsArea as a where fid=1303 " +
                //    "union all select c.[areaid],c.[fid],c.[sortarea] from HzsArea as c join t as b on c.fid=b.areaid) SELECT[areaid],[fid],[sortarea] from t";
                //List<HzsArea> List = DbHelper.FillList<HzsArea>(sql, null, CommandKind.SqlTextNoParams);//查询所有类别信息
                string sql ="WITH t AS(select[ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from DM_ZZDW as a where [ZZDW_SJDM]='510521000000'" +
                            "union all select c.[ZZDW_DM],c.[ZZDW_SJDM],c.[ZZDW_JC] from DM_ZZDW as c join t as b on c.ZZDW_SJDM=b                            .ZZDW_DM) SELECT[ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from t" ;
                List<DM_ZZDW> List = DbHelper.FillList<DM_ZZDW>(sql, null, CommandKind.SqlTextNoParams);
                zhi = "[" + GetHzsAreaByPId(List, "510521000000") + "]";
                DataCache.SetCache(HzsKey.CACHE_PLACEAREA_JSON, zhi, 60);/*缓存60分钟,频道地区基本固定*/
            }
            else
                zhi = DataCache.GetCache(HzsKey.CACHE_PLACEAREA_JSON).ToString();
            //s.Stop();
            //Response.Write(s.ElapsedMilliseconds + "毫秒");
        }
    }

    public String GetHzsAreaByPId(List<DM_ZZDW> nlist, String pid)
    {
        string json = "";
        DM_ZZDW parameters = new DM_ZZDW { ZZDW_SJDM = pid };
        List<DM_ZZDW> linqData = nlist.Where(e => e.ZZDW_SJDM == parameters.ZZDW_SJDM).ToList(); ;//查询所有类别信息

        if (linqData.Count > 0)
        {
            json += SortTreeListJason(nlist, linqData, linqData[0]).ToString();
        }
        return json;
    }

    private StringBuilder SortTreeListJason(List<DM_ZZDW> list, List<DM_ZZDW> linqData, DM_ZZDW datas)
    {
        StringBuilder treeList = new StringBuilder();

        for (int i = 0; i < linqData.Count; i++)
        {
            if (list.Where(s => s.ZZDW_SJDM == linqData[i].ZZDW_DM).ToList().Count > 0)
            {
                treeList.Append("{\"ZZDW_DM\":" + linqData[i].ZZDW_DM + ",\"ZZDW_SJDM\":" + linqData[i].ZZDW_SJDM + ",\"name\":\"" + linqData[i].ZZDW_JC + "\", \"open\":\"true\",  " + "\"children\":" + "[");
                treeList.Append(GetHzsAreaByPId(list, linqData[i].ZZDW_DM));
                treeList.Append("]},");
            }
            else
            {
                treeList.Append("{\"ZZDW_DM\":" + linqData[i].ZZDW_DM + ",\"ZZDW_SJDM\":" + linqData[i].ZZDW_SJDM + ",\"name\":\"" + linqData[i].ZZDW_JC + "\"},");
            }
        }
        //treeList = treeList.Length > 0 ? treeList.Remove(treeList.Length - 1, 1) : treeList;
        return treeList;
    }
}
