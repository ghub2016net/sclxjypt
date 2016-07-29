using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using ClownFish;
using System.Text;
using HzsCommon;
using HzsCommon.Common;
using System.Xml.Serialization;

public partial class sunadmin_info_local : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected String keywords = String.Empty;
    protected String nid = String.Empty;//新闻类型
    protected String aid = String.Empty;//地区ID
    protected List<PlacesInfo> molist = null;
    protected String areaname = default(String);
    protected ArrayOfPlacesType plist = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = 15;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["keywords"] != null)
                keywords = Request.QueryString["keywords"].Trim();

            if (Request.QueryString["nid"] != null)/*新闻类型*/
            {
                if (Others.ints(Request.QueryString["nid"]) > 0)
                    nid = Request.QueryString["nid"].Trim();
            }

            if (Request.QueryString["aid"] != null)/*审核类型*/
            {
                if (Others.ints(Request.QueryString["aid"]) > 0)
                    aid = Request.QueryString["aid"].Trim();
            }
            GetPlacesTypeList();
            GetCACHE_PLACEAREA_LIST();
            RptBind("id>0" + CombSqlTxt(this.keywords, this.nid, this.aid), "id desc");
            
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        Int32 p = Others.ints(Request.QueryString["page"]);
        if (p == 0)
            this.page = 1;
        else
            this.page = p;
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,title,pic,ishot,areaid,areacode,addtime,typeid from PlacesInfo as a");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams);
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<PlacesInfo>(pagesql, null, CommandKind.SqlTextNoParams);

        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "keywords={0}&nid={1}&aid={2}&page={3}", this.keywords, this.nid, this.aid, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _nid, string _aid)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_nid))
            strTemp.Append(" and typeid=" + _nid);

        if (!string.IsNullOrEmpty(_aid))
            strTemp.Append(" and areaid=" + _aid);

        if (!string.IsNullOrEmpty(_keywords))
            strTemp.Append(" and (title like '%" + _keywords + "%' ) ");

        return strTemp.ToString();
    }
    #endregion

    /// <summary>
    /// 根据AreaId 获取对应地区名称
    /// </summary>
    /// <param name="_aid"></param>
    /// <returns></returns>
    public string GetAreaName(string _aid)
    {
        var arealist = (List<DM_ZZDW>)DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST);
        try
        {
            string aname = (from a in arealist where a.ZZDW_DM == _aid select a).FirstOrDefault<DM_ZZDW>().ZZDW_JC;
            return aname;
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// 获取地方频道类型列表
    /// </summary>
    public void GetPlacesTypeList()
    {
        plist = XmlHelper.XmlDeserializeFromFile<ArrayOfPlacesType>(Utils.GetMapPath("~/xmlconfig/placestype.xml"), Encoding.UTF8);
        if (!string.IsNullOrEmpty(this.nid))
        {
            nid = (from n in plist.PlacesType where n.id == int.Parse(this.nid) select n).FirstOrDefault().id.ToString();
        }
    }
    /// <summary>
    /// 获取频道地区类型缓存
    /// </summary>
    public void GetCACHE_PLACEAREA_LIST()
    {
        if (DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST) == null)
        {
            //根据查询的父类ID显示所有子类
            string sql = "WITH t AS(select[ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from DM_ZZDW as a where [ZZDW_SJDM]='510521000000'" +
                               "union all select c.[ZZDW_DM],c.[ZZDW_SJDM],c.[ZZDW_JC] from DM_ZZDW as c join t as b on c.ZZDW_SJDM=b                            .ZZDW_DM) SELECT[ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from t";
            List<DM_ZZDW> List = DbHelper.FillList<DM_ZZDW>(sql, null, CommandKind.SqlTextNoParams); ;//查询所有类别信息
            DataCache.SetCache(HzsKey.CACHE_PLACEAREA_LIST, List, 60);/*缓存60分钟,频道地区基本固定*/
        }
        //if (!string.IsNullOrEmpty(this.aid))
        //{
        //    var arlist = (List<HzsArea>)DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST);
        //    areaname = (from a in arlist where a.areaid == Int64.Parse(this.aid) select a).FirstOrDefault<HzsArea>().sortarea;
        //}
    }

    /// <summary>
    /// 根据频道类型Id获取对应的名称
    /// </summary>
    /// <param name="tid">频道类型Id</param>
    /// <returns>String名称</returns>
    public string GetTypeName(int tid)
    {
        return (from p in plist.PlacesType where p.id == tid select p.value).FirstOrDefault().ToString();
    }
}

