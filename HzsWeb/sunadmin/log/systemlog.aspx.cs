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

public partial class sunadmin_log_systemlog : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected string keywords = string.Empty;
    public List<SysLog> SysLog_list = null;
    protected String ntypename = default(String);
    protected String rid = default(String);//日志类型
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = AppHelper.DefaultPageSize;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["rid"] != null)/*日志类型*/
            {
                if (Others.ints(Request.QueryString["rid"]) > 0)
                    rid = Request.QueryString["rid"].Trim();
            }

            if (Request.QueryString["keywords"] != null)
                keywords = Request.QueryString["keywords"];

            RptBind("id>0" + CombSqlTxt(this.keywords, this.rid), "id desc");
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
        strSql.Append("select * from SysLog");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = Convert.ToInt32(DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams));
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        SysLog_list = DbHelper.FillList<SysLog>(pagesql, null, CommandKind.SqlTextNoParams);
        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "keywords={0}&page={1}", this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _rid)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");

        if (!string.IsNullOrEmpty(_rid))
            strTemp.Append(" and logType=" + _rid);

        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (logValue like '%" + _keywords + "%' or editor like '%" + _keywords + "%' or ip like '%" + _keywords + "%') ");
        }
        return strTemp.ToString();
    }
    #endregion
}