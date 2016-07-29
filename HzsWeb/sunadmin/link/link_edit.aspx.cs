using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
using System.Text;

public partial class sunadmin_link_link_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected Link mo = null;
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
        mo = new Link();
        ac = "/AjaxLink/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxLink/Update.ashx";
        if (i > 0)
        {
            mo = Link.FindByid(i);
            if (mo == null) mo = new Link();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}
