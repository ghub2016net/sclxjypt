using System;
namespace HzsController
{
	/// <summary>
	/// 创建BLL的一个简单的工厂。
	/// </summary>
	public static class BllFactory
	{
        /// <summary>
        /// 站点参数设置
        /// </summary>
        /// <returns></returns>
        public static ISiteConfig GetISiteConfigBLL()
        {
            return new SiteConfigSqlBLL();
        }

	}
}
