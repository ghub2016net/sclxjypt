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
public partial class sunadmin_huser_huser_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected HzsUser mo = null;
    protected ArrayOfHzsUserType typelist = null;//会员类型列表
    protected ArrayOfHzsUserSfsjb sfslist = null;//示范社等级列表
    protected ArrayOfHzsUserJyms jymslist = null;//经营模式列表
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
        typelist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserType>(Utils.GetMapPath("~/xmlconfig/hzsusertype.xml"), Encoding.UTF8);
        sfslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserSfsjb>(Utils.GetMapPath("~/xmlconfig/hzsusersfsjb.xml"), Encoding.UTF8);
        jymslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserJyms>(Utils.GetMapPath("~/xmlconfig/hzsuserjyms.xml"), Encoding.UTF8);
    }

    public void Add()
    {
        mo = new HzsUser();
        ac = "/AjaxHzsUser/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxHzsUser/Update.ashx";
        if (i > 0)
        {
            mo = HzsUser.FindByuid(i);
            if (mo == null) mo = new HzsUser();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }

}
