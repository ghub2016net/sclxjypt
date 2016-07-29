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
    /// <summary>新闻类型表</summary>
    [Serializable]
    [DataObject]
    [Description("新闻类型表")]
    [BindIndex("IX_NewsType_ispublic", false, "ispublic")]
    [BindIndex("IX_NewsType_ntypeid", true, "ntypeid")]
    [BindIndex("PK__NewsType__3213E83F300424B4", true, "id")]
    [BindTable("NewsType", Description = "新闻类型表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class NewsType : INewsType
    {
        #region 属性

        private Int32 _ntypeid;
        /// <summary>类型使用的ID</summary>
        [DisplayName("类型使用的ID")]
        [Description("类型使用的ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(1, "ntypeid", "类型使用的ID", null, "int", 10, 0, false)]
        public virtual Int32 ntypeid
        {
            get { return _ntypeid; }
            set { if (OnPropertyChanging(__.ntypeid, value)) { _ntypeid = value; OnPropertyChanged(__.ntypeid); } }
        }

        private Int32 _pid;
        /// <summary></summary>
        [DisplayName("Pid")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "pid", "", null, "int", 10, 0, false)]
        public virtual Int32 pid
        {
            get { return _pid; }
            set { if (OnPropertyChanging(__.pid, value)) { _pid = value; OnPropertyChanged(__.pid); } }
        }

        private Int32 _array;
        /// <summary></summary>
        [DisplayName("Array")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "array", "", null, "int", 10, 0, false)]
        public virtual Int32 array
        {
            get { return _array; }
            set { if (OnPropertyChanging(__.array, value)) { _array = value; OnPropertyChanged(__.array); } }
        }

        private String _name;
        /// <summary></summary>
        [DisplayName("Name")]
        [Description("")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(4, "name", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "intro", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private String _editor;
        /// <summary></summary>
        [DisplayName("Editor")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "editor", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String editor
        {
            get { return _editor; }
            set { if (OnPropertyChanging(__.editor, value)) { _editor = value; OnPropertyChanged(__.editor); } }
        }

        private Int16 _isdel;
        /// <summary>0:默认。   1:删除，实际效果不再页面显示</summary>
        [DisplayName("0:默认")]
        [Description("0:默认。   1:删除，实际效果不再页面显示")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(7, "isdel", "0:默认。   1:删除，实际效果不再页面显示", "0", "smallint", 5, 0, false)]
        public virtual Int16 isdel
        {
            get { return _isdel; }
            set { if (OnPropertyChanging(__.isdel, value)) { _isdel = value; OnPropertyChanged(__.isdel); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "addtime", "", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int16 _ispublic;
        /// <summary>0:公开默认。   1:不公开</summary>
        [DisplayName("0:公开默认")]
        [Description("0:公开默认。   1:不公开")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(9, "ispublic", "0:公开默认。   1:不公开", "0", "smallint", 5, 0, false)]
        public virtual Int16 ispublic
        {
            get { return _ispublic; }
            set { if (OnPropertyChanging(__.ispublic, value)) { _ispublic = value; OnPropertyChanged(__.ispublic); } }
        }

        private Int32 _id;
        /// <summary>自增排序</summary>
        [DisplayName("自增排序")]
        [Description("自增排序")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(10, "id", "自增排序", null, "int", 10, 0, false)]
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
                    case __.ntypeid : return _ntypeid;
                    case __.pid : return _pid;
                    case __.array : return _array;
                    case __.name : return _name;
                    case __.intro : return _intro;
                    case __.editor : return _editor;
                    case __.isdel : return _isdel;
                    case __.addtime : return _addtime;
                    case __.ispublic : return _ispublic;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ntypeid : _ntypeid = Convert.ToInt32(value); break;
                    case __.pid : _pid = Convert.ToInt32(value); break;
                    case __.array : _array = Convert.ToInt32(value); break;
                    case __.name : _name = Convert.ToString(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.editor : _editor = Convert.ToString(value); break;
                    case __.isdel : _isdel = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.ispublic : _ispublic = Convert.ToInt16(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得新闻类型表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>类型使用的ID</summary>
            public static readonly Field ntypeid = FindByName(__.ntypeid);

            ///<summary></summary>
            public static readonly Field pid = FindByName(__.pid);

            ///<summary></summary>
            public static readonly Field array = FindByName(__.array);

            ///<summary></summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary></summary>
            public static readonly Field editor = FindByName(__.editor);

            ///<summary>0:默认。   1:删除，实际效果不再页面显示</summary>
            public static readonly Field isdel = FindByName(__.isdel);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary>0:公开默认。   1:不公开</summary>
            public static readonly Field ispublic = FindByName(__.ispublic);

            ///<summary>自增排序</summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得新闻类型表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>类型使用的ID</summary>
            public const String ntypeid = "ntypeid";

            ///<summary></summary>
            public const String pid = "pid";

            ///<summary></summary>
            public const String array = "array";

            ///<summary></summary>
            public const String name = "name";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary></summary>
            public const String editor = "editor";

            ///<summary>0:默认。   1:删除，实际效果不再页面显示</summary>
            public const String isdel = "isdel";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary>0:公开默认。   1:不公开</summary>
            public const String ispublic = "ispublic";

            ///<summary>自增排序</summary>
            public const String id = "id";

        }
        #endregion

        #region 手动添加的关联属性
        /// <summary>
        /// 父类名称
        /// </summary>
        public String pname { get; set; } 
        #endregion
    }

    /// <summary>新闻类型表接口</summary>
    public partial interface INewsType
    {
        #region 属性
        /// <summary>类型使用的ID</summary>
        Int32 ntypeid { get; set; }

        /// <summary></summary>
        Int32 pid { get; set; }

        /// <summary></summary>
        Int32 array { get; set; }

        /// <summary></summary>
        String name { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary></summary>
        String editor { get; set; }

        /// <summary>0:默认。   1:删除，实际效果不再页面显示</summary>
        Int16 isdel { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary>0:公开默认。   1:不公开</summary>
        Int16 ispublic { get; set; }

        /// <summary>自增排序</summary>
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