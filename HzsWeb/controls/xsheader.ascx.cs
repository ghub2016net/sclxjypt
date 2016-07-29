using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ClownFish;
using HzsCommon;
using HzsModel.Models;
public partial class controls_xsheader : MyMVC.MyBaseUserControl
{
    protected List<DM_ZZDW> arealist = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //获取地区频道中的县市
        GetCACHE_PLACEAREA_LIST();
    }

    /// <summary>
    /// 获取频道地区类型缓存
    /// </summary>
    public void GetCACHE_PLACEAREA_LIST()
    {
        if (DataCache.GetCache(HzsKey.CACHE_XZ_LIST) == null)
        {
            //根据查询的父类ID显示所有子类
            //string sql = "WITH t AS(select[areaid],[fid],[sortarea] from HzsArea as a where fid=1303 " +
            //    "union all select c.[areaid],c.[fid],c.[sortarea] from HzsArea as c join t as b on c.fid=b.areaid) SELECT[areaid],[fid],[sortarea] from t";

            //List<HzsArea> List = DbHelper.FillList<HzsArea>(sql, null, CommandKind.SqlTextNoParams);//查询所有类别信息
            string sql = "select[ZZDW_DM],[ZZDW_SJDM],[ZZDW_JC] from DM_ZZDW as a where [ZZDW_SJDM]='510521000000'";
            List<DM_ZZDW> List = DbHelper.FillList<DM_ZZDW>(sql, null, CommandKind.SqlTextNoParams);
            DataCache.SetCache(HzsKey.CACHE_PLACEAREA_LIST, List, 60);/*缓存60分钟,频道地区基本固定*/
        }
        arealist = (List<DM_ZZDW>)DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST);
    }
}