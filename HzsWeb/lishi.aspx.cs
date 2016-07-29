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
using HzsModel.Models;

public partial class lishi : MyMVC.MyBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater1.DataSource = DbHelper.FillDataTable("SELECT uid,corpname FROM HzsUser WHERE isverify=10 and (hzslevel=0)", null, CommandKind.SqlTextNoParams);
        Repeater1.DataBind(); 
    }
}
