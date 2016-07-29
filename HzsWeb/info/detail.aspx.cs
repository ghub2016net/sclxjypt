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
using ClownFish;
using HzsModel.Models;

public partial class info_detail : MyMVC.MyBasePage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                TextBoxBind(Convert.ToInt32(Request.Params["id"].ToString()));
            }
            catch(Exception ex)
            {
                //iinfo = new NewsInfo();
                ex.ToString();
            }
        }
    }

    public NewsInfo iinfo = null;
  


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
