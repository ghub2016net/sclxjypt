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
using ClownFish;
using HzsModel.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using HzsCommon;
public partial class difang_dflist :MyMVC.MyBasePage
{
    public List<PlacesInfo> list = null;
    public List<PlacesInfo> list1 = null;
    public DM_ZZDW zzdw = null;
    public string inifo = null;
    public int sortId;
    SqlConnection conn = null;
    SqlCommand cmd = null;
    SqlDataAdapter sda = null;
    DataSet ds = null;
    private int count;
    public string isinfo;
    public string info = null;//省市县名称
    protected void Page_Load(object sender, EventArgs e)
    {  
        if(Request.QueryString["sort"] !=null)
        {
            QueryParameter areacode = null;
            sortId = Convert.ToInt32(Request.QueryString["sort"].ToString().Replace("'",""));
            areacode = Request.QueryString["areaid"].AsQueryParameter();
            var sql = "select [ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from DM_ZZDW where [ZZDW_DM]=".AsCPQuery();
            sql = sql + areacode;
            zzdw = DbHelper.GetDataItem<DM_ZZDW>(sql);
            BindInfoList(sortId);
            AspNetPagerBind();
        }

    }
    protected void AspNetPagerAskAnswer_PageChanged(object sender, EventArgs e)
    {
        AspNetPagerBind();
    }
    protected void AspNetPagerBind()
    {
        string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["hzsweb"].ToString();
        SqlConnection conn = new SqlConnection(strconn);
        cmd = new SqlCommand("SELECT addtime,id,typeid,title FROM PlacesInfo WHERE " + " typeid=" + sortId + "and areacode=" + zzdw.ZZDW_DM + " Order By addtime DESC", conn);
        sda = new SqlDataAdapter(cmd);
        ds = new DataSet();
        AspNetPagerAskAnswer.PageSize = 15;
        AspNetPagerAskAnswer.RecordCount = count;
        sda.Fill(ds, AspNetPagerAskAnswer.PageSize * (AspNetPagerAskAnswer.CurrentPageIndex - 1), AspNetPagerAskAnswer.PageSize, "asks");
        rptList.DataSource = ds.Tables["asks"];
        rptList.DataBind();
    }
    protected void BindInfoList(int sortId)
    {

        list = DbHelper.FillList<PlacesInfo>("SELECT count(id) FROM PlacesInfo WHERE " + "typeid=" + sortId + " and areacode=" + zzdw.ZZDW_DM, null, CommandKind.SqlTextNoParams);
       
        count = list.Count;
        string bttitle = string.Empty;
        switch (sortId)
        {
            case 1:
                bttitle = "信息新闻";
                break;
            case 2:
                bttitle = "图片新闻";
                break;
            case 3:
                bttitle = "农优特产";
                break;
            case 4:
                bttitle = "合作社风采";
                break;
        }
        inifo = bttitle;
    }

}
