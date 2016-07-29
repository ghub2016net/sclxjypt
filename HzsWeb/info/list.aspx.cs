using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ClownFish;
using System.Collections.Generic;
using System.Data.SqlClient;
using HzsModel.Models;

public partial class info_list : MyMVC.MyBasePage
{
    public List<NewsInfo> list = null;
    public NewsType isinfo = null;
    public int sortId;
    SqlConnection conn = null;
    SqlCommand cmd = null;
    SqlDataAdapter sda = null;
    DataSet ds = null;
    private int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["sort"] != null)
        {          
            sortId = Convert.ToInt32(Request.Params["sort"].ToString());
            
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
        cmd = new SqlCommand("SELECT addtime,id,ntypeid,title FROM NewsInfo WHERE " + " isverify=10 and ntypeid=" + sortId + "  Order By addtime DESC", conn);
        sda = new SqlDataAdapter(cmd);
        ds = new DataSet();
        AspNetPagerAskAnswer.PageSize = 1;
        AspNetPagerAskAnswer.RecordCount = count;
        sda.Fill(ds, AspNetPagerAskAnswer.PageSize * (AspNetPagerAskAnswer.CurrentPageIndex - 1), AspNetPagerAskAnswer.PageSize, "asks");
        rptList.DataSource = ds.Tables["asks"];
        rptList.DataBind();
    }

    protected void BindInfoList(int sortId)
    {
        list = DbHelper.FillList<NewsInfo>("SELECT TOP 500 addtime,id,ntypeid,title FROM NewsInfo WHERE " + " isverify=10 and ntypeid=" + sortId + "  Order By addtime DESC", null, CommandKind.SqlTextNoParams);
        count = list.Count;
        isinfo = DbHelper.GetDataItem<NewsType>("SELECT ntypeid,name FROM NewsType WHERE ntypeid=" + sortId, null, CommandKind.SqlTextNoParams);
    }

}
