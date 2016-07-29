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
    /// <summary>评价表</summary>
    [Serializable]
    [DataObject]
    [Description("评价表")]
    [BindIndex("HzsUser_HzsGrade_r_FK", false, "uid")]
    [BindIndex("PK__HzsGrade__3213E83F3A81B327", true, "id")]
    [BindTable("HzsGrade", Description = "评价表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsGrade : IHzsGrade
    {
        #region 属性

        private Int32 _uid;
        /// <summary></summary>
        [DisplayName("Uid")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(1, "uid", "", null, "int", 10, 0, false)]
        public virtual Int32 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private Int16 _grade;
        /// <summary></summary>
        [DisplayName("Grade")]
        [Description("")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(2, "grade", "", null, "smallint", 5, 0, false)]
        public virtual Int16 grade
        {
            get { return _grade; }
            set { if (OnPropertyChanging(__.grade, value)) { _grade = value; OnPropertyChanged(__.grade); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(3, "intro", "", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private String _ip;
        /// <summary></summary>
        [DisplayName("ip")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "ip", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ip
        {
            get { return _ip; }
            set { if (OnPropertyChanging(__.ip, value)) { _ip = value; OnPropertyChanged(__.ip); } }
        }

        private Int16 _isvefity;
        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        [DisplayName("10:审核通过默认")]
        [Description("10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(5, "isvefity", "10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过", "10", "smallint", 5, 0, false)]
        public virtual Int16 isvefity
        {
            get { return _isvefity; }
            set { if (OnPropertyChanging(__.isvefity, value)) { _isvefity = value; OnPropertyChanged(__.isvefity); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(6, "addtime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(7, "id", "", null, "int", 10, 0, false)]
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
                    case __.uid : return _uid;
                    case __.grade : return _grade;
                    case __.intro : return _intro;
                    case __.ip : return _ip;
                    case __.isvefity : return _isvefity;
                    case __.addtime : return _addtime;
                    case __.id : return _id;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.grade : _grade = Convert.ToInt16(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.ip : _ip = Convert.ToString(value); break;
                    case __.isvefity : _isvefity = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得评价表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary></summary>
            public static readonly Field grade = FindByName(__.grade);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary></summary>
            public static readonly Field ip = FindByName(__.ip);

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public static readonly Field isvefity = FindByName(__.isvefity);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得评价表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String uid = "uid";

            ///<summary></summary>
            public const String grade = "grade";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary></summary>
            public const String ip = "ip";

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public const String isvefity = "isvefity";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String id = "id";

        }
        #endregion
    }

    /// <summary>评价表接口</summary>
    public partial interface IHzsGrade
    {
        #region 属性
        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary></summary>
        Int16 grade { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary></summary>
        String ip { get; set; }

        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        Int16 isvefity { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

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