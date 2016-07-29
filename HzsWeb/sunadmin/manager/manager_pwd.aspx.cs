using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;

public partial class sunadmin_manager_manager_pwd : HzsWebUI.AdminManage
{
    public String ac = default(String);
    public AdminUser mo = null;
    public String pwd = default(String);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            String zhi = Request.QueryString["action"];
            if (zhi.ToLower() == "add")
                Add();
            else if (zhi.ToLower() == "edit")
                Update();
            else
                AlertClass.AlertToBack("参数异常请重新刷新页面。");
        }else
            Update();
    }

    public void Add()
    {
        mo = new AdminUser();
        ac = "/AjaxAdminUser/AddAdmin.ashx";
    }
    public void Update()
    {
        ac = "/AjaxAdminUser/UpdateAdmin.ashx";
        int i = Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HTUID));
        mo = AdminUser.FindByadminid(i);
        if (mo == null) mo = new AdminUser();
        pwd = Encryption.Decrypt(mo.apwd);
    }
}