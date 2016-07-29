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

public partial class sunadmin_info_infotype : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected String keywords = String.Empty;
    protected String npid = String.Empty;
    protected List<NewsType> molist = null;
    protected Int16 ico = 0;//0表示显示根目录文件夹图片
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = 15;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["keywords"] != null)
            {
                ico = 20;//20表示文件夹图片
                keywords = Request.QueryString["keywords"];
            }
            if (Request.QueryString["npid"] != null)
            {
                if (Others.ints(Request.QueryString["npid"]) > 0)
                {
                    ico = 10;//10表示子类的文件夹图片
                    npid = Request.QueryString["npid"];
                }
            }
            RptBind("isdel=0" + CombSqlTxt(this.keywords,this.npid), "array desc");
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
        strSql.Append("select * from NewsType");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams);
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<NewsType>(pagesql, null, CommandKind.SqlTextNoParams);
        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "keywords={0}&npid={1}&page={2}", this.keywords, this.npid, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords,string _npid)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        _npid = _npid.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and name like '%" + _keywords + "%' ");
        }
        if (!string.IsNullOrEmpty(_npid))
            strTemp.Append(" and pid=" + _npid);
        else
            strTemp.Append(" and pid=0 ");
        return strTemp.ToString();
    }
    #endregion
}