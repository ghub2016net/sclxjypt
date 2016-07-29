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

public partial class community_reg : MyMVC.MyBasePage
{
    protected ArrayOfHzsUserType typelist = null;//会员类型列表
    protected ArrayOfHzsUserSfsjb sfslist = null;//示范社等级列表
    protected ArrayOfHzsUserJyms jymslist = null;//经营模式列表
    protected void Page_Load(object sender, EventArgs e)
    {
        typelist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserType>(Utils.GetMapPath("~/xmlconfig/hzsusertype.xml"), Encoding.UTF8);
        sfslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserSfsjb>(Utils.GetMapPath("~/xmlconfig/hzsusersfsjb.xml"), Encoding.UTF8);
        jymslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserJyms>(Utils.GetMapPath("~/xmlconfig/hzsuserjyms.xml"), Encoding.UTF8);
    }
}