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
    /// <summary>供求信息咨询表</summary>
    [Serializable]
    [DataObject]
    [Description("供求信息咨询表")]
    [BindIndex("PK__TradeCon__14BB76495070F446", true, "consultid")]
    [BindTable("TradeConsult", Description = "供求信息咨询表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class TradeConsult : ITradeConsult
    {
        #region 属性

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(1, "title", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _intro;
        /// <summary></summary>
        [DisplayName("Intro")]
        [Description("")]
        [DataObjectField(false, false, true, 1024)]
        [BindColumn(2, "intro", "", null, "nvarchar(1024)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private Int32 _tid;
        /// <summary>供求信息id</summary>
        [DisplayName("供求信息id")]
        [Description("供求信息id")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "tid", "供求信息id", null, "int", 10, 0, false)]
        public virtual Int32 tid
        {
            get { return _tid; }
            set { if (OnPropertyChanging(__.tid, value)) { _tid = value; OnPropertyChanged(__.tid); } }
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

        private String _tel;
        /// <summary></summary>
        [DisplayName("Tel")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "tel", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String tel
        {
            get { return _tel; }
            set { if (OnPropertyChanging(__.tel, value)) { _tel = value; OnPropertyChanged(__.tel); } }
        }

        private String _consultname;
        /// <summary>回复人</summary>
        [DisplayName("回复人")]
        [Description("回复人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "consultname", "回复人", null, "nvarchar(50)", 0, 0, true)]
        public virtual String consultname
        {
            get { return _consultname; }
            set { if (OnPropertyChanging(__.consultname, value)) { _consultname = value; OnPropertyChanged(__.consultname); } }
        }

        private Int32 _consultuid;
        /// <summary>咨询人Id</summary>
        [DisplayName("咨询人Id")]
        [Description("咨询人Id")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "consultuid", "咨询人Id", null, "int", 10, 0, false)]
        public virtual Int32 consultuid
        {
            get { return _consultuid; }
            set { if (OnPropertyChanging(__.consultuid, value)) { _consultuid = value; OnPropertyChanged(__.consultuid); } }
        }

        private String _replyintro;
        /// <summary></summary>
        [DisplayName("Replyintro")]
        [Description("")]
        [DataObjectField(false, false, true, 1024)]
        [BindColumn(8, "replyintro", "", null, "nvarchar(1024)", 0, 0, true)]
        public virtual String replyintro
        {
            get { return _replyintro; }
            set { if (OnPropertyChanging(__.replyintro, value)) { _replyintro = value; OnPropertyChanged(__.replyintro); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "addtime", "", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private DateTime _replytime;
        /// <summary></summary>
        [DisplayName("Replytime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "replytime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime replytime
        {
            get { return _replytime; }
            set { if (OnPropertyChanging(__.replytime, value)) { _replytime = value; OnPropertyChanged(__.replytime); } }
        }

        private Int32 _replyuid;
        /// <summary>合作社用户ID 外键</summary>
        [DisplayName("合作社用户ID外键")]
        [Description("合作社用户ID 外键")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "replyuid", "合作社用户ID 外键", null, "int", 10, 0, false)]
        public virtual Int32 replyuid
        {
            get { return _replyuid; }
            set { if (OnPropertyChanging(__.replyuid, value)) { _replyuid = value; OnPropertyChanged(__.replyuid); } }
        }

        private Int16 _ispublic;
        /// <summary>1:不公开。   0:默认公开</summary>
        [DisplayName("1:不公开")]
        [Description("1:不公开。   0:默认公开")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(12, "ispublic", "1:不公开。   0:默认公开", "0", "smallint", 5, 0, false)]
        public virtual Int16 ispublic
        {
            get { return _ispublic; }
            set { if (OnPropertyChanging(__.ispublic, value)) { _ispublic = value; OnPropertyChanged(__.ispublic); } }
        }

        private Int64 _consultid;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(13, "consultid", "", null, "bigint", 19, 0, false)]
        public virtual Int64 consultid
        {
            get { return _consultid; }
            set { if (OnPropertyChanging(__.consultid, value)) { _consultid = value; OnPropertyChanged(__.consultid); } }
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
                    case __.title : return _title;
                    case __.intro : return _intro;
                    case __.tid : return _tid;
                    case __.email : return _email;
                    case __.tel : return _tel;
                    case __.consultname : return _consultname;
                    case __.consultuid : return _consultuid;
                    case __.replyintro : return _replyintro;
                    case __.addtime : return _addtime;
                    case __.replytime : return _replytime;
                    case __.replyuid : return _replyuid;
                    case __.ispublic : return _ispublic;
                    case __.consultid : return _consultid;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.title : _title = Convert.ToString(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.tid : _tid = Convert.ToInt32(value); break;
                    case __.email : _email = Convert.ToString(value); break;
                    case __.tel : _tel = Convert.ToString(value); break;
                    case __.consultname : _consultname = Convert.ToString(value); break;
                    case __.consultuid : _consultuid = Convert.ToInt32(value); break;
                    case __.replyintro : _replyintro = Convert.ToString(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.replytime : _replytime = Convert.ToDateTime(value); break;
                    case __.replyuid : _replyuid = Convert.ToInt32(value); break;
                    case __.ispublic : _ispublic = Convert.ToInt16(value); break;
                    case __.consultid : _consultid = Convert.ToInt64(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得供求信息咨询表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary>供求信息id</summary>
            public static readonly Field tid = FindByName(__.tid);

            ///<summary></summary>
            public static readonly Field email = FindByName(__.email);

            ///<summary></summary>
            public static readonly Field tel = FindByName(__.tel);

            ///<summary>回复人</summary>
            public static readonly Field consultname = FindByName(__.consultname);

            ///<summary>咨询人Id</summary>
            public static readonly Field consultuid = FindByName(__.consultuid);

            ///<summary></summary>
            public static readonly Field replyintro = FindByName(__.replyintro);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field replytime = FindByName(__.replytime);

            ///<summary>合作社用户ID 外键</summary>
            public static readonly Field replyuid = FindByName(__.replyuid);

            ///<summary>1:不公开。   0:默认公开</summary>
            public static readonly Field ispublic = FindByName(__.ispublic);

            ///<summary></summary>
            public static readonly Field consultid = FindByName(__.consultid);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得供求信息咨询表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String intro = "intro";

            ///<summary>供求信息id</summary>
            public const String tid = "tid";

            ///<summary></summary>
            public const String email = "email";

            ///<summary></summary>
            public const String tel = "tel";

            ///<summary>回复人</summary>
            public const String consultname = "consultname";

            ///<summary>咨询人Id</summary>
            public const String consultuid = "consultuid";

            ///<summary></summary>
            public const String replyintro = "replyintro";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String replytime = "replytime";

            ///<summary>合作社用户ID 外键</summary>
            public const String replyuid = "replyuid";

            ///<summary>1:不公开。   0:默认公开</summary>
            public const String ispublic = "ispublic";

            ///<summary></summary>
            public const String consultid = "consultid";

        }
        #endregion
    }

    /// <summary>供求信息咨询表接口</summary>
    public partial interface ITradeConsult
    {
        #region 属性
        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String intro { get; set; }

        /// <summary>供求信息id</summary>
        Int32 tid { get; set; }

        /// <summary></summary>
        String email { get; set; }

        /// <summary></summary>
        String tel { get; set; }

        /// <summary>回复人</summary>
        String consultname { get; set; }

        /// <summary>咨询人Id</summary>
        Int32 consultuid { get; set; }

        /// <summary></summary>
        String replyintro { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        DateTime replytime { get; set; }

        /// <summary>合作社用户ID 外键</summary>
        Int32 replyuid { get; set; }

        /// <summary>1:不公开。   0:默认公开</summary>
        Int16 ispublic { get; set; }

        /// <summary></summary>
        Int64 consultid { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}