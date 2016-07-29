using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;

public partial class show_hezuo : MyMVC.MyBasePage
{
    protected Trade mo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mo = Trade.FindByid(int.Parse(Request.QueryString["id"]));//根据ID获取详细供应信息
            if (mo == null)
                mo = new Trade();
        }
        catch (Exception ex)
        {
            mo = new Trade();
            Response.Write(ex.ToString());
        }
    }
}