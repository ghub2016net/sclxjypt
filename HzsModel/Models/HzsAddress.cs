/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-19 21:37:02
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
    /// <summary>合作社地址表</summary>
    [Serializable]
    [DataObject]
    [Description("合作社地址表")]
    [BindIndex("HzsUser_HzsAddress_r_FK", false, "uid")]
    [BindIndex("PK_HZSADDRESS", true, "aid")]
    [BindTable("HzsAddress", Description = "合作社地址表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsAddress : IHzsAddress
    {
        #region 属性

        private Int32 _aid;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "aid", "", null, "int", 10, 0, false)]
        public virtual Int32 aid
        {
            get { return _aid; }
            set { if (OnPropertyChanging(__.aid, value)) { _aid = value; OnPropertyChanged(__.aid); } }
        }

        private Int32 _uid;
        /// <summary></summary>
        [DisplayName("Uid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "uid", "", null, "int", 10, 0, false)]
        public virtual Int32 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private Int32 _province;
        /// <summary></summary>
        [DisplayName("Province")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "province", "", null, "int", 10, 0, false)]
        public virtual Int32 province
        {
            get { return _province; }
            set { if (OnPropertyChanging(__.province, value)) { _province = value; OnPropertyChanged(__.province); } }
        }

        private Int32 _city;
        /// <summary></summary>
        [DisplayName("City")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "city", "", null, "int", 10, 0, false)]
        public virtual Int32 city
        {
            get { return _city; }
            set { if (OnPropertyChanging(__.city, value)) { _city = value; OnPropertyChanged(__.city); } }
        }

        private Int32 _county;
        /// <summary></summary>
        [DisplayName("County")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "county", "", null, "int", 10, 0, false)]
        public virtual Int32 county
        {
            get { return _county; }
            set { if (OnPropertyChanging(__.county, value)) { _county = value; OnPropertyChanged(__.county); } }
        }

        private String _address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "address", "", null, "varchar(200)", 0, 0, false)]
        public virtual String address
        {
            get { return _address; }
            set { if (OnPropertyChanging(__.address, value)) { _address = value; OnPropertyChanged(__.address); } }
        }

        private Int16 _isdefault;
        /// <summary>0:初始为0 。   1:为当前默认</summary>
        [DisplayName("0:初始为0")]
        [Description("0:初始为0 。   1:为当前默认")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(7, "isdefault", "0:初始为0 。   1:为当前默认", "0", "smallint", 5, 0, false)]
        public virtual Int16 isdefault
        {
            get { return _isdefault; }
            set { if (OnPropertyChanging(__.isdefault, value)) { _isdefault = value; OnPropertyChanged(__.isdefault); } }
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
                    case __.aid : return _aid;
                    case __.uid : return _uid;
                    case __.province : return _province;
                    case __.city : return _city;
                    case __.county : return _county;
                    case __.address : return _address;
                    case __.isdefault : return _isdefault;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.aid : _aid = Convert.ToInt32(value); break;
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.province : _province = Convert.ToInt32(value); break;
                    case __.city : _city = Convert.ToInt32(value); break;
                    case __.county : _county = Convert.ToInt32(value); break;
                    case __.address : _address = Convert.ToString(value); break;
                    case __.isdefault : _isdefault = Convert.ToInt16(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得合作社地址表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field aid = FindByName(__.aid);

            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary></summary>
            public static readonly Field province = FindByName(__.province);

            ///<summary></summary>
            public static readonly Field city = FindByName(__.city);

            ///<summary></summary>
            public static readonly Field county = FindByName(__.county);

            ///<summary></summary>
            public static readonly Field address = FindByName(__.address);

            ///<summary>0:初始为0 。   1:为当前默认</summary>
            public static readonly Field isdefault = FindByName(__.isdefault);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得合作社地址表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String aid = "aid";

            ///<summary></summary>
            public const String uid = "uid";

            ///<summary></summary>
            public const String province = "province";

            ///<summary></summary>
            public const String city = "city";

            ///<summary></summary>
            public const String county = "county";

            ///<summary></summary>
            public const String address = "address";

            ///<summary>0:初始为0 。   1:为当前默认</summary>
            public const String isdefault = "isdefault";

        }
        #endregion
    }

    /// <summary>合作社地址表接口</summary>
    public partial interface IHzsAddress
    {
        #region 属性
        /// <summary></summary>
        Int32 aid { get; set; }

        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary></summary>
        Int32 province { get; set; }

        /// <summary></summary>
        Int32 city { get; set; }

        /// <summary></summary>
        Int32 county { get; set; }

        /// <summary></summary>
        String address { get; set; }

        /// <summary>0:初始为0 。   1:为当前默认</summary>
        Int16 isdefault { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}