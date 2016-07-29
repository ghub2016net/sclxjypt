/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-11 09:19:17
 * 版权：版权所有 (C)HIK 2014
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Web;
using XCode;
using XCode.Configuration;

namespace HzsModel.Models
{
    /// <summary>新闻信息表</summary>
    public partial class NewsInfo : Entity<NewsInfo>
    {
        #region 对象操作﻿

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            //if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
            //if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
            //if (isNew || Dirtys[__.Name]) CheckExist(__.Name);
            
            if (isNew && !Dirtys[__.addtime]) addtime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();

        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数
        //    if (Meta.Count > 0) return;

        //    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(NewsInfo).Name, Meta.Table.DataTable.DisplayName);

        //    var entity = new NewsInfo();
        //    entity.adminid = 0;
        //    entity.title = "abc";
        //    entity.content = "abc";
        //    entity.nimg = "abc";
        //    entity.nvideo = "abc";
        //    entity.nvideoimg = "abc";
        //    entity.ishot = 0;
        //    entity.ispublic = 0;
        //    entity.isverify = 0;
        //    entity.editor = "abc";
        //    entity.addtime = DateTime.Now;
        //    entity.ntypeid = 0;
        //    entity.intro = "abc";
        //    entity.click = 0;
        //    entity.seotitle = "abc";
        //    entity.seointro = "abc";
        //    entity.seokeyword = "abc";
        //    entity.htmlpath = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(NewsInfo).Name, Meta.Table.DataTable.DisplayName);
        //}


        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnInsert()
        //{
        //    return base.OnInsert();
        //}
        #endregion

        #region 扩展属性﻿
        #endregion

        #region 扩展查询﻿
        /// <summary>根据主键 自增ID查找</summary>
        /// <param name="__adminid">主键 自增ID</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<NewsInfo> FindAllByadminid(Int32 __adminid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.adminid, __adminid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.adminid, __adminid);
        }

        /// <summary>根据click查找</summary>
        /// <param name="__click"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<NewsInfo> FindAllByclick(Int32 __click)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.click, __click);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.click, __click);
        }

        /// <summary>根据0:默认 否。      推荐类型10 20 30 40 50.....查找</summary>
        /// <param name="__ishot">0:默认 否。      推荐类型10 20 30 40 50.....</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<NewsInfo> FindAllByishot(Int16 __ishot)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ishot, __ishot);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.ishot, __ishot);
        }

        /// <summary>根据0:未审核。   1:默认 审核通过查找</summary>
        /// <param name="__isverify">0:未审核。   1:默认 审核通过</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<NewsInfo> FindAllByisverify(Int16 __isverify)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.isverify, __isverify);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.isverify, __isverify);
        }

        /// <summary>根据title查找</summary>
        /// <param name="__title"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<NewsInfo> FindAllBytitle(String __title)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.title, __title);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.title, __title);
        }

        /// <summary>根据id查找</summary>
        /// <param name="__id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NewsInfo FindByid(Int32 __id)
        {
            if (Meta.Count >= 1000)
                return Find(_.id, __id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.id, __id);
            // 单对象缓存
            //return Meta.SingleCache[__id];
        }
        #endregion

        #region 高级查询
        // 以下为自定义高级查询的例子

        ///// <summary>
        ///// 查询满足条件的记录集，分页、排序
        ///// </summary>
        ///// <param name="key">关键字</param>
        ///// <param name="orderClause">排序，不带Order By</param>
        ///// <param name="startRowIndex">开始行，0表示第一行</param>
        ///// <param name="maximumRows">最大返回行数，0表示所有行</param>
        ///// <returns>实体集</returns>
        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static EntityList<NewsInfo> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        //{
        //    return FindAll(SearchWhere(key), orderClause, null, startRowIndex, maximumRows);
        //}

        ///// <summary>
        ///// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
        ///// </summary>
        ///// <param name="key">关键字</param>
        ///// <param name="orderClause">排序，不带Order By</param>
        ///// <param name="startRowIndex">开始行，0表示第一行</param>
        ///// <param name="maximumRows">最大返回行数，0表示所有行</param>
        ///// <returns>记录数</returns>
        //public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        //{
        //    return FindCount(SearchWhere(key), null, null, 0, 0);
        //}

        /// <summary>构造搜索条件</summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere(String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);

            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        #endregion
    }
}