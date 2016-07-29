using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HzsModel.Models;
using HzsCommon;
using ClownFish;

namespace HzsController.Page.common
{
    public static class XzHeaderControl
    {
        public static List<HzsArea> GetXzHeader()
        {
            if (DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST) == null)
            {
                //根据查询的父类ID显示所有子类
                string sql = "WITH t AS(select[areaid],[fid],[sortarea] from HzsArea as a where fid=1303 " +
                    "union all select c.[areaid],c.[fid],c.[sortarea] from HzsArea as c join t as b on c.fid=b.areaid) SELECT[areaid],[fid],[sortarea] from t";
                List<HzsArea> List = DbHelper.FillList<HzsArea>(sql, null, CommandKind.SqlTextNoParams);//查询所有类别信息
                DataCache.SetCache(HzsKey.CACHE_PLACEAREA_LIST, List, 60);/*缓存60分钟,频道地区基本固定*/
            }
            return (List<HzsArea>)DataCache.GetCache(HzsKey.CACHE_PLACEAREA_LIST);
        }
    }
}
