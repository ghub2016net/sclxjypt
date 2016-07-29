using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using ClownFish;
using System.Data;
using HzsModel.Config;
using HzsCommon;

public partial class sunadmin_center : HzsWebUI.AdminManage
{
    public DataTable loglist;
    public string uploadpath;
    protected void Page_Load(object sender, EventArgs e)
    {
        //获取最新2条登陆日志
        loglist = LoginLog.Meta.Query("select top 2 * from LoginLog where islogin=0 and ltype =1 order by id desc").Tables[0];
        uploadpath = siteConfig.systempath+"upload";
    }
}