using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HzsModel.Config
{
    public class BackUpConfig
    {
        /// <summary>
        /// 备份的文件目录
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 设置的时间格式
        /// </summary>
        public string settime { get; set; }


        #region 单独设置时间字段
        ///// <summary>
        ///// 设置秒
        ///// </summary>
        //public string seconds { get; set; }
        ///// <summary>
        ///// 设置分
        ///// </summary>
        //public string minutes { get; set; }
        ///// <summary>
        ///// 设置小时
        ///// </summary>
        //public string hours { get; set; }
        ///// <summary>
        ///// 设置天
        ///// </summary>
        //public string days { get; set; }
        ///// <summary>
        ///// 设置月
        ///// </summary>
        //public string months { get; set; }
        ///// <summary>
        ///// 设置年
        ///// </summary>
        //public string years { get; set; } 
        #endregion
    }
}
