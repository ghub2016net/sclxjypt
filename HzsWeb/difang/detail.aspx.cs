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
using System.Collections.Generic;
using System.Data.SqlClient;
using HzsCommon;
public partial class difang_infodetail : MyMVC.MyBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                TextBoxBind(Convert.ToInt32(Request.Params["id"].ToString()));
            }
            catch
            {

            }
        }

    }

    public  PlacesInfo iinfo = null;


    private void TextBoxBind(int oid)
    {

        iinfo = DbHelper.GetDataItem<PlacesInfo>("SELECT addtime,pic,id,areacode,content,title,source FROM PlacesInfo WHERE id=" + oid, null, CommandKind.SqlTextNoParams);
    }
}
