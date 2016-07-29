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


public partial class trade_list : MyMVC.MyBasePage
{
    public List<Trade> list = null;
    public Trade trade = null;
    public HzsUser user = null;
    public List<HzsUser> userlist = new List<HzsUser>();
    public int trade_type;
    public int user_uid;
   
    SqlConnection conn = null;
    SqlCommand cmd = null;
    SqlDataAdapter sda = null;
    DataSet ds = null;
    private int count;
    public string info = "供应信息列表";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["trade_type"] != null)
        {
            trade_type = Convert.ToInt32(Request.Params["trade_type"].ToString());
            switch (trade_type)
            {
                case 10:
                    info = "供应信息列表";
                    break;
                case 20:
                    info = "需求信息列表";
                    break;
                case 30:
                    info = "合作信息列表";
                    break;
            }
            BindInfoList(trade_type);
            AspNetPagerBind();
        }

        if (Request.Params["uid"] != null)
        {
            user_uid= Convert.ToInt32(Request.Params["uid"].ToString());
            BindInfoList(user_uid);
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
        if (Request.Params["trade_type"] != null)
        {
            cmd = new SqlCommand("SELECT  tradetype,id,name,addtime,price,uid,intro,tpic,units FROM Trade WHERE " + " isverify=10 and tradetype=" + trade_type + "  Order By addtime DESC", conn); 
        }

        if (Request.Params["uid"] != null)
        {
             cmd = new SqlCommand("SELECT  tradetype,id,name,addtime,price,uid,intro,tpic,units FROM Trade WHERE " + " isverify=10 and uid=" + user_uid + "  Order By addtime DESC", conn);
        }
       
        sda = new SqlDataAdapter(cmd);
        ds = new DataSet();
        AspNetPagerAskAnswer.PageSize = 3;
        AspNetPagerAskAnswer.RecordCount = count;
        sda.Fill(ds, AspNetPagerAskAnswer.PageSize * (AspNetPagerAskAnswer.CurrentPageIndex - 1), AspNetPagerAskAnswer.PageSize, "asks");
        rptCpjy.DataSource = ds.Tables["asks"];
        rptCpjy.DataBind();
    }

    protected void BindInfoList(int trade_type)
    {
        //string sql = " WHERE " + " t.isverify=10 and tradetype=" + trade_type + "  Order By addtime DESC";
        //list = DbHelper.FillList<Trade>("SELECT TOP 500  tradetype,id,name,t.addtime,price,t.uid,intro,tpic,h.hzsboss as t.hzsboss FROM Trade t inner join HzsUser as h on t.uid=h.uid" + sql, null, CommandKind.SqlTextNoParams);
        if (Request.Params["trade_type"] != null)
        {
            list = DbHelper.FillList<Trade>("SELECT TOP 500  tradetype,id,name,addtime,price,uid,intro,tpic,units FROM Trade WHERE " + " isverify=10 and tradetype=" + trade_type + "  Order By addtime DESC", null, CommandKind.SqlTextNoParams);
            count = list.Count;
        }

        if (Request.Params["uid"] != null)
        {
            list = DbHelper.FillList<Trade>("SELECT TOP 500  tradetype,id,name,addtime,price,uid,intro,tpic,units FROM Trade WHERE " + " isverify=10 and uid=" + user_uid + "  Order By addtime DESC", null, CommandKind.SqlTextNoParams);
            count = list.Count;
        }
    }

    /// <summary>
    /// 获取boss值
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    protected string StrBoss(int uid)
    {
        String zhi = DbHelper.ExecuteScalar<String>("SELECT hzsboss FROM HzsUser WHERE uid=" + uid, null, CommandKind.SqlTextNoParams);
        return zhi;
    }
}
