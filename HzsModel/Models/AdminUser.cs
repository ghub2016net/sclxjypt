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
    /// <summary>管理员用户</summary>
    [Serializable]
    [DataObject]
    [Description("管理员用户")]
    [BindIndex("IX_AdminUser_email", false, "email")]
    [BindIndex("IX_AdminUser_isdel", false, "isdel")]
    [BindIndex("IX_AdminUser_name", false, "name")]
    [BindIndex("PK__AdminUse__AD040D7E173876EA", true, "adminid")]
    [BindTable("AdminUser", Description = "管理员用户", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class AdminUser : IAdminUser
    {
        #region 属性

        private Int16 _utype;
        /// <summary>默认1</summary>
        [DisplayName("默认1")]
        [Description("默认1")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(1, "utype", "默认1", "1", "smallint", 5, 0, false)]
        public virtual Int16 utype
        {
            get { return _utype; }
            set { if (OnPropertyChanging(__.utype, value)) { _utype = value; OnPropertyChanged(__.utype); } }
        }

        private String _name;
        /// <summary>管理员名称</summary>
        [DisplayName("管理员名称")]
        [Description("管理员名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "name", "管理员名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private String _apwd;
        /// <summary></summary>
        [DisplayName("Apwd")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "apwd", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String apwd
        {
            get { return _apwd; }
            set { if (OnPropertyChanging(__.apwd, value)) { _apwd = value; OnPropertyChanged(__.apwd); } }
        }

        private String _email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "email", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String email
        {
            get { return _email; }
            set { if (OnPropertyChanging(__.email, value)) { _email = value; OnPropertyChanged(__.email); } }
        }

        private Int16 _isdel;
        /// <summary>账户状态</summary>
        [DisplayName("账户状态")]
        [Description("账户状态")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(5, "isdel", "账户状态", "0", "smallint", 5, 0, false)]
        public virtual Int16 isdel
        {
            get { return _isdel; }
            set { if (OnPropertyChanging(__.isdel, value)) { _isdel = value; OnPropertyChanged(__.isdel); } }
        }

        private DateTime _addtime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(6, "addtime", "创建时间", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int32 _adminid;
        /// <summary>主键 自增ID</summary>
        [DisplayName("主键自增ID")]
        [Description("主键 自增ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(7, "adminid", "主键 自增ID", null, "int", 10, 0, false)]
        public virtual Int32 adminid
        {
            get { return _adminid; }
            set { if (OnPropertyChanging(__.adminid, value)) { _adminid = value; OnPropertyChanged(__.adminid); } }
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
                    case __.utype : return _utype;
                    case __.name : return _name;
                    case __.apwd : return _apwd;
                    case __.email : return _email;
                    case __.isdel : return _isdel;
                    case __.addtime : return _addtime;
                    case __.adminid : return _adminid;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.utype : _utype = Convert.ToInt16(value); break;
                    case __.name : _name = Convert.ToString(value); break;
                    case __.apwd : _apwd = Convert.ToString(value); break;
                    case __.email : _email = Convert.ToString(value); break;
                    case __.isdel : _isdel = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.adminid : _adminid = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得管理员用户字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>默认1</summary>
            public static readonly Field utype = FindByName(__.utype);

            ///<summary>管理员名称</summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary></summary>
            public static readonly Field apwd = FindByName(__.apwd);

            ///<summary></summary>
            public static readonly Field email = FindByName(__.email);

            ///<summary>账户状态</summary>
            public static readonly Field isdel = FindByName(__.isdel);

            ///<summary>创建时间</summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary>主键 自增ID</summary>
            public static readonly Field adminid = FindByName(__.adminid);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得管理员用户字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>默认1</summary>
            public const String utype = "utype";

            ///<summary>管理员名称</summary>
            public const String name = "name";

            ///<summary></summary>
            public const String apwd = "apwd";

            ///<summary></summary>
            public const String email = "email";

            ///<summary>账户状态</summary>
            public const String isdel = "isdel";

            ///<summary>创建时间</summary>
            public const String addtime = "addtime";

            ///<summary>主键 自增ID</summary>
            public const String adminid = "adminid";

        }
        #endregion
    }

    /// <summary>管理员用户接口</summary>
    public partial interface IAdminUser
    {
        #region 属性
        /// <summary>默认1</summary>
        Int16 utype { get; set; }

        /// <summary>管理员名称</summary>
        String name { get; set; }

        /// <summary></summary>
        String apwd { get; set; }

        /// <summary></summary>
        String email { get; set; }

        /// <summary>账户状态</summary>
        Int16 isdel { get; set; }

        /// <summary>创建时间</summary>
        DateTime addtime { get; set; }

        /// <summary>主键 自增ID</summary>
        Int32 adminid { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}