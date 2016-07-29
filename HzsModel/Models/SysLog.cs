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
    /// <summary>SysLog</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_SysLog_logType", false, "logType")]
    [BindIndex("PK__SysLog__3213E83F1DE57479", true, "id")]
    [BindTable("SysLog", Description = "", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class SysLog : ISysLog
    {
        #region 属性

        private String _logValue;
        /// <summary></summary>
        [DisplayName("LogValue")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(1, "logValue", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String logValue
        {
            get { return _logValue; }
            set { if (OnPropertyChanging(__.logValue, value)) { _logValue = value; OnPropertyChanged(__.logValue); } }
        }

        private String _operate;
        /// <summary></summary>
        [DisplayName("Operate")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "operate", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String operate
        {
            get { return _operate; }
            set { if (OnPropertyChanging(__.operate, value)) { _operate = value; OnPropertyChanged(__.operate); } }
        }

        private String _editor;
        /// <summary></summary>
        [DisplayName("Editor")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "editor", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String editor
        {
            get { return _editor; }
            set { if (OnPropertyChanging(__.editor, value)) { _editor = value; OnPropertyChanged(__.editor); } }
        }

        private String _ip;
        /// <summary></summary>
        [DisplayName("ip")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "ip", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String ip
        {
            get { return _ip; }
            set { if (OnPropertyChanging(__.ip, value)) { _ip = value; OnPropertyChanged(__.ip); } }
        }

        private Int32 _logType;
        /// <summary></summary>
        [DisplayName("LogType")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "logType", "", null, "int", 10, 0, false)]
        public virtual Int32 logType
        {
            get { return _logType; }
            set { if (OnPropertyChanging(__.logType, value)) { _logType = value; OnPropertyChanged(__.logType); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "addtime", "", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int32 _adminid;
        /// <summary></summary>
        [DisplayName("Adminid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "adminid", "", null, "int", 10, 0, false)]
        public virtual Int32 adminid
        {
            get { return _adminid; }
            set { if (OnPropertyChanging(__.adminid, value)) { _adminid = value; OnPropertyChanged(__.adminid); } }
        }

        private Int64 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(8, "id", "", null, "bigint", 19, 0, false)]
        public virtual Int64 id
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
                    case __.logValue : return _logValue;
                    case __.operate : return _operate;
                    case __.editor : return _editor;
                    case __.ip : return _ip;
                    case __.logType : return _logType;
                    case __.addtime : return _addtime;
                    case __.adminid : return _adminid;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.logValue : _logValue = Convert.ToString(value); break;
                    case __.operate : _operate = Convert.ToString(value); break;
                    case __.editor : _editor = Convert.ToString(value); break;
                    case __.ip : _ip = Convert.ToString(value); break;
                    case __.logType : _logType = Convert.ToInt32(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.adminid : _adminid = Convert.ToInt32(value); break;
                    case __.id : _id = Convert.ToInt64(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得SysLog字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field logValue = FindByName(__.logValue);

            ///<summary></summary>
            public static readonly Field operate = FindByName(__.operate);

            ///<summary></summary>
            public static readonly Field editor = FindByName(__.editor);

            ///<summary></summary>
            public static readonly Field ip = FindByName(__.ip);

            ///<summary></summary>
            public static readonly Field logType = FindByName(__.logType);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field adminid = FindByName(__.adminid);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得SysLog字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String logValue = "logValue";

            ///<summary></summary>
            public const String operate = "operate";

            ///<summary></summary>
            public const String editor = "editor";

            ///<summary></summary>
            public const String ip = "ip";

            ///<summary></summary>
            public const String logType = "logType";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String adminid = "adminid";

            ///<summary></summary>
            public const String id = "id";

        }
        #endregion
    }

    /// <summary>SysLog接口</summary>
    /// <remarks></remarks>
    public partial interface ISysLog
    {
        #region 属性
        /// <summary></summary>
        String logValue { get; set; }

        /// <summary></summary>
        String operate { get; set; }

        /// <summary></summary>
        String editor { get; set; }

        /// <summary></summary>
        String ip { get; set; }

        /// <summary></summary>
        Int32 logType { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        Int32 adminid { get; set; }

        /// <summary></summary>
        Int64 id { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}