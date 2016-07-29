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
public partial class sunadmin_huser_huser_verify : HzsWebUI.AdminManage
{
    protected Int32 totalCount = default(Int32);
    protected Int32 page = default(Int32);
    protected Int32 pageSize = default(Int32);
    protected String keywords = String.Empty;
    public List<HzsUser> molist = null;
    /// <summary>
    /// 会员类型列表
    /// </summary>
    protected ArrayOfHzsUserType typelist = null;//
    /// <summary>
    /// 经营模式列表
    /// </summary>
    protected ArrayOfHzsUserJyms jymslist = null;//
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pageSize = 15;
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["keywords"] != null)
                    keywords = Request.QueryString["keywords"];
                RptBind("uid>0" + CombSqlTxt(this.keywords), "uid desc");
            }
            typelist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserType>(Utils.GetMapPath("~/xmlconfig/hzsusertype.xml"), Encoding.UTF8);
            jymslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserJyms>(Utils.GetMapPath("~/xmlconfig/hzsuserjyms.xml"), Encoding.UTF8);
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
        strSql.Append("select * from HzsUser");
        if (_strWhere.Trim() != "")
        {
            strSql.Append(" where " + _strWhere);
        }
        totalCount = Convert.ToInt32(DbHelper.ExecuteScalar<Int32>(PagingHelper.CreateCountingSql(strSql.ToString()), null, CommandKind.SqlTextNoParams));
        string pagesql = PagingHelper.CreatePagingSql(totalCount, pageSize, page, strSql.ToString(), _orderby);
        molist = DbHelper.FillList<HzsUser>("SELECT TOP 15 *  FROM (select * from HzsUser where uid>0) AS T  ORDER BY uid desc ", null, CommandKind.SqlTextNoParams);
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
            strTemp.Append(" and (hname like '%" + _keywords + "%' or corpname like '%" + _keywords + "%') ");
        }
        return strTemp.ToString();
    }
    #endregion

    /// <summary>
    /// 返回经营模式值
    /// </summary>
    /// <param name="scopes"></param>
    /// <returns></returns>
    public string GetScope(string scopes)
    {
        List<HzsModel.HZSModels.HzsUserJyms> molist = jymslist.HzsUserJyms;
        string[] ii = scopes.Substring(0, scopes.Length - 1).Split('|');
        string a = default(string);
        if (ii.Length > 0)
        {
            foreach (string i in ii)
            {
                try
                {
                    a += (from z in molist where z.id == Others.ints(i) select z).FirstOrDefault().jname + " ";
                }
                catch
                {
                }
            }
        }
        return a;
    }

    public string GetHzsType(Int16 type)
    {
        List<HzsModel.HZSModels.HzsUserType> molist = typelist.HzsUserType;
        string a = default(string);
        try
        {
            a += (from z in molist where z.id == Convert.ToInt32(type) select z).FirstOrDefault().tname;
        }
        catch
        {
        }
        return a;
    }
}