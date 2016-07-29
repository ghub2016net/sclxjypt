using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Compilation;

namespace MyMVC
{
	public interface IActionResult
	{
		void Ouput(HttpContext context);
	}

	/// <summary>
	/// 表示一个用户控件结果（用户控件将由框架执行）
	/// </summary>
	public sealed class UcResult : IActionResult
	{
		public string VirtualPath { get; private set; }
		public object Model { get; private set; }

		public UcResult(string virtualPath, object model)
		{
			if( string.IsNullOrEmpty(virtualPath) )
				throw new ArgumentNullException("virtualPath");

			this.VirtualPath = virtualPath;
			this.Model = model;
		}

		void IActionResult.Ouput(HttpContext context)
		{
			context.Response.ContentType = "text/html";
			string html = UcExecutor.Render(VirtualPath, Model);
			context.Response.Write(html);
		}
	}


	/// <summary>
	/// 表示一个重定向的结果
	/// </summary>
	public sealed class RedirectResult : IActionResult
	{
		public string Url { get; private set; }

		public RedirectResult(string url)
		{
			if( string.IsNullOrEmpty(url) )
				throw new ArgumentNullException("url");
			Url = url;
		}

		void IActionResult.Ouput(HttpContext context)
		{
			context.Response.Redirect(Url, true);
		}
	}

	/// <summary>
	/// 一个Json对象结果
	/// </summary>
	public sealed class JsonResult : IActionResult
	{
		public object Model { get; private set; }

		public JsonResult(object model)
		{
			if( model == null )
				throw new ArgumentNullException("model");

			this.Model = model;
		}

		void IActionResult.Ouput(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			string json = (new JavaScriptSerializer()).Serialize(Model);
			context.Response.Write(json);
		}
	}

	/// <summary>
	/// 表示一个页面结果（页面将由框架执行）
	/// </summary>
	public sealed class PageResult : IActionResult
	{
		public string VirtualPath { get; private set; }
		public object Model { get; private set; }

		public PageResult(string virtualPath, object model)
		{
			this.VirtualPath = virtualPath;
			this.Model = model;
		}

		void IActionResult.Ouput(HttpContext context)
		{
			if( string.IsNullOrEmpty(this.VirtualPath) )
				this.VirtualPath = context.Request.FilePath;

			context.Response.ContentType = "text/html";
			string html = PageExecutor.Render(context, VirtualPath, Model);
			context.Response.Write(html);
		}
	}



}
