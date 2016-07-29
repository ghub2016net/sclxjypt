using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HzsCommon
{
    public class HzsKey
    {
        //系统版本
        /// <summary>
        /// 版本号全称
        /// </summary>
        public const string HIK_VERSION = "1.0.0";
        /// <summary>
        /// 版本年号
        /// </summary>
        public const string HIK_YEAR = "2016";

        /*
         Cache +++++++++++++++++++++++++
         */
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "hzs_cache_siteconfig";

        /*
         * Cookie ++++++++++++++++++++++++++
         */
        /// <summary>
        /// 后台管理员信息集合
        /// </summary>
        public const string COOKIE_ADMIN_MESSAGE = "hzs_cookie_htmsg"; 

        /*
         * 其他定义属性 +++++++++++++++++++++++++++++
         */

        /// <summary>
        /// 后台管理员登录合作社用户保存用户ID使用此值
        /// </summary>
        public const string COOKIE_ADMIN_HZSUSERID = "hzs_cookie_adminto_uid";

        /// <summary>
        /// 后台管理员登录名称
        /// </summary>
        public const string CACHE_HTM = "hqm";
        /// <summary>
        /// 后台管理员登录ID
        /// </summary>
        public const string CACHE_HTUID = "htuid";
        /// <summary>
        /// 后台管理员类型
        /// </summary>
        public const string CACHE_HTTYPE = "htutype";
        /// <summary>
        /// 新闻类型JSON数据
        /// </summary>
        public const string CACHE_NEWSTYPE_JSON = "json_newstype";
        /// <summary>
        /// 地方频道对应的地区JSON
        /// </summary>
        public const string CACHE_PLACEAREA_JSON = "json_placearea";
        /// <summary>
        /// 地方频道对应的地区LIST
        /// </summary>
        public const string CACHE_PLACEAREA_LIST = "list_placearea";
        /// <summary>
        ///乡镇
        /// </summary>
        public const string CACHE_XZ_LIST = "list_xz";
        /// <summary>
        ///村
        /// </summary>
        public const string CACHE_CUN_LIST = "list_cun";
        /// <summary>
        /// 地区JSON hzsarea
        /// </summary>
        public const string CACHE_HZSAREA_JSON = "json_hzsarea";
        /// <summary>
        /// 地区LIST hzsarea
        /// </summary>
        public const string CACHE_HZSAREA_LIST = "list_hzsarea";
        /// <summary>
        /// 供求产品类型JSON  tradesort
        /// </summary>
        public const string CACHE_TRADESORT_JSON = "json_tradesort";
        /// <summary>
        /// 供求产品类型LIST  tradesort
        /// </summary>
        public const string CACHE_TRADESORT_LIST = "list_tradesort";

        /*
         *合作社会员信息集合
         */
        /// <summary>
        /// 合作社会员信息集合
        /// </summary>
        public const string COOKIE_HZSUSER_MESSAGE = "hzs_cookie_usmsg";

        /// <summary>
        /// 后台管理员登录名称
        /// </summary>
        public const string CACHE_HZSUSER_NAME = "hzs_login_name";

        /// <summary>
        /// 合作社登录用户ID
        /// </summary>
        public const string CACHE_HZSUSER_UID = "hzs_login_uid";

    }
}
