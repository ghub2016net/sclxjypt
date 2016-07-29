using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClownFish;
using HzsModel.Models;
public partial class lsadmin_detail : HzsWebUI.UserManage
{
    public NewsInfo iinfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                TextBoxBind(Convert.ToInt32(Request.Params["id"].ToString()));
            }
            catch (Exception ex)
            {
                //iinfo = new NewsInfo();
                ex.ToString();
            }
        }
    }

    private void TextBoxBind(int oid)
    {
        try
        {
            iinfo = DbHelper.GetDataItem<NewsInfo>("SELECT addtime,editor,title,content FROM NewsInfo WHERE id=" + oid, null, CommandKind.SqlTextNoParams);
            if (iinfo == null)
                iinfo = new NewsInfo();
        }
        catch
        {
            iinfo = new NewsInfo();
        }
    }
}