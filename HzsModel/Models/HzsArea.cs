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
    /// <summary>区域表</summary>
    [Serializable]
    [DataObject]
    [Description("区域表")]
    [BindIndex("IX_HzsArea_fid", false, "fid")]
    [BindIndex("IX_HzsArea_sortarea", false, "sortarea")]
    [BindIndex("PK__HzsArea__3213E83F7F60ED59", true, "id")]
    [BindIndex("PK_HzsArea_areaid", true, "areaid")]
    [BindTable("HzsArea", Description = "区域表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsArea : IHzsArea
    {
        #region 属性

        private Int64 _areaid;
        /// <summary></summary>
        [DisplayName("Areaid")]
        [Description("")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(1, "areaid", "", null, "bigint", 19, 0, false)]
        public virtual Int64 areaid
        {
            get { return _areaid; }
            set { if (OnPropertyChanging(__.areaid, value)) { _areaid = value; OnPropertyChanged(__.areaid); } }
        }

        private String _sortarea;
        /// <summary>简称</summary>
        [DisplayName("简称")]
        [Description("简称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "sortarea", "简称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String sortarea
        {
            get { return _sortarea; }
            set { if (OnPropertyChanging(__.sortarea, value)) { _sortarea = value; OnPropertyChanged(__.sortarea); } }
        }

        private String _longarea;
        /// <summary>全称</summary>
        [DisplayName("全称")]
        [Description("全称")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "longarea", "全称", null, "nvarchar(100)", 0, 0, true)]
        public virtual String longarea
        {
            get { return _longarea; }
            set { if (OnPropertyChanging(__.longarea, value)) { _longarea = value; OnPropertyChanged(__.longarea); } }
        }

        private Int64 _fid;
        /// <summary></summary>
        [DisplayName("Fid")]
        [Description("")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(4, "fid", "", null, "bigint", 19, 0, false)]
        public virtual Int64 fid
        {
            get { return _fid; }
            set { if (OnPropertyChanging(__.fid, value)) { _fid = value; OnPropertyChanged(__.fid); } }
        }

        private Int32 _grade;
        /// <summary></summary>
        [DisplayName("Grade")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "grade", "", null, "int", 10, 0, false)]
        public virtual Int32 grade
        {
            get { return _grade; }
            set { if (OnPropertyChanging(__.grade, value)) { _grade = value; OnPropertyChanged(__.grade); } }
        }

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(6, "id", "", null, "int", 10, 0, false)]
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
                    case __.areaid : return _areaid;
                    case __.sortarea : return _sortarea;
                    case __.longarea : return _longarea;
                    case __.fid : return _fid;
                    case __.grade : return _grade;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.areaid : _areaid = Convert.ToInt64(value); break;
                    case __.sortarea : _sortarea = Convert.ToString(value); break;
                    case __.longarea : _longarea = Convert.ToString(value); break;
                    case __.fid : _fid = Convert.ToInt64(value); break;
                    case __.grade : _grade = Convert.ToInt32(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得区域表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field areaid = FindByName(__.areaid);

            ///<summary>简称</summary>
            public static readonly Field sortarea = FindByName(__.sortarea);

            ///<summary>全称</summary>
            public static readonly Field longarea = FindByName(__.longarea);

            ///<summary></summary>
            public static readonly Field fid = FindByName(__.fid);

            ///<summary></summary>
            public static readonly Field grade = FindByName(__.grade);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得区域表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String areaid = "areaid";

            ///<summary>简称</summary>
            public const String sortarea = "sortarea";

            ///<summary>全称</summary>
            public const String longarea = "longarea";

            ///<summary></summary>
            public const String fid = "fid";

            ///<summary></summary>
            public const String grade = "grade";

            ///<summary></summary>
            public const String id = "id";

        }
        #endregion
    }

    /// <summary>区域表接口</summary>
    public partial interface IHzsArea
    {
        #region 属性
        /// <summary></summary>
        Int64 areaid { get; set; }

        /// <summary>简称</summary>
        String sortarea { get; set; }

        /// <summary>全称</summary>
        String longarea { get; set; }

        /// <summary></summary>
        Int64 fid { get; set; }

        /// <summary></summary>
        Int32 grade { get; set; }

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