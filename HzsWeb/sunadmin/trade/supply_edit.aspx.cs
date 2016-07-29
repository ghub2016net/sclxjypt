using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
/// <summary>
/// 编辑供应信息
/// </summary>
public partial class sunadmin_trade_supply_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected Trade mo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string coki = MyCookies.GetNameFormRequest(Request, HzsKey.COOKIE_ADMIN_HZSUSERID);
        if(String.IsNullOrEmpty(coki))
            Response.Redirect("~" + siteConfig.webpath + siteConfig.webadminpath + "/huser/login.aspx?typeid=10");
        if (Request.QueryString["action"] != null)
        {
            String zhi = Request.QueryString["action"];
            if (zhi.ToLower() == "add")
                Add(coki);
            else if (zhi.ToLower() == "edit")
            {
                if (Request.QueryString["id"] != null)
                    Update(Others.ints(Request.QueryString["id"]));
            }
            else
                Add(coki);
        }
        else
            Add(coki);
    }

    public void Add(String coki)
    {
        mo = new Trade();
        mo.uid = Others.ints(coki);
        mo.tradetype = 10;
        ac = "/AjaxTrade/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxTrade/Update.ashx";
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<Trade>("select * from Trade as a where id=" + i, null, CommandKind.SqlTextNoParams);
            if (mo == null) mo = new Trade();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}