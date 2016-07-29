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
public partial class user_company_product_eidt : UserManage
{
    protected String ac = default(String);//form action跳转链接
    protected Company mo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            String zhi = Request.QueryString["action"];
            if (zhi.ToLower() == "add")
                Add(Others.ints(Request.QueryString["rid"]));
            else if (zhi.ToLower() == "edit")
            {
                if (Request.QueryString["rid"] != null)
                {
                    if (Request.QueryString["id"] != null)
                        Update(Others.ints(Request.QueryString["id"]), Others.ints(Request.QueryString["rid"]));
                }
                else
                    Add(Others.ints(Request.QueryString["rid"]));
            }
            else
                Add(Others.ints(Request.QueryString["rid"]));
        }
        else
            Add(Others.ints(Request.QueryString["rid"]));
    }

    public void Add(int rid)
    {
        if (rid > 0)
        {
            mo = new Company();
            mo.uid = Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID));
            mo.typeid = Convert.ToInt16(rid);
            ac = "/AjaxViewCompany/AddProduct.ashx";
        }
        else { Response.Redirect("product.aspx?rid=3"); }
    }
    public void Update(int i, int rid)
    {
        ac = "/AjaxViewCompany/UpdateProduct.ashx";
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<Company>("select * from Company as a where uid=" + DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID) + " and typeid=" + rid + " and id=" + i, null, CommandKind.SqlTextNoParams);
            if (mo == null) mo = new Company();
            mo.typeid = Convert.ToInt16(rid);
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }
}