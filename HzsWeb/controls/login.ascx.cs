﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsCommon;

public partial class controls_login : MyMVC.MyBaseUserControl
{
    /// <summary>
    /// 合作社用户Id
    /// </summary>
    protected Int32 uid = default(Int32);
    /// <summary>
    /// 合作社登录名称
    /// </summary>
    protected String uname = default(String);
    /// <summary>
    /// 合作社会员类型
    /// </summary>
    protected Int16 htype = default(Int16);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (MyCookies.GetNameFormRequest(Request, HzsKey.COOKIE_HZSUSER_MESSAGE) != null)
        {
            String[] sarr = MyCookies.GetNameFormRequest(HttpContext.Current.Request, HzsKey.COOKIE_HZSUSER_MESSAGE).Split(new string[] { "{*}" }, StringSplitOptions.RemoveEmptyEntries);
            uid = Int32.Parse(sarr[0]);
            uname = sarr[1];
            htype = Int16.Parse(sarr[2]);
        }
    }
}