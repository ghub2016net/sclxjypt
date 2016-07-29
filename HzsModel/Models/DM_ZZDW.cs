﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace HzsModel.Models
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("组织单位代码")]
    [BindTable("DM_ZZDW", Description = "组织单位代码", ConnName = "hzsweb", DbType = DatabaseType.SqlServer)]
    public partial class DM_ZZDW : IDM_ZZDW
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _ZZDW_DM;
        /// <summary></summary>
        [DisplayName("ZZDW_DM")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ZZDW_DM", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ZZDW_DM
        {
            get { return _ZZDW_DM; }
            set { if (OnPropertyChanging("ZZDW_DM", value)) { _ZZDW_DM = value; OnPropertyChanged("ZZDW_DM"); } }
        }

        private String _ZZDW_QC;
        /// <summary></summary>
        [DisplayName("ZZDW_QC")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "ZZDW_QC", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ZZDW_QC
        {
            get { return _ZZDW_QC; }
            set { if (OnPropertyChanging("ZZDW_QC", value)) { _ZZDW_QC = value; OnPropertyChanged("ZZDW_QC"); } }
        }

        private String _ZZDW_JC;
        /// <summary></summary>
        [DisplayName("ZZDW_JC")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ZZDW_JC", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ZZDW_JC
        {
            get { return _ZZDW_JC; }
            set { if (OnPropertyChanging("ZZDW_JC", value)) { _ZZDW_JC = value; OnPropertyChanged("ZZDW_JC"); } }
        }

        private String _ZZDW_SJDM;
        /// <summary></summary>
        [DisplayName("ZZDW_SJDM")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "ZZDW_SJDM", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ZZDW_SJDM
        {
            get { return _ZZDW_SJDM; }
            set { if (OnPropertyChanging("ZZDW_SJDM", value)) { _ZZDW_SJDM = value; OnPropertyChanged("ZZDW_SJDM"); } }
        }

        private Int32 _ZZDW_JB;
        /// <summary></summary>
        [DisplayName("ZZDW_JB")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "ZZDW_JB", "", null, "int", 10, 0, false)]
        public virtual Int32 ZZDW_JB
        {
            get { return _ZZDW_JB; }
            set { if (OnPropertyChanging("ZZDW_JB", value)) { _ZZDW_JB = value; OnPropertyChanged("ZZDW_JB"); } }
        }

        private String _CJRY;
        /// <summary></summary>
        [DisplayName("CJRY")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "CJRY", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CJRY
        {
            get { return _CJRY; }
            set { if (OnPropertyChanging("CJRY", value)) { _CJRY = value; OnPropertyChanged("CJRY"); } }
        }

        private DateTime _CJRQ;
        /// <summary></summary>
        [DisplayName("CJRQ")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "CJRQ", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CJRQ
        {
            get { return _CJRQ; }
            set { if (OnPropertyChanging("CJRQ", value)) { _CJRQ = value; OnPropertyChanged("CJRQ"); } }
        }

        private Int32 _XH;
        /// <summary></summary>
        [DisplayName("XH")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "XH", "", null, "int", 10, 0, false)]
        public virtual Int32 XH
        {
            get { return _XH; }
            set { if (OnPropertyChanging("XH", value)) { _XH = value; OnPropertyChanged("XH"); } }
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
                    case "ID" : return _ID;
                    case "ZZDW_DM" : return _ZZDW_DM;
                    case "ZZDW_QC" : return _ZZDW_QC;
                    case "ZZDW_JC" : return _ZZDW_JC;
                    case "ZZDW_SJDM" : return _ZZDW_SJDM;
                    case "ZZDW_JB" : return _ZZDW_JB;
                    case "CJRY" : return _CJRY;
                    case "CJRQ" : return _CJRQ;
                    case "XH" : return _XH;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToInt32(value); break;
                    case "ZZDW_DM" : _ZZDW_DM = Convert.ToString(value); break;
                    case "ZZDW_QC" : _ZZDW_QC = Convert.ToString(value); break;
                    case "ZZDW_JC" : _ZZDW_JC = Convert.ToString(value); break;
                    case "ZZDW_SJDM" : _ZZDW_SJDM = Convert.ToString(value); break;
                    case "ZZDW_JB" : _ZZDW_JB = Convert.ToInt32(value); break;
                    case "CJRY" : _CJRY = Convert.ToString(value); break;
                    case "CJRQ" : _CJRQ = Convert.ToDateTime(value); break;
                    case "XH" : _XH = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName("ID");

            ///<summary></summary>
            public static readonly Field ZZDW_DM = FindByName("ZZDW_DM");

            ///<summary></summary>
            public static readonly Field ZZDW_QC = FindByName("ZZDW_QC");

            ///<summary></summary>
            public static readonly Field ZZDW_JC = FindByName("ZZDW_JC");

            ///<summary></summary>
            public static readonly Field ZZDW_SJDM = FindByName("ZZDW_SJDM");

            ///<summary></summary>
            public static readonly Field ZZDW_JB = FindByName("ZZDW_JB");

            ///<summary></summary>
            public static readonly Field CJRY = FindByName("CJRY");

            ///<summary></summary>
            public static readonly Field CJRQ = FindByName("CJRQ");

            ///<summary></summary>
            public static readonly Field XH = FindByName("XH");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IDM_ZZDW
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary></summary>
        String ZZDW_DM { get; set; }

        /// <summary></summary>
        String ZZDW_QC { get; set; }

        /// <summary></summary>
        String ZZDW_JC { get; set; }

        /// <summary></summary>
        String ZZDW_SJDM { get; set; }

        /// <summary></summary>
        Int32 ZZDW_JB { get; set; }

        /// <summary></summary>
        String CJRY { get; set; }

        /// <summary></summary>
        DateTime CJRQ { get; set; }

        /// <summary></summary>
        Int32 XH { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}