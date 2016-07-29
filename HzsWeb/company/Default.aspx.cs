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
using HzsModel.HZSModels;
using HzsModel.Models;
public partial class company_Default : MyMVC.MyBasePage
{
    public HzsUser hzuModel = null;
    public int id;
    public Company hzsintro = default(Company);//合作社介绍

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uid"] != null)
        {
            id = int.Parse(Request.QueryString["uid"].ToString());
            hzuModel = DbHelper.GetDataItem<HzsUser>("select uid ,hname,corpname,city,address,linkman,scope,tel,email,addtime,fax,zipcode,hzsintro,corppic from HzsUser where uid=" + id, null, CommandKind.SqlTextNoParams);
        }

        //供求关系
        rptZxgy.DataSource = DbHelper.FillDataTable("select TOP 7 name,tradetype,city,county,uid,name,intro,price,title,tpic,address,id,units,daytime from Trade where uid=" + id + " ORDER BY id DESC", null, CommandKind.SqlTextNoParams);
        rptZxgy.DataBind();
        //新闻资讯
        rptXwzx.DataSource = DbHelper.FillDataTable("select TOP 6 uid,id, content, title,pic, addtime FROM Company where typeid=2 and uid=" + id + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
        rptZxgy.DataBind();
        //产品展示
        rptCpzs.DataSource = DbHelper.FillDataTable("select TOP 6 uid,id, content, title,pic, addtime FROM Company where typeid=3 and uid=" + id + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
        rptCpzs.DataBind();
        //合作社介绍
        hzsintro = DbHelper.GetDataItem<Company>("select TOP 1 * FROM Company where isonepage=0 and typeid=1 and uid=" + id, null, CommandKind.SqlTextNoParams);
        if (hzsintro == null)
            hzsintro = new Company();
    }
}
