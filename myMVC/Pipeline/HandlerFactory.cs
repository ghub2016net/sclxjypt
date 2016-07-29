using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace MyMVC
{

	internal sealed class AjaxHandlerFactory : IHttpHandlerFactory
	{
		public IHttpHandler GetHandler(HttpContext context,
							string requestType, string virtualPath, string physicalPath)
		{
			// 根据请求路径，定位到要执行的Action
			ControllerActionPair pair = UrlParser.ParseAjaxUrl(virtualPath);
			if( pair == null )
				ExceptionHelper.Throw404Exception(context);

			// 获取内部表示的调用信息
			InvokeInfo vkInfo = ReflectionHelper.GetAjaxInvokeInfo(pair);
			if( vkInfo == null )
				ExceptionHelper.Throw404Exception(context);

			// 创建能够调用Action的HttpHandler
			return ActionHandler.CreateHandler(vkInfo);
		}
		
		public void ReleaseHandler(IHttpHandler handler)
		{
		}
	}

	internal sealed class AspnetPageHandlerFactory : PageHandlerFactory { }

	public sealed class MvcPageHandlerFactory : IHttpHandlerFactory
	{
		/// <summary>
		/// 尝试根据当前请求，获取一个有效的Action，并返回ActionHandler
		/// 此方法可以在HttpModule中使用，用于替代httpHandler的映射配置
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static IHttpHandler TryGetHandler(HttpContext context)
		{
			InvokeInfo vkInfo = ReflectionHelper.GetPageActionInvokeInfo(context.Request.FilePath);
			if( vkInfo == null ) 
				return null;

			return ActionHandler.CreateHandler(vkInfo);
		}

		private AspnetPageHandlerFactory _msPageHandlerFactory;

		IHttpHandler IHttpHandlerFactory.GetHandler(HttpContext context, 
							string requestType, string virtualPath, string physicalPath)
		{
			// 尝试根据请求路径获取Action
			InvokeInfo vkInfo = ReflectionHelper.GetPageActionInvokeInfo(virtualPath);
			
			// 如果没有找到合适的Action，并且请求的是一个ASPX页面，则按ASP.NET默认的方式来继续处理
			if( vkInfo == null && virtualPath.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase) ) {
				if( _msPageHandlerFactory == null )
					_msPageHandlerFactory = new AspnetPageHandlerFactory();

				// 调用ASP.NET默认的Page处理器工厂来处理
				return _msPageHandlerFactory.GetHandler(context, requestType, virtualPath, physicalPath);
			}

			return ActionHandler.CreateHandler(vkInfo);
		}

		void IHttpHandlerFactory.ReleaseHandler(IHttpHandler handler)
		{			
		}
	}

	
}
