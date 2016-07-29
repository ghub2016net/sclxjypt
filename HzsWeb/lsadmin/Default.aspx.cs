using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.Models;
public partial class lsadmin_Default :  HzsWebUI.UserManage
{
    public List<NewsInfo> lishitupian= null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //人物风采
        rptRwfc.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=275  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptRwfc.DataBind();
        //项目指南
        rptXmzn.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=276  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptXmzn.DataBind();
        //示范社指南
        rptSfszn.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=277  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptSfszn.DataBind();
        //营销指南
        rptYxzn.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=278  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptYxzn.DataBind();
        //经验交流
        rptJyjl.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=279  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptJyjl.DataBind();
        //联会通报
        rptLhtb.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=280  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptLhtb.DataBind();

        //献策建议 288
        rptxcjy.DataSource = DbHelper.FillDataTable("SELECT top 6 id,title,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=288  Order by id DESC", null, CommandKind.SqlTextNoParams);
        rptxcjy.DataBind();

        //理事图片
        lishitupian = DbHelper.FillList<NewsInfo>("SELECT top 12 id,title,nimg,addtime FROM NewsInfo WHERE  isverify=10 and ntypeid=288  Order by id DESC", null, CommandKind.SqlTextNoParams);
    }
}