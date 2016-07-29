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
    /// <summary>管理员权限</summary>
    [Serializable]
    [DataObject]
    [Description("管理员权限")]
    [BindIndex("IX_AdminRole_menuid", false, "menuid")]
    [BindIndex("PK__AdminRol__3213E83F36B12243", true, "id")]
    [BindTable("AdminRole", Description = "管理员权限", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class AdminRole : IAdminRole
    {
        #region 属性

        private Int32 _roleid;
        /// <summary></summary>
        [DisplayName("Roleid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(1, "roleid", "", null, "int", 10, 0, false)]
        public virtual Int32 roleid
        {
            get { return _roleid; }
            set { if (OnPropertyChanging(__.roleid, value)) { _roleid = value; OnPropertyChanged(__.roleid); } }
        }

        private Int32 _menuid;
        /// <summary></summary>
        [DisplayName("Menuid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "menuid", "", null, "int", 10, 0, false)]
        public virtual Int32 menuid
        {
            get { return _menuid; }
            set { if (OnPropertyChanging(__.menuid, value)) { _menuid = value; OnPropertyChanged(__.menuid); } }
        }

        private Int32 _prmission;
        /// <summary>允许权限</summary>
        [DisplayName("允许权限")]
        [Description("允许权限")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "prmission", "允许权限", null, "int", 10, 0, false)]
        public virtual Int32 prmission
        {
            get { return _prmission; }
            set { if (OnPropertyChanging(__.prmission, value)) { _prmission = value; OnPropertyChanged(__.prmission); } }
        }

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(4, "id", "", null, "int", 10, 0, false)]
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
                    case __.roleid : return _roleid;
                    case __.menuid : return _menuid;
                    case __.prmission : return _prmission;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.roleid : _roleid = Convert.ToInt32(value); break;
                    case __.menuid : _menuid = Convert.ToInt32(value); break;
                    case __.prmission : _prmission = Convert.ToInt32(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得管理员权限字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field roleid = FindByName(__.roleid);

            ///<summary></summary>
            public static readonly Field menuid = FindByName(__.menuid);

            ///<summary>允许权限</summary>
            public static readonly Field prmission = FindByName(__.prmission);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得管理员权限字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String roleid = "roleid";

            ///<summary></summary>
            public const String menuid = "menuid";

            ///<summary>允许权限</summary>
            public const String prmission = "prmission";

            ///<summary></summary>
            public const String id = "id";

        }
        #endregion
    }

    /// <summary>管理员权限接口</summary>
    public partial interface IAdminRole
    {
        #region 属性
        /// <summary></summary>
        Int32 roleid { get; set; }

        /// <summary></summary>
        Int32 menuid { get; set; }

        /// <summary>允许权限</summary>
        Int32 prmission { get; set; }

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