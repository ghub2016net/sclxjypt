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
    /// <summary>LoginLog</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_LoginLog_adminid", false, "adminid")]
    [BindIndex("IX_LoginLog_islogin", false, "islogin")]
    [BindIndex("IX_LoginLog_ltype", false, "ltype")]
    [BindIndex("PK__LoginLog__3213E83F3F466844", true, "id")]
    [BindTable("LoginLog", Description = "", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class LoginLog : ILoginLog
    {
        #region 属性

        private Int32 _adminid;
        /// <summary></summary>
        [DisplayName("Adminid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(1, "adminid", "", null, "int", 10, 0, false)]
        public virtual Int32 adminid
        {
            get { return _adminid; }
            set { if (OnPropertyChanging(__.adminid, value)) { _adminid = value; OnPropertyChanged(__.adminid); } }
        }

        private String _adminname;
        /// <summary></summary>
        [DisplayName("Adminname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "adminname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String adminname
        {
            get { return _adminname; }
            set { if (OnPropertyChanging(__.adminname, value)) { _adminname = value; OnPropertyChanged(__.adminname); } }
        }

        private String _remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "remark", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String remark
        {
            get { return _remark; }
            set { if (OnPropertyChanging(__.remark, value)) { _remark = value; OnPropertyChanged(__.remark); } }
        }

        private DateTime _logintime;
        /// <summary></summary>
        [DisplayName("Logintime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(4, "logintime", "", "getdate()", "datetime", 3, 0, false)]
        public virtual DateTime logintime
        {
            get { return _logintime; }
            set { if (OnPropertyChanging(__.logintime, value)) { _logintime = value; OnPropertyChanged(__.logintime); } }
        }

        private String _loginip;
        /// <summary></summary>
        [DisplayName("Loginip")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "loginip", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String loginip
        {
            get { return _loginip; }
            set { if (OnPropertyChanging(__.loginip, value)) { _loginip = value; OnPropertyChanged(__.loginip); } }
        }

        private Int16 _ltype;
        /// <summary>区分管理员和会员 1:admin  2:hzsuser</summary>
        [DisplayName("区分管理员和会员1:admin2:hzsuser")]
        [Description("区分管理员和会员 1:admin  2:hzsuser")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(6, "ltype", "区分管理员和会员 1:admin  2:hzsuser", null, "smallint", 5, 0, false)]
        public virtual Int16 ltype
        {
            get { return _ltype; }
            set { if (OnPropertyChanging(__.ltype, value)) { _ltype = value; OnPropertyChanged(__.ltype); } }
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

        private Int16 _islogin;
        /// <summary>登陆是否成功 0:yes  1:no</summary>
        [DisplayName("登陆是否成功0:yes1:no")]
        [Description("登陆是否成功 0:yes  1:no")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(8, "islogin", "登陆是否成功 0:yes  1:no", "0", "smallint", 5, 0, false)]
        public virtual Int16 islogin
        {
            get { return _islogin; }
            set { if (OnPropertyChanging(__.islogin, value)) { _islogin = value; OnPropertyChanged(__.islogin); } }
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
                    case __.adminid : return _adminid;
                    case __.adminname : return _adminname;
                    case __.remark : return _remark;
                    case __.logintime : return _logintime;
                    case __.loginip : return _loginip;
                    case __.ltype : return _ltype;
                    case __.id : return _id;
                    case __.islogin : return _islogin;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.adminid : _adminid = Convert.ToInt32(value); break;
                    case __.adminname : _adminname = Convert.ToString(value); break;
                    case __.remark : _remark = Convert.ToString(value); break;
                    case __.logintime : _logintime = Convert.ToDateTime(value); break;
                    case __.loginip : _loginip = Convert.ToString(value); break;
                    case __.ltype : _ltype = Convert.ToInt16(value); break;
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.islogin : _islogin = Convert.ToInt16(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得LoginLog字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field adminid = FindByName(__.adminid);

            ///<summary></summary>
            public static readonly Field adminname = FindByName(__.adminname);

            ///<summary></summary>
            public static readonly Field remark = FindByName(__.remark);

            ///<summary></summary>
            public static readonly Field logintime = FindByName(__.logintime);

            ///<summary></summary>
            public static readonly Field loginip = FindByName(__.loginip);

            ///<summary>区分管理员和会员 1:admin  2:hzsuser</summary>
            public static readonly Field ltype = FindByName(__.ltype);

            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>登陆是否成功 0:yes  1:no</summary>
            public static readonly Field islogin = FindByName(__.islogin);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得LoginLog字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String adminid = "adminid";

            ///<summary></summary>
            public const String adminname = "adminname";

            ///<summary></summary>
            public const String remark = "remark";

            ///<summary></summary>
            public const String logintime = "logintime";

            ///<summary></summary>
            public const String loginip = "loginip";

            ///<summary>区分管理员和会员 1:admin  2:hzsuser</summary>
            public const String ltype = "ltype";

            ///<summary></summary>
            public const String id = "id";

            ///<summary>登陆是否成功 0:yes  1:no</summary>
            public const String islogin = "islogin";

        }
        #endregion
    }

    /// <summary>LoginLog接口</summary>
    /// <remarks></remarks>
    public partial interface ILoginLog
    {
        #region 属性
        /// <summary></summary>
        Int32 adminid { get; set; }

        /// <summary></summary>
        String adminname { get; set; }

        /// <summary></summary>
        String remark { get; set; }

        /// <summary></summary>
        DateTime logintime { get; set; }

        /// <summary></summary>
        String loginip { get; set; }

        /// <summary>区分管理员和会员 1:admin  2:hzsuser</summary>
        Int16 ltype { get; set; }

        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary>登陆是否成功 0:yes  1:no</summary>
        Int16 islogin { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}