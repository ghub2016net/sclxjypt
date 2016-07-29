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
using HzsWebUI;
using System.Collections.Generic;
public partial class user_company_product : UserManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    public List<Company> molist = null;
    protected String rid = default(String);//合作社新闻类型
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = AppHelper.DefaultPageSize;
        if (DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) == null) { AlertClass.AlertToBack("异常，请重新刷新页面！"); }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["rid"] != null)/*合作社新闻类型*/
            {
                if (Others.ints(Request.QueryString["rid"]) > 0)
                    rid = Request.QueryString["rid"].Trim();
            }

            RptBind("uid=" + Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)) + CombSqlTxt(this.rid), "id desc");
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
        strSql.Append("select * from Company");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = Convert.ToInt32(DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams));
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<Company>(pagesql, null, CommandKind.SqlTextNoParams);
        //绑定页码
        string pageUrl = Utils.CombUrlTxt("", "page={0}", "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _rid)
    {
        StringBuilder strTemp = new StringBuilder();
        if (!string.IsNullOrEmpty(_rid))
            strTemp.Append(" and typeid=" + _rid);
        return strTemp.ToString();
    }
    #endregion
}