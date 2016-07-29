/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-12 16:16:17
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
    /// <summary>Link</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Link", true, "id")]
    [BindTable("Link", Description = "", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class Link : ILink
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

        private Int32 _linkType;
        /// <summary>0为文字链接1为图片链接  (默认为0)</summary>
        [DisplayName("0为文字链接1为图片链接默认为0")]
        [Description("0为文字链接1为图片链接  (默认为0)")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "linkType", "0为文字链接1为图片链接  (默认为0)", "0", "int", 10, 0, false)]
        public virtual Int32 linkType
        {
            get { return _linkType; }
            set { if (OnPropertyChanging(__.linkType, value)) { _linkType = value; OnPropertyChanged(__.linkType); } }
        }

        private String _linkName;
        /// <summary>友情链接名称</summary>
        [DisplayName("友情链接名称")]
        [Description("友情链接名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "linkName", "友情链接名称", null, "varchar(50)", 0, 0, false)]
        public virtual String linkName
        {
            get { return _linkName; }
            set { if (OnPropertyChanging(__.linkName, value)) { _linkName = value; OnPropertyChanged(__.linkName); } }
        }

        private String _linkUrl;
        /// <summary>url链接地址</summary>
        [DisplayName("url链接地址")]
        [Description("url链接地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "linkUrl", "url链接地址", null, "varchar(50)", 0, 0, false)]
        public virtual String linkUrl
        {
            get { return _linkUrl; }
            set { if (OnPropertyChanging(__.linkUrl, value)) { _linkUrl = value; OnPropertyChanged(__.linkUrl); } }
        }

        private String _linkImgurl;
        /// <summary>图片地址</summary>
        [DisplayName("图片地址")]
        [Description("图片地址")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "linkImgurl", "图片地址", null, "varchar(100)", 0, 0, false)]
        public virtual String linkImgurl
        {
            get { return _linkImgurl; }
            set { if (OnPropertyChanging(__.linkImgurl, value)) { _linkImgurl = value; OnPropertyChanged(__.linkImgurl); } }
        }

        private DateTime _addDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "addDate", "创建时间", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addDate
        {
            get { return _addDate; }
            set { if (OnPropertyChanging(__.addDate, value)) { _addDate = value; OnPropertyChanged(__.addDate); } }
        }

        private Int32 _isdel;
        /// <summary>是否删除(0:否 1:删除)   默认0</summary>
        [DisplayName("是否删除0:否1:删除默认0")]
        [Description("是否删除(0:否 1:删除)   默认0")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "isdel", "是否删除(0:否 1:删除)   默认0", "0", "int", 10, 0, false)]
        public virtual Int32 isdel
        {
            get { return _isdel; }
            set { if (OnPropertyChanging(__.isdel, value)) { _isdel = value; OnPropertyChanged(__.isdel); } }
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
                    case __.linkType : return _linkType;
                    case __.linkName : return _linkName;
                    case __.linkUrl : return _linkUrl;
                    case __.linkImgurl : return _linkImgurl;
                    case __.addDate : return _addDate;
                    case __.isdel : return _isdel;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.linkType : _linkType = Convert.ToInt32(value); break;
                    case __.linkName : _linkName = Convert.ToString(value); break;
                    case __.linkUrl : _linkUrl = Convert.ToString(value); break;
                    case __.linkImgurl : _linkImgurl = Convert.ToString(value); break;
                    case __.addDate : _addDate = Convert.ToDateTime(value); break;
                    case __.isdel : _isdel = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Link字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>0为文字链接1为图片链接  (默认为0)</summary>
            public static readonly Field linkType = FindByName(__.linkType);

            ///<summary>友情链接名称</summary>
            public static readonly Field linkName = FindByName(__.linkName);

            ///<summary>url链接地址</summary>
            public static readonly Field linkUrl = FindByName(__.linkUrl);

            ///<summary>图片地址</summary>
            public static readonly Field linkImgurl = FindByName(__.linkImgurl);

            ///<summary>创建时间</summary>
            public static readonly Field addDate = FindByName(__.addDate);

            ///<summary>是否删除(0:否 1:删除)   默认0</summary>
            public static readonly Field isdel = FindByName(__.isdel);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Link字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary>0为文字链接1为图片链接  (默认为0)</summary>
            public const String linkType = "linkType";

            ///<summary>友情链接名称</summary>
            public const String linkName = "linkName";

            ///<summary>url链接地址</summary>
            public const String linkUrl = "linkUrl";

            ///<summary>图片地址</summary>
            public const String linkImgurl = "linkImgurl";

            ///<summary>创建时间</summary>
            public const String addDate = "addDate";

            ///<summary>是否删除(0:否 1:删除)   默认0</summary>
            public const String isdel = "isdel";

        }
        #endregion
    }

    /// <summary>Link接口</summary>
    /// <remarks></remarks>
    public partial interface ILink
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary>0为文字链接1为图片链接  (默认为0)</summary>
        Int32 linkType { get; set; }

        /// <summary>友情链接名称</summary>
        String linkName { get; set; }

        /// <summary>url链接地址</summary>
        String linkUrl { get; set; }

        /// <summary>图片地址</summary>
        String linkImgurl { get; set; }

        /// <summary>创建时间</summary>
        DateTime addDate { get; set; }

        /// <summary>是否删除(0:否 1:删除)   默认0</summary>
        Int32 isdel { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}