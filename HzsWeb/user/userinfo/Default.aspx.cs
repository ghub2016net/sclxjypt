using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HzsWebUI;
using HzsModel.Models;
using HzsCommon;
using ClownFish;
using System.Text;
public partial class user_userinfo_Default : UserManage
{
    protected HzsUser mo = null;
    protected ArrayOfHzsUserType typelist = null;//会员类型列表
    protected ArrayOfHzsUserSfsjb sfslist = null;//示范社等级列表
    protected ArrayOfHzsUserJyms jymslist = null;//经营模式列表
    protected void Page_Load(object sender, EventArgs e)
    {
        Update();
        typelist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserType>(Utils.GetMapPath("~/xmlconfig/hzsusertype.xml"), Encoding.UTF8);
        sfslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserSfsjb>(Utils.GetMapPath("~/xmlconfig/hzsusersfsjb.xml"), Encoding.UTF8);
        jymslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserJyms>(Utils.GetMapPath("~/xmlconfig/hzsuserjyms.xml"), Encoding.UTF8);
    }
    public void Update()
    {

        try
        {
            mo = HzsUser.FindByuid(Convert.ToInt32(DataCache.GetCache(HzsKey.CACHE_HZSUSER_UID)));
            if (mo == null) mo = new HzsUser();
        }
        catch
        {
            AlertClass.AlertToBack("参数异常请重新刷新页面。");
        }
            
    }
}