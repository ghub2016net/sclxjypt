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
public partial class difang_Default : MyMVC.MyBasePage
{
   
    public DM_ZZDW info = null;
    protected void Page_Load(object sender, EventArgs e)
    {

      QueryParameter areacode = null;
      if (Request.QueryString["aid"] == null){ Response.Redirect("../Default.aspx"); }
        areacode = Request.QueryString["aid"].Replace("'","").AsQueryParameter();
        var sql = "select [ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from DM_ZZDW where [ZZDW_DM]=".AsCPQuery();
        sql = sql + areacode;
        info = DbHelper.GetDataItem<DM_ZZDW>(sql);

        var sql1 = " SELECT TOP 6 id,title,pic FROM PlacesInfo where typeid = 2 and  areacode= ".AsCPQuery();
        sql1 = sql1 + areacode;
        //int areaid = Convert.ToInt32(Request.QueryString["aid"].ToString());
        //新闻图片
        List<PlacesInfo> dlist = DbHelper.FillList<PlacesInfo>(sql1);
        rptBimg.DataSource=dlist;
        rptBimg.DataBind();
        if(dlist.Count==0)
        {
            rptBimg.Visible = false;
            Literal1.Text = "<img src=\"../images/noimg.png\" alt=\"暂无内容\" width=\"369\" height=\"232\">";
        }
        //名优特产
        var sql2 = "SELECT TOP 15 id,title,pic,addtime FROM PlacesInfo where typeid=3 and areacode=".AsCPQuery();
        sql2 = sql2 + areacode;
        sql2 = sql2 + " Order By addtime DESC";
        rptMytc.DataSource = DbHelper.FillDataTable(sql2);
        rptMytc.DataBind();
        //新闻信息
        var sql3 = "SELECT top 7 id,title,content,typeid,addtime FROM PlacesInfo where typeid=1 and areacode=".AsCPQuery();
        sql3 = sql3 + areacode;
        sql3 = sql3 + " Order By addtime DESC";
        Repeater1.DataSource = DbHelper.FillDataTable(sql3);
        Repeater1.DataBind();
        //农民合作社
        var sql4 = "SELECT TOP 7 id, title,pic, addtime FROM PlacesInfo where typeid=4 and areacode=".AsCPQuery();
        sql4 = sql4 + areacode;
        sql4 = sql4 + " Order By addtime DESC";
        rptNmhzstj.DataSource = DbHelper.FillDataTable(sql4);
        rptNmhzstj.DataBind();
    }
}
