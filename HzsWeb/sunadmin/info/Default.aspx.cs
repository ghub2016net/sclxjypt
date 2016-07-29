using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsWebUI;
using HzsModel.Models;
using ClownFish;
using System.Text;
using HzsCommon;
using HzsCommon.Common;

public partial class sunadmin_info_Default : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected String keywords = String.Empty;
    protected String nid = String.Empty;//新闻类型
    protected String rid = String.Empty;//审核类型
    protected List<NewsInfo> molist = null;
    protected String ntypename = default(String); 
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

            if (Request.QueryString["rid"] != null)/*审核类型*/
            {
                if (Others.ints(Request.QueryString["rid"]) > 0)
                    rid = Request.QueryString["rid"].Trim();
            }
            RptBind("id>0" + CombSqlTxt(this.keywords, this.nid, this.rid), "id desc");
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
        strSql.Append("select id,title,nimg,nvideo,ishot,isverify,addtime,editor,(select name from NewsType where ntypeid=a.ntypeid) as tname from NewsInfo as a");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams);
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<NewsInfo>(pagesql, null, CommandKind.SqlTextNoParams);

        if (!string.IsNullOrEmpty(this.nid))
        {
            molist.FirstOrDefault();
            if (totalCount > 0)
                ntypename = molist.FirstOrDefault<NewsInfo>().tname;
            else
                ntypename = DbHelper.ExecuteScalar<String>("select name from NewsType where ntypeid=" + this.nid, null, CommandKind.SqlTextNoParams);

        }

        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "keywords={0}&nid={1}&rid={2}&page={3}", this.keywords, this.nid, this.rid, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _nid, string _rid)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_nid))
            strTemp.Append(" and ntypeid=" + _nid);

        if (!string.IsNullOrEmpty(_rid))
            strTemp.Append(" and isverify=" + _rid);

        if (!string.IsNullOrEmpty(_keywords))
            strTemp.Append(" and (title like '%" + _keywords + "%' or seointro like '%" + _keywords + "%' or seokeyword like '%" + _keywords + "%') ");

        return strTemp.ToString();
    }
    #endregion
}