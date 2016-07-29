/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-03-08 09:48:04
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
    /// <summary>合作社新闻展示表</summary>
    [Serializable]
    [DataObject]
    [Description("合作社新闻展示表")]
    [BindIndex("HzsUser_Company_r_FK", false, "uid")]
    [BindIndex("PK__Company__3213E83F2A4B4B5E", true, "id")]
    [BindTable("Company", Description = "合作社新闻展示表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class Company : ICompany
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

        private Int16 _typeid;
        /// <summary></summary>
        [DisplayName("Typeid")]
        [Description("")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(2, "typeid", "", null, "smallint", 5, 0, false)]
        public virtual Int16 typeid
        {
            get { return _typeid; }
            set { if (OnPropertyChanging(__.typeid, value)) { _typeid = value; OnPropertyChanged(__.typeid); } }
        }

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(3, "title", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _content;
        /// <summary></summary>
        [DisplayName("Content")]
        [Description("")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(4, "content", "", null, "ntext", 0, 0, true)]
        public virtual String content
        {
            get { return _content; }
            set { if (OnPropertyChanging(__.content, value)) { _content = value; OnPropertyChanged(__.content); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(5, "intro", "", null, "ntext", 0, 0, true)]
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
        [BindColumn(6, "pic", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic
        {
            get { return _pic; }
            set { if (OnPropertyChanging(__.pic, value)) { _pic = value; OnPropertyChanged(__.pic); } }
        }

        private String _pic2;
        /// <summary></summary>
        [DisplayName("Pic2")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "pic2", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic2
        {
            get { return _pic2; }
            set { if (OnPropertyChanging(__.pic2, value)) { _pic2 = value; OnPropertyChanged(__.pic2); } }
        }

        private String _pic3;
        /// <summary></summary>
        [DisplayName("Pic3")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(8, "pic3", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic3
        {
            get { return _pic3; }
            set { if (OnPropertyChanging(__.pic3, value)) { _pic3 = value; OnPropertyChanged(__.pic3); } }
        }

        private Int64 _click;
        /// <summary>默认0</summary>
        [DisplayName("默认0")]
        [Description("默认0")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(9, "click", "默认0", "0", "bigint", 19, 0, false)]
        public virtual Int64 click
        {
            get { return _click; }
            set { if (OnPropertyChanging(__.click, value)) { _click = value; OnPropertyChanged(__.click); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(10, "addtime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int64 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(11, "id", "", null, "bigint", 19, 0, false)]
        public virtual Int64 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private Int16 _isonepage;
        /// <summary>是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是</summary>
        [DisplayName("是否单页新闻类型默认0不是例如企业介绍为单页1：是")]
        [Description("是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(12, "isonepage", "是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是", null, "smallint", 5, 0, false)]
        public virtual Int16 isonepage
        {
            get { return _isonepage; }
            set { if (OnPropertyChanging(__.isonepage, value)) { _isonepage = value; OnPropertyChanged(__.isonepage); } }
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
                    case __.typeid : return _typeid;
                    case __.title : return _title;
                    case __.content : return _content;
                    case __.intro : return _intro;
                    case __.pic : return _pic;
                    case __.pic2 : return _pic2;
                    case __.pic3 : return _pic3;
                    case __.click : return _click;
                    case __.addtime : return _addtime;
                    case __.id : return _id;
                    case __.isonepage : return _isonepage;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.typeid : _typeid = Convert.ToInt16(value); break;
                    case __.title : _title = Convert.ToString(value); break;
                    case __.content : _content = Convert.ToString(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.pic : _pic = Convert.ToString(value); break;
                    case __.pic2 : _pic2 = Convert.ToString(value); break;
                    case __.pic3 : _pic3 = Convert.ToString(value); break;
                    case __.click : _click = Convert.ToInt64(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.id : _id = Convert.ToInt64(value); break;
                    case __.isonepage : _isonepage = Convert.ToInt16(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得合作社新闻展示表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary></summary>
            public static readonly Field typeid = FindByName(__.typeid);

            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field content = FindByName(__.content);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary></summary>
            public static readonly Field pic = FindByName(__.pic);

            ///<summary></summary>
            public static readonly Field pic2 = FindByName(__.pic2);

            ///<summary></summary>
            public static readonly Field pic3 = FindByName(__.pic3);

            ///<summary>默认0</summary>
            public static readonly Field click = FindByName(__.click);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是</summary>
            public static readonly Field isonepage = FindByName(__.isonepage);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得合作社新闻展示表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String uid = "uid";

            ///<summary></summary>
            public const String typeid = "typeid";

            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String content = "content";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary></summary>
            public const String pic = "pic";

            ///<summary></summary>
            public const String pic2 = "pic2";

            ///<summary></summary>
            public const String pic3 = "pic3";

            ///<summary>默认0</summary>
            public const String click = "click";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String id = "id";

            ///<summary>是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是</summary>
            public const String isonepage = "isonepage";

        }
        #endregion
    }

    /// <summary>合作社新闻展示表接口</summary>
    public partial interface ICompany
    {
        #region 属性
        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary></summary>
        Int16 typeid { get; set; }

        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String content { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary></summary>
        String pic { get; set; }

        /// <summary></summary>
        String pic2 { get; set; }

        /// <summary></summary>
        String pic3 { get; set; }

        /// <summary>默认0</summary>
        Int64 click { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        Int64 id { get; set; }

        /// <summary>是否单页新闻类型 默认0（不是） 例如企业介绍为单页 1：是</summary>
        Int16 isonepage { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}