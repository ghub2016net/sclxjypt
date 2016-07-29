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
    /// <summary>合作社会员表</summary>
    [Serializable]
    [DataObject]
    [Description("合作社会员表")]
    [BindIndex("IX_HzsUser_isverify", false, "isverify")]
    [BindIndex("PK__HzsUser__DD7012640DAF0CB0", true, "uid")]
    [BindTable("HzsUser", Description = "合作社会员表", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class HzsUser : IHzsUser
    {
        #region 属性

        private String _hname;
        /// <summary></summary>
        [DisplayName("Hname")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(1, "hname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String hname
        {
            get { return _hname; }
            set { if (OnPropertyChanging(__.hname, value)) { _hname = value; OnPropertyChanged(__.hname); } }
        }

        private String _hpwd;
        /// <summary></summary>
        [DisplayName("Hpwd")]
        [Description("")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(2, "hpwd", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String hpwd
        {
            get { return _hpwd; }
            set { if (OnPropertyChanging(__.hpwd, value)) { _hpwd = value; OnPropertyChanged(__.hpwd); } }
        }

        private String _email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "email", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String email
        {
            get { return _email; }
            set { if (OnPropertyChanging(__.email, value)) { _email = value; OnPropertyChanged(__.email); } }
        }

        private Int16 _sex;
        /// <summary>1:男 默认。   2:女</summary>
        [DisplayName("1:男默认")]
        [Description("1:男 默认。   2:女")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(4, "sex", "1:男 默认。   2:女", "1", "smallint", 5, 0, false)]
        public virtual Int16 sex
        {
            get { return _sex; }
            set { if (OnPropertyChanging(__.sex, value)) { _sex = value; OnPropertyChanged(__.sex); } }
        }

        private Int16 _htype;
        /// <summary></summary>
        [DisplayName("Htype")]
        [Description("")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(5, "htype", "", "0", "smallint", 5, 0, false)]
        public virtual Int16 htype
        {
            get { return _htype; }
            set { if (OnPropertyChanging(__.htype, value)) { _htype = value; OnPropertyChanged(__.htype); } }
        }

        private String _linkman;
        /// <summary></summary>
        [DisplayName("Linkman")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "linkman", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String linkman
        {
            get { return _linkman; }
            set { if (OnPropertyChanging(__.linkman, value)) { _linkman = value; OnPropertyChanged(__.linkman); } }
        }

        private String _corpname;
        /// <summary></summary>
        [DisplayName("Corpname")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(7, "corpname", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String corpname
        {
            get { return _corpname; }
            set { if (OnPropertyChanging(__.corpname, value)) { _corpname = value; OnPropertyChanged(__.corpname); } }
        }

        private String _tel;
        /// <summary></summary>
        [DisplayName("Tel")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "tel", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String tel
        {
            get { return _tel; }
            set { if (OnPropertyChanging(__.tel, value)) { _tel = value; OnPropertyChanged(__.tel); } }
        }

        private String _fax;
        /// <summary></summary>
        [DisplayName("Fax")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "fax", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String fax
        {
            get { return _fax; }
            set { if (OnPropertyChanging(__.fax, value)) { _fax = value; OnPropertyChanged(__.fax); } }
        }

        private Int64 _province;
        /// <summary></summary>
        [DisplayName("Province")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(10, "province", "", "0", "bigint", 19, 0, false)]
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
        [BindColumn(11, "city", "", "0", "bigint", 19, 0, false)]
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
        [BindColumn(12, "county", "", "0", "bigint", 19, 0, false)]
        public virtual Int64 county
        {
            get { return _county; }
            set { if (OnPropertyChanging(__.county, value)) { _county = value; OnPropertyChanged(__.county); } }
        }

        private String _address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 300)]
        [BindColumn(13, "address", "", null, "nvarchar(300)", 0, 0, true)]
        public virtual String address
        {
            get { return _address; }
            set { if (OnPropertyChanging(__.address, value)) { _address = value; OnPropertyChanged(__.address); } }
        }

        private String _zipcode;
        /// <summary></summary>
        [DisplayName("Zipcode")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(14, "zipcode", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String zipcode
        {
            get { return _zipcode; }
            set { if (OnPropertyChanging(__.zipcode, value)) { _zipcode = value; OnPropertyChanged(__.zipcode); } }
        }

        private String _scope;
        /// <summary>经营范围</summary>
        [DisplayName("经营范围")]
        [Description("经营范围")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(15, "scope", "经营范围", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String scope
        {
            get { return _scope; }
            set { if (OnPropertyChanging(__.scope, value)) { _scope = value; OnPropertyChanged(__.scope); } }
        }

        private String _corppic;
        /// <summary></summary>
        [DisplayName("Corppic")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(16, "corppic", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String corppic
        {
            get { return _corppic; }
            set { if (OnPropertyChanging(__.corppic, value)) { _corppic = value; OnPropertyChanged(__.corppic); } }
        }

        private String _cropregtime;
        /// <summary></summary>
        [DisplayName("Cropregtime")]
        [Description("")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(17, "cropregtime", "", null, "varchar(30)", 0, 0, false)]
        public virtual String cropregtime
        {
            get { return _cropregtime; }
            set { if (OnPropertyChanging(__.cropregtime, value)) { _cropregtime = value; OnPropertyChanged(__.cropregtime); } }
        }

        private String _licence;
        /// <summary>许可证</summary>
        [DisplayName("许可证")]
        [Description("许可证")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(18, "licence", "许可证", null, "nvarchar(200)", 0, 0, true)]
        public virtual String licence
        {
            get { return _licence; }
            set { if (OnPropertyChanging(__.licence, value)) { _licence = value; OnPropertyChanged(__.licence); } }
        }

        private String _regip;
        /// <summary></summary>
        [DisplayName("Regip")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "regip", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String regip
        {
            get { return _regip; }
            set { if (OnPropertyChanging(__.regip, value)) { _regip = value; OnPropertyChanged(__.regip); } }
        }

        private Int16 _isverify;
        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        [DisplayName("10:审核通过默认")]
        [Description("10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(20, "isverify", "10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过", "10", "smallint", 5, 0, false)]
        public virtual Int16 isverify
        {
            get { return _isverify; }
            set { if (OnPropertyChanging(__.isverify, value)) { _isverify = value; OnPropertyChanged(__.isverify); } }
        }

        private Int16 _hzslevel;
        /// <summary></summary>
        [DisplayName("Hzslevel")]
        [Description("")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(21, "hzslevel", "", "0", "smallint", 5, 0, false)]
        public virtual Int16 hzslevel
        {
            get { return _hzslevel; }
            set { if (OnPropertyChanging(__.hzslevel, value)) { _hzslevel = value; OnPropertyChanged(__.hzslevel); } }
        }

        private String _hzsintro;
        /// <summary></summary>
        [DisplayName("Hzsintro")]
        [Description("")]
        [DataObjectField(false, false, true, 300)]
        [BindColumn(22, "hzsintro", "", null, "nvarchar(300)", 0, 0, true)]
        public virtual String hzsintro
        {
            get { return _hzsintro; }
            set { if (OnPropertyChanging(__.hzsintro, value)) { _hzsintro = value; OnPropertyChanged(__.hzsintro); } }
        }

        private String _skin;
        /// <summary>存放企业黄页样式（.css文件）路径</summary>
        [DisplayName("存放企业黄页样式")]
        [Description("存放企业黄页样式（.css文件）路径")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(23, "skin", "存放企业黄页样式（.css文件）路径", null, "varchar(200)", 0, 0, false)]
        public virtual String skin
        {
            get { return _skin; }
            set { if (OnPropertyChanging(__.skin, value)) { _skin = value; OnPropertyChanged(__.skin); } }
        }

        private String _lasttime;
        /// <summary></summary>
        [DisplayName("Lasttime")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "lasttime", "", null, "varchar(50)", 0, 0, false)]
        public virtual String lasttime
        {
            get { return _lasttime; }
            set { if (OnPropertyChanging(__.lasttime, value)) { _lasttime = value; OnPropertyChanged(__.lasttime); } }
        }

        private String _mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(25, "mobile", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String mobile
        {
            get { return _mobile; }
            set { if (OnPropertyChanging(__.mobile, value)) { _mobile = value; OnPropertyChanged(__.mobile); } }
        }

        private String _qq;
        /// <summary></summary>
        [DisplayName("qq")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(26, "qq", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String qq
        {
            get { return _qq; }
            set { if (OnPropertyChanging(__.qq, value)) { _qq = value; OnPropertyChanged(__.qq); } }
        }

        private Int16 _isdel;
        /// <summary>0:未操作 默认。   1:删除</summary>
        [DisplayName("0:未操作默认")]
        [Description("0:未操作 默认。   1:删除")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(27, "isdel", "0:未操作 默认。   1:删除", "0", "smallint", 5, 0, false)]
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
        [BindColumn(28, "addtime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime addtime
        {
            get { return _addtime; }
            set { if (OnPropertyChanging(__.addtime, value)) { _addtime = value; OnPropertyChanged(__.addtime); } }
        }

        private Decimal _grade;
        /// <summary>平均评级</summary>
        [DisplayName("平均评级")]
        [Description("平均评级")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(29, "grade", "平均评级", "0", "numeric", 5, 2, false)]
        public virtual Decimal grade
        {
            get { return _grade; }
            set { if (OnPropertyChanging(__.grade, value)) { _grade = value; OnPropertyChanged(__.grade); } }
        }

        private Int16 _tjgrade;
        /// <summary>统计合作社等级</summary>
        [DisplayName("统计合作社等级")]
        [Description("统计合作社等级")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(30, "tjgrade", "统计合作社等级", "0", "smallint", 5, 0, false)]
        public virtual Int16 tjgrade
        {
            get { return _tjgrade; }
            set { if (OnPropertyChanging(__.tjgrade, value)) { _tjgrade = value; OnPropertyChanged(__.tjgrade); } }
        }

        private Int32 _uid;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(31, "uid", "", null, "int", 10, 0, false)]
        public virtual Int32 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private String _companyimg;
        /// <summary></summary>
        [DisplayName("Companyimg")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(32, "companyimg", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String companyimg
        {
            get { return _companyimg; }
            set { if (OnPropertyChanging(__.companyimg, value)) { _companyimg = value; OnPropertyChanged(__.companyimg); } }
        }

        private String _hzstjid;
        /// <summary>合作社统计系统中的ID</summary>
        [DisplayName("合作社统计系统中的ID")]
        [Description("合作社统计系统中的ID")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(33, "hzstjid", "合作社统计系统中的ID", null, "nvarchar(100)", 0, 0, true)]
        public virtual String hzstjid
        {
            get { return _hzstjid; }
            set { if (OnPropertyChanging(__.hzstjid, value)) { _hzstjid = value; OnPropertyChanged(__.hzstjid); } }
        }

        private String _hzstjname;
        /// <summary>合作社统计用户</summary>
        [DisplayName("合作社统计用户")]
        [Description("合作社统计用户")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(34, "hzstjname", "合作社统计用户", null, "nvarchar(100)", 0, 0, true)]
        public virtual String hzstjname
        {
            get { return _hzstjname; }
            set { if (OnPropertyChanging(__.hzstjname, value)) { _hzstjname = value; OnPropertyChanged(__.hzstjname); } }
        }

        private String _hzstjpwd;
        /// <summary>合作社统计用户密码</summary>
        [DisplayName("合作社统计用户密码")]
        [Description("合作社统计用户密码")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(35, "hzstjpwd", "合作社统计用户密码", null, "nvarchar(100)", 0, 0, true)]
        public virtual String hzstjpwd
        {
            get { return _hzstjpwd; }
            set { if (OnPropertyChanging(__.hzstjpwd, value)) { _hzstjpwd = value; OnPropertyChanged(__.hzstjpwd); } }
        }

        private String _hzsboss;
        /// <summary></summary>
        [DisplayName("Hzsboss")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(36, "hzsboss", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String hzsboss
        {
            get { return _hzsboss; }
            set { if (OnPropertyChanging(__.hzsboss, value)) { _hzsboss = value; OnPropertyChanged(__.hzsboss); } }
        }

        private String _hzslevellasttime;
        /// <summary></summary>
        [DisplayName("Hzslevellasttime")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(37, "hzslevellasttime", "", null, "varchar(50)", 0, 0, false)]
        public virtual String hzslevellasttime
        {
            get { return _hzslevellasttime; }
            set { if (OnPropertyChanging(__.hzslevellasttime, value)) { _hzslevellasttime = value; OnPropertyChanged(__.hzslevellasttime); } }
        }

        private Int16 _hzsdj;
        /// <summary>合作社级别</summary>
        [DisplayName("合作社级别")]
        [Description("合作社级别")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(38, "hzsdj", "合作社级别", "0", "smallint", 5, 0, false)]
        public virtual Int16 hzsdj
        {
            get { return _hzsdj; }
            set { if (OnPropertyChanging(__.hzsdj, value)) { _hzsdj = value; OnPropertyChanged(__.hzsdj); } }
        }

        private Int16 _sfsjb;
        /// <summary>示范社级别</summary>
        [DisplayName("示范社级别")]
        [Description("示范社级别")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(39, "sfsjb", "示范社级别", "0", "smallint", 5, 0, false)]
        public virtual Int16 sfsjb
        {
            get { return _sfsjb; }
            set { if (OnPropertyChanging(__.sfsjb, value)) { _sfsjb = value; OnPropertyChanged(__.sfsjb); } }
        }

        private Int16 _submitverify;
        /// <summary>提交合作社统计平台的审核</summary>
        [DisplayName("提交合作社统计平台的审核")]
        [Description("提交合作社统计平台的审核")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(40, "submitverify", "提交合作社统计平台的审核", "0", "smallint", 5, 0, false)]
        public virtual Int16 submitverify
        {
            get { return _submitverify; }
            set { if (OnPropertyChanging(__.submitverify, value)) { _submitverify = value; OnPropertyChanged(__.submitverify); } }
        }

        private Int16 _ishot;
        /// <summary>推荐合作社  0不推荐</summary>
        [DisplayName("推荐合作社0不推荐")]
        [Description("推荐合作社  0不推荐")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(41, "ishot", "推荐合作社  0不推荐", "0", "smallint", 5, 0, false)]
        public virtual Int16 ishot
        {
            get { return _ishot; }
            set { if (OnPropertyChanging(__.ishot, value)) { _ishot = value; OnPropertyChanged(__.ishot); } }
        }

        private Int32 _hzsbigclass;
        /// <summary>合作社大类  HzsClass表</summary>
        [DisplayName("合作社大类HzsClass表")]
        [Description("合作社大类  HzsClass表")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(42, "hzsbigclass", "合作社大类  HzsClass表", "0", "int", 10, 0, false)]
        public virtual Int32 hzsbigclass
        {
            get { return _hzsbigclass; }
            set { if (OnPropertyChanging(__.hzsbigclass, value)) { _hzsbigclass = value; OnPropertyChanged(__.hzsbigclass); } }
        }

        private Int32 _hzssmallclass;
        /// <summary>合作社小类  HzsClass表</summary>
        [DisplayName("合作社小类HzsClass表")]
        [Description("合作社小类  HzsClass表")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(43, "hzssmallclass", "合作社小类  HzsClass表", "0", "int", 10, 0, false)]
        public virtual Int32 hzssmallclass
        {
            get { return _hzssmallclass; }
            set { if (OnPropertyChanging(__.hzssmallclass, value)) { _hzssmallclass = value; OnPropertyChanged(__.hzssmallclass); } }
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
                    case __.hname : return _hname;
                    case __.hpwd : return _hpwd;
                    case __.email : return _email;
                    case __.sex : return _sex;
                    case __.htype : return _htype;
                    case __.linkman : return _linkman;
                    case __.corpname : return _corpname;
                    case __.tel : return _tel;
                    case __.fax : return _fax;
                    case __.province : return _province;
                    case __.city : return _city;
                    case __.county : return _county;
                    case __.address : return _address;
                    case __.zipcode : return _zipcode;
                    case __.scope : return _scope;
                    case __.corppic : return _corppic;
                    case __.cropregtime : return _cropregtime;
                    case __.licence : return _licence;
                    case __.regip : return _regip;
                    case __.isverify : return _isverify;
                    case __.hzslevel : return _hzslevel;
                    case __.hzsintro : return _hzsintro;
                    case __.skin : return _skin;
                    case __.lasttime : return _lasttime;
                    case __.mobile : return _mobile;
                    case __.qq : return _qq;
                    case __.isdel : return _isdel;
                    case __.addtime : return _addtime;
                    case __.grade : return _grade;
                    case __.tjgrade : return _tjgrade;
                    case __.uid : return _uid;
                    case __.companyimg : return _companyimg;
                    case __.hzstjid : return _hzstjid;
                    case __.hzstjname : return _hzstjname;
                    case __.hzstjpwd : return _hzstjpwd;
                    case __.hzsboss : return _hzsboss;
                    case __.hzslevellasttime : return _hzslevellasttime;
                    case __.hzsdj : return _hzsdj;
                    case __.sfsjb : return _sfsjb;
                    case __.submitverify : return _submitverify;
                    case __.ishot : return _ishot;
                    case __.hzsbigclass : return _hzsbigclass;
                    case __.hzssmallclass : return _hzssmallclass;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.hname : _hname = Convert.ToString(value); break;
                    case __.hpwd : _hpwd = Convert.ToString(value); break;
                    case __.email : _email = Convert.ToString(value); break;
                    case __.sex : _sex = Convert.ToInt16(value); break;
                    case __.htype : _htype = Convert.ToInt16(value); break;
                    case __.linkman : _linkman = Convert.ToString(value); break;
                    case __.corpname : _corpname = Convert.ToString(value); break;
                    case __.tel : _tel = Convert.ToString(value); break;
                    case __.fax : _fax = Convert.ToString(value); break;
                    case __.province : _province = Convert.ToInt64(value); break;
                    case __.city : _city = Convert.ToInt64(value); break;
                    case __.county : _county = Convert.ToInt64(value); break;
                    case __.address : _address = Convert.ToString(value); break;
                    case __.zipcode : _zipcode = Convert.ToString(value); break;
                    case __.scope : _scope = Convert.ToString(value); break;
                    case __.corppic : _corppic = Convert.ToString(value); break;
                    case __.cropregtime : _cropregtime = Convert.ToString(value); break;
                    case __.licence : _licence = Convert.ToString(value); break;
                    case __.regip : _regip = Convert.ToString(value); break;
                    case __.isverify : _isverify = Convert.ToInt16(value); break;
                    case __.hzslevel : _hzslevel = Convert.ToInt16(value); break;
                    case __.hzsintro : _hzsintro = Convert.ToString(value); break;
                    case __.skin : _skin = Convert.ToString(value); break;
                    case __.lasttime : _lasttime = Convert.ToString(value); break;
                    case __.mobile : _mobile = Convert.ToString(value); break;
                    case __.qq : _qq = Convert.ToString(value); break;
                    case __.isdel : _isdel = Convert.ToInt16(value); break;
                    case __.addtime : _addtime = Convert.ToDateTime(value); break;
                    case __.grade : _grade = Convert.ToDecimal(value); break;
                    case __.tjgrade : _tjgrade = Convert.ToInt16(value); break;
                    case __.uid : _uid = Convert.ToInt32(value); break;
                    case __.companyimg : _companyimg = Convert.ToString(value); break;
                    case __.hzstjid : _hzstjid = Convert.ToString(value); break;
                    case __.hzstjname : _hzstjname = Convert.ToString(value); break;
                    case __.hzstjpwd : _hzstjpwd = Convert.ToString(value); break;
                    case __.hzsboss : _hzsboss = Convert.ToString(value); break;
                    case __.hzslevellasttime : _hzslevellasttime = Convert.ToString(value); break;
                    case __.hzsdj : _hzsdj = Convert.ToInt16(value); break;
                    case __.sfsjb : _sfsjb = Convert.ToInt16(value); break;
                    case __.submitverify : _submitverify = Convert.ToInt16(value); break;
                    case __.ishot : _ishot = Convert.ToInt16(value); break;
                    case __.hzsbigclass : _hzsbigclass = Convert.ToInt32(value); break;
                    case __.hzssmallclass : _hzssmallclass = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得合作社会员表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field hname = FindByName(__.hname);

            ///<summary></summary>
            public static readonly Field hpwd = FindByName(__.hpwd);

            ///<summary></summary>
            public static readonly Field email = FindByName(__.email);

            ///<summary>1:男 默认。   2:女</summary>
            public static readonly Field sex = FindByName(__.sex);

            ///<summary></summary>
            public static readonly Field htype = FindByName(__.htype);

            ///<summary></summary>
            public static readonly Field linkman = FindByName(__.linkman);

            ///<summary></summary>
            public static readonly Field corpname = FindByName(__.corpname);

            ///<summary></summary>
            public static readonly Field tel = FindByName(__.tel);

            ///<summary></summary>
            public static readonly Field fax = FindByName(__.fax);

            ///<summary></summary>
            public static readonly Field province = FindByName(__.province);

            ///<summary></summary>
            public static readonly Field city = FindByName(__.city);

            ///<summary></summary>
            public static readonly Field county = FindByName(__.county);

            ///<summary></summary>
            public static readonly Field address = FindByName(__.address);

            ///<summary></summary>
            public static readonly Field zipcode = FindByName(__.zipcode);

            ///<summary>经营范围</summary>
            public static readonly Field scope = FindByName(__.scope);

            ///<summary></summary>
            public static readonly Field corppic = FindByName(__.corppic);

            ///<summary></summary>
            public static readonly Field cropregtime = FindByName(__.cropregtime);

            ///<summary>许可证</summary>
            public static readonly Field licence = FindByName(__.licence);

            ///<summary></summary>
            public static readonly Field regip = FindByName(__.regip);

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public static readonly Field isverify = FindByName(__.isverify);

            ///<summary></summary>
            public static readonly Field hzslevel = FindByName(__.hzslevel);

            ///<summary></summary>
            public static readonly Field hzsintro = FindByName(__.hzsintro);

            ///<summary>存放企业黄页样式（.css文件）路径</summary>
            public static readonly Field skin = FindByName(__.skin);

            ///<summary></summary>
            public static readonly Field lasttime = FindByName(__.lasttime);

            ///<summary></summary>
            public static readonly Field mobile = FindByName(__.mobile);

            ///<summary></summary>
            public static readonly Field qq = FindByName(__.qq);

            ///<summary>0:未操作 默认。   1:删除</summary>
            public static readonly Field isdel = FindByName(__.isdel);

            ///<summary></summary>
            public static readonly Field addtime = FindByName(__.addtime);

            ///<summary>平均评级</summary>
            public static readonly Field grade = FindByName(__.grade);

            ///<summary>统计合作社等级</summary>
            public static readonly Field tjgrade = FindByName(__.tjgrade);

            ///<summary></summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary></summary>
            public static readonly Field companyimg = FindByName(__.companyimg);

            ///<summary>合作社统计系统中的ID</summary>
            public static readonly Field hzstjid = FindByName(__.hzstjid);

            ///<summary>合作社统计用户</summary>
            public static readonly Field hzstjname = FindByName(__.hzstjname);

            ///<summary>合作社统计用户密码</summary>
            public static readonly Field hzstjpwd = FindByName(__.hzstjpwd);

            ///<summary></summary>
            public static readonly Field hzsboss = FindByName(__.hzsboss);

            ///<summary></summary>
            public static readonly Field hzslevellasttime = FindByName(__.hzslevellasttime);

            ///<summary>合作社级别</summary>
            public static readonly Field hzsdj = FindByName(__.hzsdj);

            ///<summary>示范社级别</summary>
            public static readonly Field sfsjb = FindByName(__.sfsjb);

            ///<summary>提交合作社统计平台的审核</summary>
            public static readonly Field submitverify = FindByName(__.submitverify);

            ///<summary>推荐合作社  0不推荐</summary>
            public static readonly Field ishot = FindByName(__.ishot);

            ///<summary>合作社大类  HzsClass表</summary>
            public static readonly Field hzsbigclass = FindByName(__.hzsbigclass);

            ///<summary>合作社小类  HzsClass表</summary>
            public static readonly Field hzssmallclass = FindByName(__.hzssmallclass);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得合作社会员表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String hname = "hname";

            ///<summary></summary>
            public const String hpwd = "hpwd";

            ///<summary></summary>
            public const String email = "email";

            ///<summary>1:男 默认。   2:女</summary>
            public const String sex = "sex";

            ///<summary></summary>
            public const String htype = "htype";

            ///<summary></summary>
            public const String linkman = "linkman";

            ///<summary></summary>
            public const String corpname = "corpname";

            ///<summary></summary>
            public const String tel = "tel";

            ///<summary></summary>
            public const String fax = "fax";

            ///<summary></summary>
            public const String province = "province";

            ///<summary></summary>
            public const String city = "city";

            ///<summary></summary>
            public const String county = "county";

            ///<summary></summary>
            public const String address = "address";

            ///<summary></summary>
            public const String zipcode = "zipcode";

            ///<summary>经营范围</summary>
            public const String scope = "scope";

            ///<summary></summary>
            public const String corppic = "corppic";

            ///<summary></summary>
            public const String cropregtime = "cropregtime";

            ///<summary>许可证</summary>
            public const String licence = "licence";

            ///<summary></summary>
            public const String regip = "regip";

            ///<summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
            public const String isverify = "isverify";

            ///<summary></summary>
            public const String hzslevel = "hzslevel";

            ///<summary></summary>
            public const String hzsintro = "hzsintro";

            ///<summary>存放企业黄页样式（.css文件）路径</summary>
            public const String skin = "skin";

            ///<summary></summary>
            public const String lasttime = "lasttime";

            ///<summary></summary>
            public const String mobile = "mobile";

            ///<summary></summary>
            public const String qq = "qq";

            ///<summary>0:未操作 默认。   1:删除</summary>
            public const String isdel = "isdel";

            ///<summary></summary>
            public const String addtime = "addtime";

            ///<summary>平均评级</summary>
            public const String grade = "grade";

            ///<summary>统计合作社等级</summary>
            public const String tjgrade = "tjgrade";

            ///<summary></summary>
            public const String uid = "uid";

            ///<summary></summary>
            public const String companyimg = "companyimg";

            ///<summary>合作社统计系统中的ID</summary>
            public const String hzstjid = "hzstjid";

            ///<summary>合作社统计用户</summary>
            public const String hzstjname = "hzstjname";

            ///<summary>合作社统计用户密码</summary>
            public const String hzstjpwd = "hzstjpwd";

            ///<summary></summary>
            public const String hzsboss = "hzsboss";

            ///<summary></summary>
            public const String hzslevellasttime = "hzslevellasttime";

            ///<summary>合作社级别</summary>
            public const String hzsdj = "hzsdj";

            ///<summary>示范社级别</summary>
            public const String sfsjb = "sfsjb";

            ///<summary>提交合作社统计平台的审核</summary>
            public const String submitverify = "submitverify";

            ///<summary>推荐合作社  0不推荐</summary>
            public const String ishot = "ishot";

            ///<summary>合作社大类  HzsClass表</summary>
            public const String hzsbigclass = "hzsbigclass";

            ///<summary>合作社小类  HzsClass表</summary>
            public const String hzssmallclass = "hzssmallclass";

        }
        #endregion
    }

    /// <summary>合作社会员表接口</summary>
    public partial interface IHzsUser
    {
        #region 属性
        /// <summary></summary>
        String hname { get; set; }

        /// <summary></summary>
        String hpwd { get; set; }

        /// <summary></summary>
        String email { get; set; }

        /// <summary>1:男 默认。   2:女</summary>
        Int16 sex { get; set; }

        /// <summary></summary>
        Int16 htype { get; set; }

        /// <summary></summary>
        String linkman { get; set; }

        /// <summary></summary>
        String corpname { get; set; }

        /// <summary></summary>
        String tel { get; set; }

        /// <summary></summary>
        String fax { get; set; }

        /// <summary></summary>
        Int64 province { get; set; }

        /// <summary></summary>
        Int64 city { get; set; }

        /// <summary></summary>
        Int64 county { get; set; }

        /// <summary></summary>
        String address { get; set; }

        /// <summary></summary>
        String zipcode { get; set; }

        /// <summary>经营范围</summary>
        String scope { get; set; }

        /// <summary></summary>
        String corppic { get; set; }

        /// <summary></summary>
        String cropregtime { get; set; }

        /// <summary>许可证</summary>
        String licence { get; set; }

        /// <summary></summary>
        String regip { get; set; }

        /// <summary>10:审核通过 默认。   20:待审核。   30:未审核。   40:未通过</summary>
        Int16 isverify { get; set; }

        /// <summary></summary>
        Int16 hzslevel { get; set; }

        /// <summary></summary>
        String hzsintro { get; set; }

        /// <summary>存放企业黄页样式（.css文件）路径</summary>
        String skin { get; set; }

        /// <summary></summary>
        String lasttime { get; set; }

        /// <summary></summary>
        String mobile { get; set; }

        /// <summary></summary>
        String qq { get; set; }

        /// <summary>0:未操作 默认。   1:删除</summary>
        Int16 isdel { get; set; }

        /// <summary></summary>
        DateTime addtime { get; set; }

        /// <summary>平均评级</summary>
        Decimal grade { get; set; }

        /// <summary>统计合作社等级</summary>
        Int16 tjgrade { get; set; }

        /// <summary></summary>
        Int32 uid { get; set; }

        /// <summary></summary>
        String companyimg { get; set; }

        /// <summary>合作社统计系统中的ID</summary>
        String hzstjid { get; set; }

        /// <summary>合作社统计用户</summary>
        String hzstjname { get; set; }

        /// <summary>合作社统计用户密码</summary>
        String hzstjpwd { get; set; }

        /// <summary></summary>
        String hzsboss { get; set; }

        /// <summary></summary>
        String hzslevellasttime { get; set; }

        /// <summary>合作社级别</summary>
        Int16 hzsdj { get; set; }

        /// <summary>示范社级别</summary>
        Int16 sfsjb { get; set; }

        /// <summary>提交合作社统计平台的审核</summary>
        Int16 submitverify { get; set; }

        /// <summary>推荐合作社  0不推荐</summary>
        Int16 ishot { get; set; }

        /// <summary>合作社大类  HzsClass表</summary>
        Int32 hzsbigclass { get; set; }

        /// <summary>合作社小类  HzsClass表</summary>
        Int32 hzssmallclass { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}