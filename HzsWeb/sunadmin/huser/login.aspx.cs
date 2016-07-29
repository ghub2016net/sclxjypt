using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sunadmin_huser_login : HzsWebUI.AdminManage
{
    protected string ac = default(string);//页面form action的值
    protected void Page_Load(object sender, EventArgs e)
    {
        ac = "/AjaxHzsUserManage/HzsUserLogin.ashx";
        if (Request.QueryString["typeid"] != null)//供求信息类型ID
        {
            switch (Request.QueryString["typeid"])
            {
                case "10":
                    ac += "?t=10";
                    break;
                case "20":
                    ac += "?t=20";
                    break;
                case "30":
                    ac += "?t=30";
                    break;
            }
        }
    }
}