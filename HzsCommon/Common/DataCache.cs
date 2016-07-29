using System;
using System.Web;

namespace HzsCommon
{
	/// <summary>
	/// 缓存相关的操作类
    /// Copyright (C) Maticsoft
	/// </summary>
	public static class DataCache
	{
        /// <summary>
        /// 创建缓存项的文件依赖
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="fileName">文件绝对路径</param>
        public static void Insert(string key, object obj, string fileName)
        {
            //创建缓存依赖项
            System.Web.Caching.CacheDependency dep = new System.Web.Caching.CacheDependency(fileName);
            //创建缓存
            HttpRuntime.Cache.Insert(key, obj, dep);
        }

		/// <summary>
		/// 获取当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="CacheKey">缓存Key</param>
        /// <returns></returns>
        public static T Get<T>(string CacheKey)
        {
            object obj = GetCache(CacheKey);
            return obj == null ? default(T) : (T)obj;
        }

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

        /// <summary>
        /// 创建缓存项过期
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void SetCache(string CacheKey, object objObject, int expires)
        {
            HttpContext.Current.Cache.Insert(CacheKey, objObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, expires, 0));
        }

		/// <summary>
        /// 创建缓存项过期
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
        /// <param name="absoluteExpiration">Cache.NoAbsoluteExpiration/DateTime...</param>
        /// <param name="slidingExpiration">Cache.NoSlidingExpiration/TimeSpan.FromHours</param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}

        /// <summary>
        /// 删除指定缓存项
        /// </summary>
        /// <param name="key">key</param>
        public static void RemoveCache(string key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(key);
        }
	}
}
