using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.HZSModels;
using HzsModel.Models;
public partial class company_glorys : MyMVC.MyBasePage
{
    public HzsUser hzuModel = null;
    public List<HzsGlory> molist = null;//荣誉证书
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uid"] != null)
        {
            int uid = int.Parse(Request.QueryString["uid"].ToString());
            hzuModel = DbHelper.GetDataItem<HzsUser>("select uid ,hname,corpname,city,address,linkman,scope,tel,email,addtime,fax,zipcode,hzsintro,corppic from HzsUser where uid=" + uid, null, CommandKind.SqlTextNoParams);
            //产品展示
            rptCpzs.DataSource = DbHelper.FillDataTable("select TOP 6 uid,id, content, title,pic, addtime FROM Company where typeid=3 and uid=" + uid + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
            rptCpzs.DataBind();

            //荣誉证书
            molist = DbHelper.FillList<HzsGlory>("select TOP 10 * FROM HzsGlory where uid=" + uid + "ORDER BY addtime DESC ", null, CommandKind.SqlTextNoParams);
        }
    }
}