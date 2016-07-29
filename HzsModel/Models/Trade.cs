/*
 * X v6.0.5010.17515
 * 作者：琨/HIKYUU
 * 时间：2014-02-28 15:50:12
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
    /// <summary>供求交易信息</summary>
    [Serializable]
    [DataObject]
    [Description("供求交易信息")]
    [BindIndex("HzsUser_Trade_r_FK", false, "uid")]
    [BindIndex("PK__Trade__3213E83F66603565", true, "id")]
    [BindTable("Trade", Description = "供求交易信息", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class Trade : ITrade
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

        private Int16 _tradetype;
        /// <summary>10:供应  默认。   20:求购。   30:合作</summary>
        [DisplayName("10:供应默认")]
        [Description("10:供应  默认。   20:求购。   30:合作")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(2, "tradetype", "10:供应  默认。   20:求购。   30:合作", "10", "smallint", 5, 0, false)]
        public virtual Int16 tradetype
        {
            get { return _tradetype; }
            set { if (OnPropertyChanging(__.tradetype, value)) { _tradetype = value; OnPropertyChanged(__.tradetype); } }
        }

        private String _name;
        /// <summary></summary>
        [DisplayName("Name")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "name", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private Int32 _ptype;
        /// <summary></summary>
        [DisplayName("Ptype")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "ptype", "", "0", "int", 10, 0, false)]
        public virtual Int32 ptype
        {
            get { return _ptype; }
            set { if (OnPropertyChanging(__.ptype, value)) { _ptype = value; OnPropertyChanged(__.ptype); } }
        }

        private Int32 _ptype2;
        /// <summary></summary>
        [DisplayName("Ptype2")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "ptype2", "", "0", "int", 10, 0, false)]
        public virtual Int32 ptype2
        {
            get { return _ptype2; }
            set { if (OnPropertyChanging(__.ptype2, value)) { _ptype2 = value; OnPropertyChanged(__.ptype2); } }
        }

        private String _title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "title", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _tpic;
        /// <summary></summary>
        [DisplayName("Tpic")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "tpic", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String tpic
        {
            get { return _tpic; }
            set { if (OnPropertyChanging(__.tpic, value)) { _tpic = value; OnPropertyChanged(__.tpic); } }
        }

        private String _pic2;
        /// <summary></summary>
        [DisplayName("Pic2")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(8, "pic2", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic2
        {
            get { return _pic2; }
            set { if (OnPropertyChanging(__.pic2, value)) { _pic2 = value; OnPropertyChanged(__.pic2); } }
        }

        private String _pic3;
        /// <summary></summary>
        [DisplayName("Pic3")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(9, "pic3", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String pic3
        {
            get { return _pic3; }
            set { if (OnPropertyChanging(__.pic3, value)) { _pic3 = value; OnPropertyChanged(__.pic3); } }
        }

        private Decimal _price;
        /// <summary>价格默认0</summary>
        [DisplayName("价格默认0")]
        [Description("价格默认0")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(10, "price", "价格默认0", "0", "money", 19, 4, false)]
        public virtual Decimal price
        {
            get { return _price; }
            set { if (OnPropertyChanging(__.price, value)) { _price = value; OnPropertyChanged(__.price); } }
        }

        private String _units;
        /// <summary>对应价格单位</summary>
        [DisplayName("对应价格单位")]
        [Description("对应价格单位")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "units", "对应价格单位", null, "nvarchar(50)", 0, 0, true)]
        public virtual String units
        {
            get { return _units; }
            set { if (OnPropertyChanging(__.units, value)) { _units = value; OnPropertyChanged(__.units); } }
        }

        private String _smallamount;
        /// <summary>最小供应量</summary>
        [DisplayName("最小供应量")]
        [Description("最小供应量")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(12, "smallamount", "最小供应量", null, "varchar(20)", 0, 0, false)]
        public virtual String smallamount
        {
            get { return _smallamount; }
            set { if (OnPropertyChanging(__.smallamount, value)) { _smallamount = value; OnPropertyChanged(__.smallamount); } }
        }

        private String _bigamount;
        /// <summary>最大供应量</summary>
        [DisplayName("最大供应量")]
        [Description("最大供应量")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "bigamount", "最大供应量", null, "nvarchar(50)", 0, 0, true)]
        public virtual String bigamount
        {
            get { return _bigamount; }
            set { if (OnPropertyChanging(__.bigamount, value)) { _bigamount = value; OnPropertyChanged(__.bigamount); } }
        }

        private String _amountunits;
        /// <summary>对应数量单位</summary>
        [DisplayName("对应数量单位")]
        [Description("对应数量单位")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(14, "amountunits", "对应数量单位", null, "nvarchar(20)", 0, 0, true)]
        public virtual String amountunits
        {
            get { return _amountunits; }
            set { if (OnPropertyChanging(__.amountunits, value)) { _amountunits = value; OnPropertyChanged(__.amountunits); } }
        }

        private String _brand;
        /// <summary>产品品牌</summary>
        [DisplayName("产品品牌")]
        [Description("产品品牌")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "brand", "产品品牌", null, "nvarchar(50)", 0, 0, true)]
        public virtual String brand
        {
            get { return _brand; }
            set { if (OnPropertyChanging(__.brand, value)) { _brand = value; OnPropertyChanged(__.brand); } }
        }

        private String _intro;
        /// <summary>简单介绍</summary>
        [DisplayName("简单介绍")]
        [Description("简单介绍")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(16, "intro", "简单介绍", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String intro
        {
            get { return _intro; }
            set { if (OnPropertyChanging(__.intro, value)) { _intro = value; OnPropertyChanged(__.intro); } }
        }

        private Int16 _ishot;
        /// <summary>0:默认。   1:推荐产品</summary>
        [DisplayName("0:默认")]
        [Description("0:默认。   1:推荐产品")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(17, "ishot", "0:默认。   1:推荐产品", "0", "smallint", 5, 0, false)]
        public virtual Int16 ishot
        {
            get { return _ishot; }
            set { if (OnPropertyChanging(__.ishot, value)) { _ishot = value; OnPropertyChanged(__.ishot); } }
        }

        private Int16 _isverify;
        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        [DisplayName("10:审核通过默认")]
        [Description("10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(18, "isverify", "10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过", "10", "smallint", 5, 0, false)]
        public virtual Int16 isverify
        {
            get { return _isverify; }
            set { if (OnPropertyChanging(__.isverify, value)) { _isverify = value; OnPropertyChanged(__.isverify); } }
        }

        private DateTime _addtime;
        /// <summary></summary>
        [DisplayName("Addtime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(19, "addtime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Int64 _province;
        /// <summary></summary>
        [DisplayName("Province")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(20, "province", "", "0", "bigint", 19, 0, false)]
        public virtual Int64 province
        {
            get { return _province; }
            set { if (OnPropertyChanging(__.province, value)) { _province = value; OnPropertyChanged(__.province); } }
        }

        private Int64 _city;
        /// <summary></summary>
        [DisplayName("City")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(21, "city", "", null, "bigint", 19, 0, false)]
        public virtual Int64 city
        {
            get { return _city; }
            set { if (OnPropertyChanging(__.city, value)) { _city = value; OnPropertyChanged(__.city); } }
        }

        private Int64 _county;
        /// <summary></summary>
        [DisplayName("County")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(22, "county", "", "0", "bigint", 19, 0, false)]
        public virtual Int64 county
        {
            get { return _county; }
            set { if (OnPropertyChanging(__.county, value)) { _county = value; OnPropertyChanged(__.county); } }
        }

        private String _address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(23, "address", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String address
        {
            get { return _address; }
            set { if (OnPropertyChanging(__.address, value)) { _address = value; OnPropertyChanged(__.address); } }
        }

        private Int32 _click;
        /// <summary>默认0</summary>
        [DisplayName("默认0")]
        [Description("默认0")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(24, "click", "默认0", "0", "int", 10, 0, false)]
        public virtual Int32 click
        {
            get { return _click; }
            set { if (OnPropertyChanging(__.click, value)) { _click = value; OnPropertyChanged(__.click); } }
        }

        private Int32 _today;
        /// <summary>到期时间type</summary>
        [DisplayName("到期时间type")]
        [Description("到期时间type")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(25, "today", "到期时间type", "0", "int", 10, 0, false)]
        public virtual Int32 today
        {
            get { return _today; }
            set { if (OnPropertyChanging(__.today, value)) { _today = value; OnPropertyChanged(__.today); } }
        }

        private DateTime _daytime;
        /// <summary>到期时间</summary>
        [DisplayName("到期时间")]
        [Description("到期时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(26, "daytime", "到期时间", null, "datetime", 3, 0, false)]
        public virtual DateTime daytime
        {
            get { return _daytime; }
            set { if (OnPropertyChanging(__.daytime, value)) { _daytime = value; OnPropertyChanged(__.daytime); } }
        }

        private Int32 _id;
        /// <summary>主键自增ID</summary>
        [DisplayName("主键自增ID")]
        [Description("主键自增ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(27, "id", "主键自增ID", null, "int", 10, 0, false)]
        public virtual Int32 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _content;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(28, "content", "内容", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String content
        {
            get { return _content; }
            set { if (OnPropertyChanging(__.content, value)) { _content = value; OnPropertyChanged(__.content); } }
        }

        private String _htmlpath;
        /// <summary></summary>
        [DisplayName("Htmlpath")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(29, "htmlpath", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String htmlpath
        {
            get { return _htmlpath; }
            set { if (OnPropertyChanging(__.htmlpath, value)) { _htmlpath = value; OnPropertyChanged(__.htmlpath); } }
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
                    case __.tradetype : return _tradetype;
                    case __.name : return _name;
                    case __.ptype : return _ptype;
                    case __.ptype2 : return _ptype2;
                    case __.title : return _title;
                    case __.tpic : return _tpic;
                    case __.pic2 : return _pic2;
                    case __.pic3 : return _pic3;
                    case __.price : return _price;
                    case __.units : return _units;
                    case __.smallamount : return _smallamount;
                    case __.bigamount : return _bigamount;
                    case __.amountunits : return _amountunits;
                    case __.brand : return _brand;
                    case __.intro : return _intro;
                    case __.ishot : return _ishot;
                    case __.isverify : return _isverify;
                    case __.addtime : return _addtime;
                    case __.province : return _province;
                    case __.city : return _city;
                    case __.county : return _county;
                    case __.address : return _address;
                    case __.click : return _click;
                    case __.today : return _today;
                    case __.daytime : return _daytime;
                    case __.id : return _id;
                    case __.content : return _content;
                    case __.htmlpath : return _htmlpath;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.tradetype : _tradetype = Convert.ToInt16(value); break;
                    case __.name : _name = Convert.ToString(value); break;
                    case __.ptype : _ptype = Convert.ToInt32(value); break;
                    case __.ptype2 : _ptype2 = Convert.ToInt32(value); break;
                    case __.title : _title = Convert.ToString(value); break;
                    case __.tpic : _tpic = Convert.ToString(value); break;
                    case __.pic2 : _pic2 = Convert.ToString(value); break;
                    case __.pic3 : _pic3 = Convert.ToString(value); break;
                    case __.price : _price = Convert.ToDecimal(value); break;
                    case __.units : _units = Convert.ToString(value); break;
                    case __.smallamount : _smallamount = Convert.ToString(value); break;
                    case __.bigamount : _bigamount = Convert.ToString(value); break;
                    case __.amountunits : _amountunits = Convert.ToString(value); break;
                    case __.brand : _brand = Convert.ToString(value); break;
                    case __.intro : _intro = Convert.ToString(value); break;
                    case __.ishot : _ishot = Convert.ToInt16(value); break;
                    case __.isverify : _isverify = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.province : _province = Convert.ToInt64(value); break;
                    case __.city : _city = Convert.ToInt64(value); break;
                    case __.county : _county = Convert.ToInt64(value); break;
                    case __.address : _address = Convert.ToString(value); break;
                    case __.click : _click = Convert.ToInt32(value); break;
                    case __.today : _today = Convert.ToInt32(value); break;
                    case __.daytime : _daytime = Convert.ToDateTime(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.content : _content = Convert.ToString(value); break;
                    case __.htmlpath : _htmlpath = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得供求交易信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary>10:供应  默认。   20:求购。   30:合作</summary>
            public static readonly Field tradetype = FindByName(__.tradetype);

            ///<summary></summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary></summary>
            public static readonly Field ptype = FindByName(__.ptype);

            ///<summary></summary>
            public static readonly Field ptype2 = FindByName(__.ptype2);

            ///<summary></summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary></summary>
            public static readonly Field tpic = FindByName(__.tpic);

            ///<summary></summary>
            public static readonly Field pic2 = FindByName(__.pic2);

            ///<summary></summary>
            public static readonly Field pic3 = FindByName(__.pic3);

            ///<summary>价格默认0</summary>
            public static readonly Field price = FindByName(__.price);

            ///<summary>对应价格单位</summary>
            public static readonly Field units = FindByName(__.units);

            ///<summary>最小供应量</summary>
            public static readonly Field smallamount = FindByName(__.smallamount);

            ///<summary>最大供应量</summary>
            public static readonly Field bigamount = FindByName(__.bigamount);

            ///<summary>对应数量单位</summary>
            public static readonly Field amountunits = FindByName(__.amountunits);

            ///<summary>产品品牌</summary>
            public static readonly Field brand = FindByName(__.brand);

            ///<summary>简单介绍</summary>
            public static readonly Field intro = FindByName(__.intro);

            ///<summary>0:默认。   1:推荐产品</summary>
            public static readonly Field ishot = FindByName(__.ishot);

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public static readonly Field isverify = FindByName(__.isverify);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary></summary>
            public static readonly Field province = FindByName(__.province);

            ///<summary></summary>
            public static readonly Field city = FindByName(__.city);

            ///<summary></summary>
            public static readonly Field county = FindByName(__.county);

            ///<summary></summary>
            public static readonly Field address = FindByName(__.address);

            ///<summary>默认0</summary>
            public static readonly Field click = FindByName(__.click);

            ///<summary>到期时间type</summary>
            public static readonly Field today = FindByName(__.today);

            ///<summary>到期时间</summary>
            public static readonly Field daytime = FindByName(__.daytime);

            ///<summary>主键自增ID</summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>内容</summary>
            public static readonly Field content = FindByName(__.content);

            ///<summary></summary>
            public static readonly Field htmlpath = FindByName(__.htmlpath);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得供求交易信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String uid = "uid";

            ///<summary>10:供应  默认。   20:求购。   30:合作</summary>
            public const String tradetype = "tradetype";

            ///<summary></summary>
            public const String name = "name";

            ///<summary></summary>
            public const String ptype = "ptype";

            ///<summary></summary>
            public const String ptype2 = "ptype2";

            ///<summary></summary>
            public const String title = "title";

            ///<summary></summary>
            public const String tpic = "tpic";

            ///<summary></summary>
            public const String pic2 = "pic2";

            ///<summary></summary>
            public const String pic3 = "pic3";

            ///<summary>价格默认0</summary>
            public const String price = "price";

            ///<summary>对应价格单位</summary>
            public const String units = "units";

            ///<summary>最小供应量</summary>
            public const String smallamount = "smallamount";

            ///<summary>最大供应量</summary>
            public const String bigamount = "bigamount";

            ///<summary>对应数量单位</summary>
            public const String amountunits = "amountunits";

            ///<summary>产品品牌</summary>
            public const String brand = "brand";

            ///<summary>简单介绍</summary>
            public const String intro = "intro";

            ///<summary>0:默认。   1:推荐产品</summary>
            public const String ishot = "ishot";

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public const String isverify = "isverify";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary></summary>
            public const String province = "province";

            ///<summary></summary>
            public const String city = "city";

            ///<summary></summary>
            public const String county = "county";

            ///<summary></summary>
            public const String address = "address";

            ///<summary>默认0</summary>
            public const String click = "click";

            ///<summary>到期时间type</summary>
            public const String today = "today";

            ///<summary>到期时间</summary>
            public const String daytime = "daytime";

            ///<summary>主键自增ID</summary>
            public const String id = "id";

            ///<summary>内容</summary>
            public const String content = "content";

            ///<summary></summary>
            public const String htmlpath = "htmlpath";

        }
        #endregion
    }

    /// <summary>供求交易信息接口</summary>
    public partial interface ITrade
    {
        #region 属性
        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary>10:供应  默认。   20:求购。   30:合作</summary>
        Int16 tradetype { get; set; }

        /// <summary></summary>
        String name { get; set; }

        /// <summary></summary>
        Int32 ptype { get; set; }

        /// <summary></summary>
        Int32 ptype2 { get; set; }

        /// <summary></summary>
        String title { get; set; }

        /// <summary></summary>
        String tpic { get; set; }

        /// <summary></summary>
        String pic2 { get; set; }

        /// <summary></summary>
        String pic3 { get; set; }

        /// <summary>价格默认0</summary>
        Decimal price { get; set; }

        /// <summary>对应价格单位</summary>
        String units { get; set; }

        /// <summary>最小供应量</summary>
        String smallamount { get; set; }

        /// <summary>最大供应量</summary>
        String bigamount { get; set; }

        /// <summary>对应数量单位</summary>
        String amountunits { get; set; }

        /// <summary>产品品牌</summary>
        String brand { get; set; }

        /// <summary>简单介绍</summary>
        String intro { get; set; }

        /// <summary>0:默认。   1:推荐产品</summary>
        Int16 ishot { get; set; }

        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        Int16 isverify { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary></summary>
        Int64 province { get; set; }

        /// <summary></summary>
        Int64 city { get; set; }

        /// <summary></summary>
        Int64 county { get; set; }

        /// <summary></summary>
        String address { get; set; }

        /// <summary>默认0</summary>
        Int32 click { get; set; }

        /// <summary>到期时间type</summary>
        Int32 today { get; set; }

        /// <summary>到期时间</summary>
        DateTime daytime { get; set; }

        /// <summary>主键自增ID</summary>
        Int32 id { get; set; }

        /// <summary>内容</summary>
        String content { get; set; }

        /// <summary></summary>
        String htmlpath { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}