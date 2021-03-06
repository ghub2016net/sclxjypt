﻿using System;
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

public partial class sunadmin_manager_managerlist : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected String keywords = String.Empty;
    public List<AdminUser> molist = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = 1;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["keywords"] != null)
                keywords = Request.QueryString["keywords"];
            RptBind("adminid>0" + CombSqlTxt(this.keywords), "adminid desc");
        }
    }
    
    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        Int32 p =Others.ints(Request.QueryString["page"]);
        if ( p == 0)
            this.page = 1;
        else
            this.page = p;
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from AdminUser");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = Convert.ToInt32(DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()),null,CommandKind.SqlTextNoParams));
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<AdminUser>(pagesql, null, CommandKind.SqlTextNoParams);
        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "keywords={0}&page={1}", this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (name like '%" + _keywords + "%' or email like '%" + _keywords + "%') ");
        }
        return strTemp.ToString();
    }
    #endregion

}