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
using System.Collections.Generic;
using System.Data.SqlClient;
using HzsCommon;
using HzsModel.Models;
using System.Text;
public partial class community_list : MyMVC.MyBasePage{
    protected ArrayOfHzsUserJyms jymslist = null;//经营模式列表
    SqlConnection conn = null;
    SqlCommand cmd = null;
    SqlDataAdapter sda = null;
    DataSet ds = null;
    private int count;
    string listsql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载经营模式
        jymslist = XmlHelper.XmlDeserializeFromFile<ArrayOfHzsUserJyms>(Utils.GetMapPath("~/xmlconfig/hzsuserjyms.xml"), Encoding.UTF8);

        BindInfoList();
        AspNetPagerBind();
    }
    protected void AspNetPagerAskAnswer_PageChanged(object sender, EventArgs e)
    {
        AspNetPagerBind();
    }

    protected void AspNetPagerBind()
    {
        string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["hzsweb"].ToString();
        SqlConnection conn = new SqlConnection(strconn);
        cmd = new SqlCommand(listsql, conn);
        sda = new SqlDataAdapter(cmd);
        ds = new DataSet();
        AspNetPagerAskAnswer.PageSize = 15;
        AspNetPagerAskAnswer.RecordCount = count;
        sda.Fill(ds, AspNetPagerAskAnswer.PageSize * (AspNetPagerAskAnswer.CurrentPageIndex - 1), AspNetPagerAskAnswer.PageSize, "asks");
        rptList.DataSource = ds.Tables["asks"];
        rptList.DataBind();
    }

    protected void BindInfoList()
    {
        string param = string.Empty;
        if(Request["county"]!=null)
            param += string.Format(" and county = {0}", Request["county"]);
        else if (Request["city"] != null)
            param += string.Format(" and city = {0}", Request["city"]);
        else if (Request["province"] != null)
            param += string.Format(" and province = {0}", Request["province"]);
        if (Request["jyms"] != null)
            param += string.Format(" and scope like '%{0}|%'", Request["jyms"]);
        if (Request["gxsj"] != null)
        {
            string t1 = string.Empty;
            switch (Others.ints(Request["gxsj"]))
            {
                case 1:
                    t1 = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
                    break;
                case 2:
                    t1 = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                    break;
                case 3:
                    t1 = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                    break;
                case 4:
                    t1 = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd");
                    break;
            }
            param += string.Format(" and addtime>'{0}'", t1);
        }
        if (!string.IsNullOrEmpty(param))
            param = " where uid>0 " + param;
        listsql = "SELECT uid,corpname,province,city,county,linkman,tel,addtime,scope FROM HzsUser " + param + " ORDER BY addtime DESC";
        List<HzsUser> cl = DbHelper.FillList<HzsUser>(listsql, null, CommandKind.SqlTextNoParams);
        count = cl.Count;
        rptList.DataSource = cl;
        rptList.DataBind();
    }

    public string GetScope(string scopes)
    {
        List<HzsModel.HZSModels.HzsUserJyms> molist = jymslist.HzsUserJyms;
        string[] ii = scopes.Substring(0, scopes.Length - 1).Split('|');
        string a = default(string);
        if (ii.Length > 0)
        {
            foreach (string i in ii)
            {
                try
                {
                    a += (from z in molist where z.id == Others.ints(i) select z).FirstOrDefault().jname + " ";
                }
                catch
                {
                }
            }
        }
        return a;
    }
}
