using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsWebUI;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
public partial class user_company_about : UserManage
{
    protected String ac = default(String);//form action跳转链接
    protected Company mo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID).ToString();
        try
        {
            mo = DbHelper.GetDataItem<Company>("select * from Company as a where isonepage=1 and uid=" + DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) + " and typeid=4", null, CommandKind.SqlTextNoParams);
        }
        catch
        {
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
        }
        if (mo != null)
            Update(mo.id);
        else
            Add();
    }

    public void Add()
    {
        mo = new Company();
        mo.uid = Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID));
        mo.typeid = 4;
        ac = "/AjaxViewCompany/AddAbout.ashx";
    }
    public void Update(long i)
    {
        ac = "/AjaxViewCompany/UpdateAbout.ashx";
    }
}