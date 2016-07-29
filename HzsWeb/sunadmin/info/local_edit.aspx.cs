using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
using System.Text;


public partial class sunadmin_info_local_edit : HzsWebUI.AdminManage
{
    protected String ac = default(String);//form action跳转链接
    protected PlacesInfo mo = null;
    protected ArrayOfPlacesType plist = null;
    protected String areaname = default(String);
    protected void Page_Load(object sender, EventArgs e)
    {
        GetPlacesTypeList();
        if (Request.QueryString["action"] != null)
        {
            String zhi = Request.QueryString["action"];
            if (zhi.ToLower() == "add")
                Add();
            else if (zhi.ToLower() == "edit")
            {
                if (Request.QueryString["id"] != null)
                    Update(Others.ints(Request.QueryString["id"]));
            }
            else
                Add();
        }
        else
            Add();
    }

    public void Add()
    {
        mo = new PlacesInfo();
        ac = "/AjaxPlacesInfo/Add.ashx";
    }

    public void Update(int i)
    {
        ac = "/AjaxPlacesInfo/Update.ashx";
        if (i > 0)
        {
            mo = DbHelper.GetDataItem<PlacesInfo>("select * from PlacesInfo as a where id=" + i, null, CommandKind.SqlTextNoParams);
            string zzdw_jc=string.Empty;
            zzdw_jc = DM_ZZDW.Find("ZZDW_DM='"+mo.areacode+"'").ZZDW_JC;
            mo.areacode = zzdw_jc;
            if (mo == null) mo = new PlacesInfo();
        }
        else
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
    }

    /// <summary>
    /// 获取地方频道类型列表
    /// </summary>
    public void GetPlacesTypeList()
    {
        try
        {
            plist = XmlHelper.XmlDeserializeFromFile<ArrayOfPlacesType>(Utils.GetMapPath("~/xmlconfig/placestype.xml"), Encoding.UTF8);
        }
        catch
        {
            AlertClass.AlertToBack("频道类型加载异常，请尝试重新刷新.");
        }
    }
}