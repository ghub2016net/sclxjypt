/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-11 09:08:47
 * 版权：版权所有 (C)HIK 2014
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace HzsModel.Models
{
    /// <summary>合作社会员荣誉证书表</summary>
    [Serializable]
    [DataObject]
    [Description("合作社会员荣誉证书表")]
    [BindIndex("HzsUser_HzsGlory_r_FK", false, "uid")]
    [BindIndex("PK__HzsGlory__3213E83F1273C1CD", true, "id")]
    [BindTable("HzsGlory", Description = "合作社会员荣誉证书表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsGlory : IHzsGlory
    {
        #region 属性

        private Int32 _uid;
        /// <summary></summary>
        [DisplayName("Uid")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(1, "uid", "", null, "int", 10, 0, false)]
        public virtual Int32 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(2, "title", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(3, "intro", "", null, "text", 0, 0, false)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private String _pic;
        /// <summary></summary>
        [DisplayName("Pic")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(4, "pic", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic
        {
            get { return _pic; }
            set { if (OnPropertyChanging(__.pic, value)) { _pic = value; OnPropertyChanged(__.pic); } }
        }

        private Int16 _isverify;
        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        [DisplayName("10:审核通过默认")]
        [Description("10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(5, "isverify", "10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过", "10", "smallint", 5, 0, false)]
        public virtual Int16 isverify
        {
            get { return _isverify; }
            set { if (OnPropertyChanging(__.isverify, value)) { _isverify = value; OnPropertyChanged(__.isverify); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(6, "addtime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(7, "id", "", null, "int", 10, 0, false)]
        public virtual Int32 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.uid : return _uid;
                    case __.title : return _title;
                    case __.intro : return _intro;
                    case __.pic : return _pic;
                    case __.isverify : return _isverify;
                    case __.addtime : return _addtime;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.title : _title = Convert.ToString(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.pic : _pic = Convert.ToString(value); break;
                    case __.isverify : _isverify = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得合作社会员荣誉证书表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary></summary>
            public static readonly Field pic = FindByName(__.pic);

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public static readonly Field isverify = FindByName(__.isverify);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得合作社会员荣誉证书表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String uid = "uid";

            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary></summary>
            public const String pic = "pic";

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public const String isverify = "isverify";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String id = "id";

        }
        #endregion
    }

    /// <summary>合作社会员荣誉证书表接口</summary>
    public partial interface IHzsGlory
    {
        #region 属性
        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary></summary>
        String pic { get; set; }

        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        Int16 isverify { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        Int32 id { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}