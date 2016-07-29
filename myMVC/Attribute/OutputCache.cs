using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace MyMVC
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	public class OutputCacheAttribute : Attribute
	{
		private OutputCacheParameters _cacheSettings = new OutputCacheParameters();

		public string CacheProfile
		{
			get { return _cacheSettings.CacheProfile ?? String.Empty; }
			set { _cacheSettings.CacheProfile = value; }
		}

		internal OutputCacheParameters CacheSettings
		{
			get { return _cacheSettings; }
		}

		public int Duration
		{
			get { return _cacheSettings.Duration; }
			set { _cacheSettings.Duration = value; }
		}

		public OutputCacheLocation Location
		{
			get { return _cacheSettings.Location; }
			set { _cacheSettings.Location = value; }
		}

		public bool NoStore
		{
			get { return _cacheSettings.NoStore; }
			set { _cacheSettings.NoStore = value; }
		}

		public string SqlDependency
		{
			get { return _cacheSettings.SqlDependency ?? String.Empty; }
			set { _cacheSettings.SqlDependency = value; }
		}

		public string VaryByContentEncoding
		{
			get { return _cacheSettings.VaryByContentEncoding ?? String.Empty; }
			set { _cacheSettings.VaryByContentEncoding = value; }
		}

		public string VaryByCustom
		{
			get { return _cacheSettings.VaryByCustom ?? String.Empty; }
			set { _cacheSettings.VaryByCustom = value; }
		}

		public string VaryByHeader
		{
			get { return _cacheSettings.VaryByHeader ?? String.Empty; }
			set { _cacheSettings.VaryByHeader = value; }
		}

		public string VaryByParam
		{
			get { return _cacheSettings.VaryByParam ?? String.Empty; }
			set { _cacheSettings.VaryByParam = value; }
		}

		internal void SetResponseCache(HttpContext context)
		{
			if( context == null )
				throw new ArgumentNullException("context");

			OutputCachedPage page = new OutputCachedPage(_cacheSettings);
			page.ProcessRequest(context);
		}

		private sealed class OutputCachedPage : Page
		{
			private OutputCacheParameters _cacheSettings;

			public OutputCachedPage(OutputCacheParameters cacheSettings)
			{
				this.ID = Guid.NewGuid().ToString();
				_cacheSettings = cacheSettings;
			}

			protected override void FrameworkInitialize()
			{
				base.FrameworkInitialize();
				InitOutputCache(_cacheSettings);
			}
		}
	}
}
