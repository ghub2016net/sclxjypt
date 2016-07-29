using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsCommon;
using HzsModel.Models;
using ClownFish;
public partial class company_newdetail : MyMVC.MyBasePage
{
    public Company mo = default(Company);
    public string typename = default(string);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)//类型id
            mo = DbHelper.GetDataItem<Company>("select TOP 1 * FROM Company where isonepage=0 and typeid=2 and id=" + Request.QueryString["id"], null, CommandKind.SqlTextNoParams);
    }
}