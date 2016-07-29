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
    /// <summary>新闻信息表</summary>
    [Serializable]
    [DataObject]
    [Description("新闻信息表")]
    [BindIndex("adminuser_news_r_FK", false, "adminid")]
    [BindIndex("IX_NewsInfo_click", false, "click")]
    [BindIndex("IX_NewsInfo_ishot", false, "ishot")]
    [BindIndex("IX_NewsInfo_isverify", false, "isverify")]
    [BindIndex("IX_NewsInfo_title", false, "title")]
    [BindIndex("PK__NewsInfo__3213E83F22AA2996", true, "id")]
    [BindTable("NewsInfo", Description = "新闻信息表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class NewsInfo : INewsInfo
    {
        #region 属性

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "id", "", null, "int", 10, 0, false)]
        public virtual Int32 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private Int32 _adminid;
        /// <summary>主键 自增ID</summary>
        [DisplayName("主键自增ID")]
        [Description("主键 自增ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "adminid", "主键 自增ID", null, "int", 10, 0, false)]
        public virtual Int32 adminid
        {
            get { return _adminid; }
            set { if (OnPropertyChanging(__.adminid, value)) { _adminid = value; OnPropertyChanged(__.adminid); } }
        }

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "title", "", null, "varchar(200)", 0, 0, false)]
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

        private String _nimg;
        /// <summary></summary>
        [DisplayName("Nimg")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "nimg", "", null, "varchar(200)", 0, 0, false)]
        public virtual String nimg
        {
            get { return _nimg; }
            set { if (OnPropertyChanging(__.nimg, value)) { _nimg = value; OnPropertyChanged(__.nimg); } }
        }

        private String _nvideo;
        /// <summary></summary>
        [DisplayName("Nvideo")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "nvideo", "", null, "varchar(200)", 0, 0, false)]
        public virtual String nvideo
        {
            get { return _nvideo; }
            set { if (OnPropertyChanging(__.nvideo, value)) { _nvideo = value; OnPropertyChanged(__.nvideo); } }
        }

        private String _nvideoimg;
        /// <summary></summary>
        [DisplayName("Nvideoimg")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "nvideoimg", "", null, "varchar(200)", 0, 0, false)]
        public virtual String nvideoimg
        {
            get { return _nvideoimg; }
            set { if (OnPropertyChanging(__.nvideoimg, value)) { _nvideoimg = value; OnPropertyChanged(__.nvideoimg); } }
        }

        private Int16 _ishot;
        /// <summary>0:默认 否。      推荐类型10 20 30 40 50.....</summary>
        [DisplayName("0:默认否")]
        [Description("0:默认 否。      推荐类型10 20 30 40 50.....")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(8, "ishot", "0:默认 否。      推荐类型10 20 30 40 50.....", "0", "smallint", 5, 0, false)]
        public virtual Int16 ishot
        {
            get { return _ishot; }
            set { if (OnPropertyChanging(__.ishot, value)) { _ishot = value; OnPropertyChanged(__.ishot); } }
        }

        private Int16 _ispublic;
        /// <summary>0:公开默认。   1:不公开</summary>
        [DisplayName("0:公开默认")]
        [Description("0:公开默认。   1:不公开")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(9, "ispublic", "0:公开默认。   1:不公开", "0", "smallint", 5, 0, false)]
        public virtual Int16 ispublic
        {
            get { return _ispublic; }
            set { if (OnPropertyChanging(__.ispublic, value)) { _ispublic = value; OnPropertyChanged(__.ispublic); } }
        }

        private Int16 _isverify;
        /// <summary>0:未审核。   1:默认 审核通过</summary>
        [DisplayName("0:未审核")]
        [Description("0:未审核。   1:默认 审核通过")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(10, "isverify", "0:未审核。   1:默认 审核通过", "1", "smallint", 5, 0, false)]
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
        [BindColumn(11, "editor", "", null, "varchar(50)", 0, 0, false)]
        public virtual String editor
        {
            get { return _editor; }
            set { if (OnPropertyChanging(__.editor, value)) { _editor = value; OnPropertyChanged(__.editor); } }
        }

        private DateTime _addtime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "addtime", "添加时间", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int32 _ntypeid;
        /// <summary>新闻类型</summary>
        [DisplayName("新闻类型")]
        [Description("新闻类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "ntypeid", "新闻类型", null, "int", 10, 0, false)]
        public virtual Int32 ntypeid
        {
            get { return _ntypeid; }
            set { if (OnPropertyChanging(__.ntypeid, value)) { _ntypeid = value; OnPropertyChanged(__.ntypeid); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(14, "intro", "", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private Int32 _click;
        /// <summary></summary>
        [DisplayName("Click")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "click", "", null, "int", 10, 0, false)]
        public virtual Int32 click
        {
            get { return _click; }
            set { if (OnPropertyChanging(__.click, value)) { _click = value; OnPropertyChanged(__.click); } }
        }

        private String _seotitle;
        /// <summary></summary>
        [DisplayName("Seotitle")]
        [Description("")]
        [DataObjectField(false, false, true, 300)]
        [BindColumn(16, "seotitle", "", null, "nvarchar(300)", 0, 0, true)]
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
        [BindColumn(17, "seointro", "", null, "nvarchar(500)", 0, 0, true)]
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
        [BindColumn(18, "seokeyword", "", null, "nvarchar(300)", 0, 0, true)]
        public virtual String seokeyword
        {
            get { return _seokeyword; }
            set { if (OnPropertyChanging(__.seokeyword, value)) { _seokeyword = value; OnPropertyChanged(__.seokeyword); } }
        }

        private String _htmlpath;
        /// <summary>html</summary>
        [DisplayName("html")]
        [Description("html")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(19, "htmlpath", "html", null, "nvarchar(100)", 0, 0, true)]
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
                    case __.id : return _id;
                    case __.adminid : return _adminid;
                    case __.title : return _title;
                    case __.content : return _content;
                    case __.nimg : return _nimg;
                    case __.nvideo : return _nvideo;
                    case __.nvideoimg : return _nvideoimg;
                    case __.ishot : return _ishot;
                    case __.ispublic : return _ispublic;
                    case __.isverify : return _isverify;
                    case __.editor : return _editor;
                    case __.addtime : return _addtime;
                    case __.ntypeid : return _ntypeid;
                    case __.intro : return _intro;
                    case __.click : return _click;
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
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.adminid : _adminid = Convert.ToInt32(value); break;
                    case __.title : _title = Convert.ToString(value); break;
                    case __.content : _content = Convert.ToString(value); break;
                    case __.nimg : _nimg = Convert.ToString(value); break;
                    case __.nvideo : _nvideo = Convert.ToString(value); break;
                    case __.nvideoimg : _nvideoimg = Convert.ToString(value); break;
                    case __.ishot : _ishot = Convert.ToInt16(value); break;
                    case __.ispublic : _ispublic = Convert.ToInt16(value); break;
                    case __.isverify : _isverify = Convert.ToInt16(value); break;
                    case __.editor : _editor = Convert.ToString(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.ntypeid : _ntypeid = Convert.ToInt32(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.click : _click = Convert.ToInt32(value); break;
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
        /// <summary>取得新闻信息表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>主键 自增ID</summary>
            public static readonly Field adminid = FindByName(__.adminid);

            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field content = FindByName(__.content);

            ///<summary></summary>
            public static readonly Field nimg = FindByName(__.nimg);

            ///<summary></summary>
            public static readonly Field nvideo = FindByName(__.nvideo);

            ///<summary></summary>
            public static readonly Field nvideoimg = FindByName(__.nvideoimg);

            ///<summary>0:默认 否。      推荐类型10 20 30 40 50.....</summary>
            public static readonly Field ishot = FindByName(__.ishot);

            ///<summary>0:公开默认。   1:不公开</summary>
            public static readonly Field ispublic = FindByName(__.ispublic);

            ///<summary>0:未审核。   1:默认 审核通过</summary>
            public static readonly Field isverify = FindByName(__.isverify);

            ///<summary></summary>
            public static readonly Field editor = FindByName(__.editor);

            ///<summary>添加时间</summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary>新闻类型</summary>
            public static readonly Field ntypeid = FindByName(__.ntypeid);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary></summary>
            public static readonly Field click = FindByName(__.click);

            ///<summary></summary>
            public static readonly Field seotitle = FindByName(__.seotitle);

            ///<summary></summary>
            public static readonly Field seointro = FindByName(__.seointro);

            ///<summary></summary>
            public static readonly Field seokeyword = FindByName(__.seokeyword);

            ///<summary>html</summary>
            public static readonly Field htmlpath = FindByName(__.htmlpath);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得新闻信息表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary>主键 自增ID</summary>
            public const String adminid = "adminid";

            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String content = "content";

            ///<summary></summary>
            public const String nimg = "nimg";

            ///<summary></summary>
            public const String nvideo = "nvideo";

            ///<summary></summary>
            public const String nvideoimg = "nvideoimg";

            ///<summary>0:默认 否。      推荐类型10 20 30 40 50.....</summary>
            public const String ishot = "ishot";

            ///<summary>0:公开默认。   1:不公开</summary>
            public const String ispublic = "ispublic";

            ///<summary>0:未审核。   1:默认 审核通过</summary>
            public const String isverify = "isverify";

            ///<summary></summary>
            public const String editor = "editor";

            ///<summary>添加时间</summary>
            public const String addtime = "addtime";

            ///<summary>新闻类型</summary>
            public const String ntypeid = "ntypeid";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary></summary>
            public const String click = "click";

            ///<summary></summary>
            public const String seotitle = "seotitle";

            ///<summary></summary>
            public const String seointro = "seointro";

            ///<summary></summary>
            public const String seokeyword = "seokeyword";

            ///<summary>html</summary>
            public const String htmlpath = "htmlpath";

        }
        #endregion

        #region 手动添加的关联属性
        /// <summary>
        /// 新闻类型名称
        /// </summary>
        public String tname { get; set; } 
        #endregion
    }

    /// <summary>新闻信息表接口</summary>
    public partial interface INewsInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary>主键 自增ID</summary>
        Int32 adminid { get; set; }

        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String content { get; set; }

        /// <summary></summary>
        String nimg { get; set; }

        /// <summary></summary>
        String nvideo { get; set; }

        /// <summary></summary>
        String nvideoimg { get; set; }

        /// <summary>0:默认 否。      推荐类型10 20 30 40 50.....</summary>
        Int16 ishot { get; set; }

        /// <summary>0:公开默认。   1:不公开</summary>
        Int16 ispublic { get; set; }

        /// <summary>0:未审核。   1:默认 审核通过</summary>
        Int16 isverify { get; set; }

        /// <summary></summary>
        String editor { get; set; }

        /// <summary>添加时间</summary>
        DateTime addtime { get; set; }

        /// <summary>新闻类型</summary>
        Int32 ntypeid { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary></summary>
        Int32 click { get; set; }

        /// <summary></summary>
        String seotitle { get; set; }

        /// <summary></summary>
        String seointro { get; set; }

        /// <summary></summary>
        String seokeyword { get; set; }

        /// <summary>html</summary>
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