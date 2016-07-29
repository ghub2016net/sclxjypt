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
using HzsModel.Models;
using HzsCommon;
using ClownFish;

public partial class sunadmin_info_infotype_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected NewsType mo = null;
    protected Int16 istrue = 0;//返回子类数量
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
                AlertClass.AlertToBack("参数异常请重新刷新页面。");
        }else
            Add();
    }

    public void Add()
    {
        mo = new NewsType();
        ac = "/AjaxNewsType/Add.ashx";
    }
    public void Update(int i)
    {
        ac = "/AjaxNewsType/Update.ashx";
        //mo = NewsType.Find("ntypeid",i);
        istrue = DbHelper.ExecuteScalar<Int16>("select count(1) from NewsType where pid=" + i, null, CommandKind.SqlTextNoParams);
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<NewsType>("select *,(select name from NewsType where ntypeid=a.pid) as pname from NewsType as a where ntypeid=" + i, null, CommandKind.SqlTextNoParams);
            if (mo == null) mo = new NewsType();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}
