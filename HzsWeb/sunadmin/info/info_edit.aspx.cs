using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;
using ClownFish;

public partial class sunadmin_info_info_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected NewsInfo mo = null;
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
        mo = new NewsInfo();
        ac = "/AjaxNewsInfo/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxNewsInfo/Update.ashx";
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<NewsInfo>("select *,(select name from NewsType where ntypeid=a.ntypeid) as tname from NewsInfo as a where id=" + i, null, CommandKind.SqlTextNoParams);
            if (mo == null) mo = new NewsInfo();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}