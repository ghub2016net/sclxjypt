using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HzsModel.Config
{
    [Serializable]
    public class SiteConfig
    {
        /// <summary>
        /// 系统安装目录
        /// </summary>
        public string systempath { get; set; }

        public string webpath { get; set; }
        /// <summary>
        /// 后台目录
        /// </summary>
        public string webadminpath { get; set; }
        /// <summary>
        /// 是否开启统计true/false 默认false
        /// </summary>
        public string numtongji { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string dbname { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string sitename { get; set; }
        /// <summary>
        /// 是否开启HTML生成 true/false 默认false
        /// </summary>
        public string ishtml { get; set; }
        /// <summary>
        /// 视频转换器地址
        /// </summary>
        public string ffmpeg { get; set; }
        /// <summary>
        /// 网站域名
        /// </summary>
        public string website { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string companyname { get; set; }
    }
}
