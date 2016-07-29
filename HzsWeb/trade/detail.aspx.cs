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


public partial class trade_detail : MyMVC.MyBasePage
{
    public Trade trade = null;
    public HzsUser user = null;
    public HzsArea province, city, county = null;
    public int effetive_days;
    public string info = "供应信息列表";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["id"] != null && Request.Params["id"].ToString().Trim() != "")
        {
            try
            {
                BindTrade(Convert.ToInt32(Request.Params["id"].ToString()));
            }
            catch
            {
                Response.Write("<script>alert('暂无数据！');location.href='../../';</script>");
            }
            finally
            { }
        }
    }

    protected void BindTrade(int id)
    {
        ///获取交易信息
        trade = DbHelper.GetDataItem<Trade>("SELECT tradetype,name,title,intro,price,province,city,county,addtime,daytime,tpic,uid,units,content FROM Trade WHERE id=" + id, null, CommandKind.SqlTextNoParams);
        if (trade == null)
            Response.Redirect("~/");
        switch (trade.tradetype)
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
        //获取会员信息
        user = DbHelper.GetDataItem<HzsUser>("SELECT uid,corpname,hzsboss,tel FROM HzsUser WHERE uid=" + trade.uid, null, CommandKind.SqlTextNoParams);
        //获取省市县
        province = DbHelper.GetDataItem<HzsArea>("SELECT areaid,sortarea FROM HzsArea WHERE areaid=" + trade.province, null, CommandKind.SqlTextNoParams);
        city = DbHelper.GetDataItem<HzsArea>("SELECT areaid,sortarea FROM HzsArea WHERE areaid=" + trade.city, null, CommandKind.SqlTextNoParams);
        county = DbHelper.GetDataItem<HzsArea>("SELECT areaid,sortarea FROM HzsArea WHERE areaid=" + trade.county, null, CommandKind.SqlTextNoParams);

        //获取时间
        //TimeSpan t = trade.daytime - DateTime.Now;
        effetive_days = trade.daytime.Subtract(DateTime.Now).Days;
        //int i = trade.daytime.Subtract(DateTime.Now).Days;
        //DbHelper.ExecuteScalar<Int32>("SELECT datediff(day,getdate(),daytime)  FROM Trade WHERE id=" + id, null, CommandKind.SqlTextNoParams);
    }
}

