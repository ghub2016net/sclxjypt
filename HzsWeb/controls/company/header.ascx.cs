using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.HZSModels;
using HzsModel.Models;
public partial class controls_company_header : MyMVC.MyBaseUserControl
{
    public HzsUser hzuModel = null;
    public Company hzsintro = default(Company);//合作社介绍
    public int aboutid = default(int);//联系我们ID
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["uid"].ToString());
        hzuModel = DbHelper.GetDataItem<HzsUser>("select uid ,hname,corpname,city,address,linkman,scope,tel,email,addtime,fax,zipcode,hzsintro,corppic from HzsUser where uid=" + id, null, CommandKind.SqlTextNoParams);
        //合作社介绍
        hzsintro = DbHelper.GetDataItem<Company>("select TOP 1 * FROM Company where isonepage=0 and typeid=1 and uid=" + id, null, CommandKind.SqlTextNoParams);
        if (hzsintro == null)
            hzsintro = new Company();
        //联系我们
        aboutid = DbHelper.ExecuteScalar<Int32>("select TOP 1 id FROM Company where isonepage=0 and typeid=1 and uid=" + id, null, CommandKind.SqlTextNoParams);

    }
}