/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-03-06 08:50:41
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
    /// <summary>地方信息</summary>
    [Serializable]
    [DataObject]
    [Description("地方信息")]
    [BindIndex("IX_PlacesInfo_areaid", false, "areaid")]
    [BindIndex("IX_PlacesInfo_title", false, "title")]
    [BindIndex("IX_PlacesInfo_typeid", false, "typeid")]
    [BindIndex("PK__PlacesIn__3213E83F45F365D3", true, "id")]
    [BindTable("PlacesInfo", Description = "地方信息", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class PlacesInfo : IPlacesInfo
    {
        #region 属性

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(1, "title", "", null, "varchar(200)", 0, 0, false)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _content;
        /// <summary></summary>
        [DisplayName("Content")]
        [Description("")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(2, "content", "", null, "text", 0, 0, false)]
        public virtual String content
        {
            get { return _content; }
            set { if (OnPropertyChanging(__.content, value)) { _content = value; OnPropertyChanged(__.content); } }
        }

        private Int32 _typeid;
        /// <summary></summary>
        [DisplayName("Typeid")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "typeid", "", null, "int", 10, 0, false)]
        public virtual Int32 typeid
        {
            get { return _typeid; }
            set { if (OnPropertyChanging(__.typeid, value)) { _typeid = value; OnPropertyChanged(__.typeid); } }
        }

        private String _source;
        /// <summary></summary>
        [DisplayName("Source")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "source", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String source
        {
            get { return _source; }
            set { if (OnPropertyChanging(__.source, value)) { _source = value; OnPropertyChanged(__.source); } }
        }

        private String _areacode;
        /// <summary></summary>
        [DisplayName("Areacode")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "areacode", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String areacode
        {
            get { return _areacode; }
            set { if (OnPropertyChanging(__.areacode, value)) { _areacode = value; OnPropertyChanged(__.areacode); } }
        }

        private String _pic;
        /// <summary></summary>
        [DisplayName("Pic")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "pic", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String pic
        {
            get { return _pic; }
            set { if (OnPropertyChanging(__.pic, value)) { _pic = value; OnPropertyChanged(__.pic); } }
        }

        private Int16 _ishot;
        /// <summary></summary>
        [DisplayName("IsHot")]
        [Description("")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(7, "ishot", "", null, "smallint", 5, 0, false)]
        public virtual Int16 ishot
        {
            get { return _ishot; }
            set { if (OnPropertyChanging(__.ishot, value)) { _ishot = value; OnPropertyChanged(__.ishot); } }
        }

        private Int64 _areaid;
        /// <summary></summary>
        [DisplayName("Areaid")]
        [Description("")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(8, "areaid", "", null, "bigint", 19, 0, false)]
        public virtual Int64 areaid
        {
            get { return _areaid; }
            set { if (OnPropertyChanging(__.areaid, value)) { _areaid = value; OnPropertyChanged(__.areaid); } }
        }

        private Int16 _isdel;
        /// <summary>0:默认。   1:删除</summary>
        [DisplayName("0:默认")]
        [Description("0:默认。   1:删除")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(9, "isdel", "0:默认。   1:删除", "0", "smallint", 5, 0, false)]
        public virtual Int16 isdel
        {
            get { return _isdel; }
            set { if (OnPropertyChanging(__.isdel, value)) { _isdel = value; OnPropertyChanged(__.isdel); } }
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

        private Int32 _adminid;
        /// <summary></summary>
        [DisplayName("Adminid")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "adminid", "", null, "int", 10, 0, false)]
        public virtual Int32 adminid
        {
            get { return _adminid; }
            set { if (OnPropertyChanging(__.adminid, value)) { _adminid = value; OnPropertyChanged(__.adminid); } }
        }

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(12, "id", "", null, "int", 10, 0, false)]
        public virtual Int32 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _intro;
        /// <summary>内容简介</summary>
        [DisplayName("内容简介")]
        [Description("内容简介")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(13, "intro", "内容简介", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private Int32 _click;
        /// <summary>点击量</summary>
        [DisplayName("点击量")]
        [Description("点击量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "click", "点击量", "0", "int", 10, 0, false)]
        public virtual Int32 click
        {
            get { return _click; }
            set { if (OnPropertyChanging(__.click, value)) { _click = value; OnPropertyChanged(__.click); } }
        }

        private Int16 _isverify;
        /// <summary>10审核 20待审核 40未审核</summary>
        [DisplayName("10审核20待审核40未审核")]
        [Description("10审核 20待审核 40未审核")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(15, "isverify", "10审核 20待审核 40未审核", "10", "smallint", 5, 0, false)]
        public virtual Int16 isverify
        {
            get { return _isverify; }
            set { if (OnPropertyChanging(__.isverify, value)) { _isverify = value; OnPropertyChanged(__.isverify); } }
        }

        private String _editor;
        /// <summary></summary>
        [DisplayName("Editor")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "editor", "", null, "varchar(50)", 0, 0, false)]
        public virtual String editor
        {
            get { return _editor; }
            set { if (OnPropertyChanging(__.editor, value)) { _editor = value; OnPropertyChanged(__.editor); } }
        }

        private String _seotitle;
        /// <summary></summary>
        [DisplayName("Seotitle")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(17, "seotitle", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String seotitle
        {
            get { return _seotitle; }
            set { if (OnPropertyChanging(__.seotitle, value)) { _seotitle = value; OnPropertyChanged(__.seotitle); } }
        }

        private String _seointro;
        /// <summary></summary>
        [DisplayName("Seointro")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(18, "seointro", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String seointro
        {
            get { return _seointro; }
            set { if (OnPropertyChanging(__.seointro, value)) { _seointro = value; OnPropertyChanged(__.seointro); } }
        }

        private String _seokeyword;
        /// <summary></summary>
        [DisplayName("Seokeyword")]
        [Description("")]
        [DataObjectField(false, false, true, 300)]
        [BindColumn(19, "seokeyword", "", null, "nvarchar(300)", 0, 0, true)]
        public virtual String seokeyword
        {
            get { return _seokeyword; }
            set { if (OnPropertyChanging(__.seokeyword, value)) { _seokeyword = value; OnPropertyChanged(__.seokeyword); } }
        }

        private String _htmlpath;
        /// <summary>静态页地址</summary>
        [DisplayName("静态页地址")]
        [Description("静态页地址")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(20, "htmlpath", "静态页地址", null, "nvarchar(100)", 0, 0, true)]
        public virtual String htmlpath
        {
            get { return _htmlpath; }
            set { if (OnPropertyChanging(__.htmlpath, value)) { _htmlpath = value; OnPropertyChanged(__.htmlpath); } }
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
                    case __.title : return _title;
                    case __.content : return _content;
                    case __.typeid : return _typeid;
                    case __.source : return _source;
                    case __.areacode : return _areacode;
                    case __.pic : return _pic;
                    case __.ishot : return _ishot;
                    case __.areaid : return _areaid;
                    case __.isdel : return _isdel;
                    case __.addtime : return _addtime;
                    case __.adminid : return _adminid;
                    case __.id : return _id;
                    case __.intro : return _intro;
                    case __.click : return _click;
                    case __.isverify : return _isverify;
                    case __.editor : return _editor;
                    case __.seotitle : return _seotitle;
                    case __.seointro : return _seointro;
                    case __.seokeyword : return _seokeyword;
                    case __.htmlpath : return _htmlpath;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.title : _title = Convert.ToString(value); break;
                    case __.content : _content = Convert.ToString(value); break;
                    case __.typeid : _typeid = Convert.ToInt32(value); break;
                    case __.source : _source = Convert.ToString(value); break;
                    case __.areacode : _areacode = Convert.ToString(value); break;
                    case __.pic : _pic = Convert.ToString(value); break;
                    case __.ishot : _ishot = Convert.ToInt16(value); break;
                    case __.areaid : _areaid = Convert.ToInt64(value); break;
                    case __.isdel : _isdel = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.adminid : _adminid = Convert.ToInt32(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.click : _click = Convert.ToInt32(value); break;
                    case __.isverify : _isverify = Convert.ToInt16(value); break;
                    case __.editor : _editor = Convert.ToString(value); break;
                    case __.seotitle : _seotitle = Convert.ToString(value); break;
                    case __.seointro : _seointro = Convert.ToString(value); break;
                    case __.seokeyword : _seokeyword = Convert.ToString(value); break;
                    case __.htmlpath : _htmlpath = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得地方信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field content = FindByName(__.content);

            ///<summary></summary>
            public static readonly Field typeid = FindByName(__.typeid);

            ///<summary></summary>
            public static readonly Field source = FindByName(__.source);

            ///<summary></summary>
            public static readonly Field areacode = FindByName(__.areacode);

            ///<summary></summary>
            public static readonly Field pic = FindByName(__.pic);

            ///<summary></summary>
            public static readonly Field ishot = FindByName(__.ishot);

            ///<summary></summary>
            public static readonly Field areaid = FindByName(__.areaid);

            ///<summary>0:默认。   1:删除</summary>
            public static readonly Field isdel = FindByName(__.isdel);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field adminid = FindByName(__.adminid);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>内容简介</summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary>点击量</summary>
            public static readonly Field click = FindByName(__.click);

            ///<summary>10审核 20待审核 40未审核</summary>
            public static readonly Field isverify = FindByName(__.isverify);

            ///<summary></summary>
            public static readonly Field editor = FindByName(__.editor);

            ///<summary></summary>
            public static readonly Field seotitle = FindByName(__.seotitle);

            ///<summary></summary>
            public static readonly Field seointro = FindByName(__.seointro);

            ///<summary></summary>
            public static readonly Field seokeyword = FindByName(__.seokeyword);

            ///<summary>静态页地址</summary>
            public static readonly Field htmlpath = FindByName(__.htmlpath);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得地方信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String content = "content";

            ///<summary></summary>
            public const String typeid = "typeid";

            ///<summary></summary>
            public const String source = "source";

            ///<summary></summary>
            public const String areacode = "areacode";

            ///<summary></summary>
            public const String pic = "pic";

            ///<summary></summary>
            public const String ishot = "ishot";

            ///<summary></summary>
            public const String areaid = "areaid";

            ///<summary>0:默认。   1:删除</summary>
            public const String isdel = "isdel";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String adminid = "adminid";

            ///<summary></summary>
            public const String id = "id";

            ///<summary>内容简介</summary>
            public const String intro = "intro";

            ///<summary>点击量</summary>
            public const String click = "click";

            ///<summary>10审核 20待审核 40未审核</summary>
            public const String isverify = "isverify";

            ///<summary></summary>
            public const String editor = "editor";

            ///<summary></summary>
            public const String seotitle = "seotitle";

            ///<summary></summary>
            public const String seointro = "seointro";

            ///<summary></summary>
            public const String seokeyword = "seokeyword";

            ///<summary>静态页地址</summary>
            public const String htmlpath = "htmlpath";

        }
        #endregion
    }

    /// <summary>地方信息接口</summary>
    public partial interface IPlacesInfo
    {
        #region 属性
        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String content { get; set; }

        /// <summary></summary>
        Int32 typeid { get; set; }

        /// <summary></summary>
        String source { get; set; }

        /// <summary></summary>
        String areacode { get; set; }

        /// <summary></summary>
        String pic { get; set; }

        /// <summary></summary>
        Int16 ishot { get; set; }

        /// <summary></summary>
        Int64 areaid { get; set; }

        /// <summary>0:默认。   1:删除</summary>
        Int16 isdel { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        Int32 adminid { get; set; }

        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary>内容简介</summary>
        String intro { get; set; }

        /// <summary>点击量</summary>
        Int32 click { get; set; }

        /// <summary>10审核 20待审核 40未审核</summary>
        Int16 isverify { get; set; }

        /// <summary></summary>
        String editor { get; set; }

        /// <summary></summary>
        String seotitle { get; set; }

        /// <summary></summary>
        String seointro { get; set; }

        /// <summary></summary>
        String seokeyword { get; set; }

        /// <summary>静态页地址</summary>
        String htmlpath { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}