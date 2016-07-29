using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.HZSModels;
using HzsModel.Models;
public partial class company_news : MyMVC.MyBasePage
{
    public HzsUser hzuModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uid"] != null)
        {
            int uid = int.Parse(Request.QueryString["uid"].ToString());
            hzuModel = DbHelper.GetDataItem<HzsUser>("select uid ,hname,corpname,city,address,linkman,scope,tel,email,addtime,fax,zipcode,hzsintro,corppic from HzsUser where uid=" + uid, null, CommandKind.SqlTextNoParams);
            //新闻信息
            rptXinwen.DataSource = DbHelper.FillList<Company>("select top 15 uid,id,typeid,title,content,addtime,pic from Company where typeid=2 and uid= " + uid + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
            rptXinwen.DataBind();
            //产品展示
            rptCpzs.DataSource = DbHelper.FillDataTable("select TOP 6 uid,id, content, title,pic, addtime FROM Company where typeid=3 and uid=" + uid + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
            rptCpzs.DataBind();
        }
    }
}