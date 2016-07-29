/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-26 09:53:56
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
    /// <summary>合作社分类</summary>
    [Serializable]
    [DataObject]
    [Description("合作社分类")]
    [BindIndex("PK_HzsClass", true, "hid,sortid")]
    [BindTable("HzsClass", Description = "合作社分类", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsClass : IHzsClass
    {
        #region 属性

        private Int32 _hid;
        /// <summary>主键ID，查询时使用此ID</summary>
        [DisplayName("主键ID，查询时使用此ID")]
        [Description("主键ID，查询时使用此ID")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "hid", "主键ID，查询时使用此ID", "0", "int", 10, 0, false)]
        public virtual Int32 hid
        {
            get { return _hid; }
            set { if (OnPropertyChanging(__.hid, value)) { _hid = value; OnPropertyChanged(__.hid); } }
        }

        private Int32 _sortid;
        /// <summary>序号ID，不使用</summary>
        [DisplayName("序号ID，不使用")]
        [Description("序号ID，不使用")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(2, "sortid", "序号ID，不使用", null, "int", 10, 0, false)]
        public virtual Int32 sortid
        {
            get { return _sortid; }
            set { if (OnPropertyChanging(__.sortid, value)) { _sortid = value; OnPropertyChanged(__.sortid); } }
        }

        private Int16 _depth;
        /// <summary></summary>
        [DisplayName("Depth")]
        [Description("")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(3, "depth", "", null, "smallint", 5, 0, false)]
        public virtual Int16 depth
        {
            get { return _depth; }
            set { if (OnPropertyChanging(__.depth, value)) { _depth = value; OnPropertyChanged(__.depth); } }
        }

        private Int32 _array;
        /// <summary></summary>
        [DisplayName("Array")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "array", "", null, "int", 10, 0, false)]
        public virtual Int32 array
        {
            get { return _array; }
            set { if (OnPropertyChanging(__.array, value)) { _array = value; OnPropertyChanged(__.array); } }
        }

        private String _cname;
        /// <summary></summary>
        [DisplayName("Cname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "cname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String cname
        {
            get { return _cname; }
            set { if (OnPropertyChanging(__.cname, value)) { _cname = value; OnPropertyChanged(__.cname); } }
        }

        private Int32 _pid;
        /// <summary></summary>
        [DisplayName("Pid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "pid", "", null, "int", 10, 0, false)]
        public virtual Int32 pid
        {
            get { return _pid; }
            set { if (OnPropertyChanging(__.pid, value)) { _pid = value; OnPropertyChanged(__.pid); } }
        }

        private Int16 _ispublic;
        /// <summary>0:默认公开。   1:不公开</summary>
        [DisplayName("0:默认公开")]
        [Description("0:默认公开。   1:不公开")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(7, "ispublic", "0:默认公开。   1:不公开", null, "smallint", 5, 0, false)]
        public virtual Int16 ispublic
        {
            get { return _ispublic; }
            set { if (OnPropertyChanging(__.ispublic, value)) { _ispublic = value; OnPropertyChanged(__.ispublic); } }
        }

        private Int32 _isrose;
        /// <summary>默认0 </summary>
        [DisplayName("默认0")]
        [Description("默认0 ")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "isrose", "默认0 ", null, "int", 10, 0, false)]
        public virtual Int32 isrose
        {
            get { return _isrose; }
            set { if (OnPropertyChanging(__.isrose, value)) { _isrose = value; OnPropertyChanged(__.isrose); } }
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
                    case __.hid : return _hid;
                    case __.sortid : return _sortid;
                    case __.depth : return _depth;
                    case __.array : return _array;
                    case __.cname : return _cname;
                    case __.pid : return _pid;
                    case __.ispublic : return _ispublic;
                    case __.isrose : return _isrose;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.hid : _hid = Convert.ToInt32(value); break;
                    case __.sortid : _sortid = Convert.ToInt32(value); break;
                    case __.depth : _depth = Convert.ToInt16(value); break;
                    case __.array : _array = Convert.ToInt32(value); break;
                    case __.cname : _cname = Convert.ToString(value); break;
                    case __.pid : _pid = Convert.ToInt32(value); break;
                    case __.ispublic : _ispublic = Convert.ToInt16(value); break;
                    case __.isrose : _isrose = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得合作社分类字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID，查询时使用此ID</summary>
            public static readonly Field hid = FindByName(__.hid);

            ///<summary>序号ID，不使用</summary>
            public static readonly Field sortid = FindByName(__.sortid);

            ///<summary></summary>
            public static readonly Field depth = FindByName(__.depth);

            ///<summary></summary>
            public static readonly Field array = FindByName(__.array);

            ///<summary></summary>
            public static readonly Field cname = FindByName(__.cname);

            ///<summary></summary>
            public static readonly Field pid = FindByName(__.pid);

            ///<summary>0:默认公开。   1:不公开</summary>
            public static readonly Field ispublic = FindByName(__.ispublic);

            ///<summary>默认0 </summary>
            public static readonly Field isrose = FindByName(__.isrose);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得合作社分类字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID，查询时使用此ID</summary>
            public const String hid = "hid";

            ///<summary>序号ID，不使用</summary>
            public const String sortid = "sortid";

            ///<summary></summary>
            public const String depth = "depth";

            ///<summary></summary>
            public const String array = "array";

            ///<summary></summary>
            public const String cname = "cname";

            ///<summary></summary>
            public const String pid = "pid";

            ///<summary>0:默认公开。   1:不公开</summary>
            public const String ispublic = "ispublic";

            ///<summary>默认0 </summary>
            public const String isrose = "isrose";

        }
        #endregion
    }

    /// <summary>合作社分类接口</summary>
    public partial interface IHzsClass
    {
        #region 属性
        /// <summary>主键ID，查询时使用此ID</summary>
        Int32 hid { get; set; }

        /// <summary>序号ID，不使用</summary>
        Int32 sortid { get; set; }

        /// <summary></summary>
        Int16 depth { get; set; }

        /// <summary></summary>
        Int32 array { get; set; }

        /// <summary></summary>
        String cname { get; set; }

        /// <summary></summary>
        Int32 pid { get; set; }

        /// <summary>0:默认公开。   1:不公开</summary>
        Int16 ispublic { get; set; }

        /// <summary>默认0 </summary>
        Int32 isrose { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}