using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
using HzsWebUI;
public partial class user_tarde_supply_edit : UserManage
{
    protected String ac = default(String);//form action跳转链接
    protected Trade mo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            String zhi = Request.QueryString["action"];
            if (zhi.ToLower() == "add")
                Add();
            else if (zhi.ToLower() == "edit")
            {
                if (Request.QueryString["id"] != null)
                    Update(Others.ints(Request.QueryString["id"]));
            }
            else
                Add();
        }
        else
            Add();
    }

    public void Add()
    {
        mo = new Trade();
        mo.uid = Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID));
        mo.tradetype = 10;
        ac = "/AjaxViewTrade/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxViewTrade/Update.ashx";
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<Trade>("select * from Trade as a where id=" + i, null, CommandKind.SqlTextNoParams);
            if (mo == null) mo = new Trade();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}