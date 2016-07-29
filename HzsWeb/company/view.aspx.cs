using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsCommon;
using HzsModel.Models;
using ClownFish;

public partial class company_view : MyMVC.MyBasePage
{
    public Company mo = default(Company) ;
    public string typename = default(string);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["uid"] != null)//用户id
            {
                if (Request.QueryString["typeid"] != null)//类型id
                    GetValue(Others.ints(Request.QueryString["uid"]), Others.ints(Request.QueryString["typeid"]));
                else Response.Redirect("/company/Default.aspx?uid=" + Request.QueryString["uid"]);
            }
            else
                Response.Redirect("~/");
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uid">用户ID</param>
    /// <param name="t">类型ID</param>
    private void GetValue(int uid ,int t)
    {
        if (uid > 0)
        {
            if (t > 0)
            {
                mo = DbHelper.GetDataItem<Company>("select TOP 1 * FROM Company where isonepage=0 and typeid=" + t + " and uid=" + uid, null, CommandKind.SqlTextNoParams);
                if (mo == null)
                    mo = new Company();
                switch (t)
                {
                    case 1:
                        typename = "合作社介绍";
                        break;
                    case 4:
                        typename = "联系我们";
                        break;
                }
            }
            else Response.Redirect("/company/Default.aspx?uid=" + uid);
        } else Response.Redirect("~/");
    }
}