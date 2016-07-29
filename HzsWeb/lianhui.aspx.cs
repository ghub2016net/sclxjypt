using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.Models;

public partial class lianhui : MyMVC.MyBasePage
{
    public List<NewsInfo> jigouzhengshu = null;//机构证书
    protected void Page_Load(object sender, EventArgs e)
    {
        //机构图片新闻
        List<NewsInfo> nlist = DbHelper.FillList<NewsInfo>("SELECT TOP 6 id,nimg,title FROM NewsInfo WHERE"
    + " ntypeid=284  Order By id DESC", null, CommandKind.SqlTextNoParams);
        rptBimg.DataSource = nlist;
        rptBimg.DataBind();
        if (nlist.Count > 0) { Literal1.Visible = false; } else Literal1.Visible = true;

        //机构介绍
        rptjgjs.DataSource = DbHelper.FillList<NewsInfo>("SELECT TOP 7 id,title FROM NewsInfo WHERE"
    + " ntypeid=283 and nimg<>null Order By id DESC", null, CommandKind.SqlTextNoParams);
        rptjgjs.DataBind();

        //机构证书
        jigouzhengshu = DbHelper.FillList<NewsInfo>("SELECT top 12 id,title,nimg,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=285  Order by id DESC", null, CommandKind.SqlTextNoParams);


        //机构新闻254
        rptlhxw.DataSource = DbHelper.FillList<NewsInfo>("SELECT TOP 7 id,title FROM NewsInfo WHERE"
    + " ntypeid=254 Order By id DESC", null, CommandKind.SqlTextNoParams);
        rptlhxw.DataBind();
    }
}