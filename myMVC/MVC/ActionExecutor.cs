using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Collections.Specialized;

namespace MyMVC
{
	public static class ActionExecutor
	{
		/// <summary>
		/// 执行一次Ajax调用请求。例如："/AjaxOrder/AddOrder.cspx"
		/// </summary>
		/// <param name="context"></param>
		/// <param name="pair"></param>
		public static void ExecuteAjaxAction(HttpContext context, ControllerActionPair pair)
		{
			if( context == null )
				throw new ArgumentNullException("context");
			if( pair == null )
				throw new ArgumentNullException("pair");

			InvokeInfo vkInfo = ReflectionHelper.GetAjaxInvokeInfo(pair);
			if( vkInfo == null )
				ExceptionHelper.Throw404Exception(context);

			ExecuteAction(context, vkInfo);
		}

		/// <summary>
		/// 执行指定的页面请求。例如："/Pages/Categories.aspx"
		/// </summary>
		/// <param name="context"></param>
		/// <param name="virtualPath"></param>
		/// <returns></returns>
		public static void ExecutePageAction(HttpContext context, string virtualPath)
		{
			if( context == null )
				throw new ArgumentNullException("context");
			if( string.IsNullOrEmpty(virtualPath) )
				throw new ArgumentNullException("virtualPath");

			// 根据请求路径获取对应的调用信息
			InvokeInfo vkInfo = ReflectionHelper.GetPageActionInvokeInfo(virtualPath);
			if( vkInfo == null )
				ExceptionHelper.Throw404Exception(context);

			ExecuteAction(context, vkInfo);
		}


		internal static void ExecuteAction(HttpContext context, InvokeInfo vkInfo)
		{
			if( context == null )
				throw new ArgumentNullException("context");
			if( vkInfo == null )
				throw new ArgumentNullException("vkInfo");

			// 验证请求是否允许访问（身份验证）
			AuthorizeAttribute authorize = vkInfo.GetAuthorize();
			if( authorize != null ) {
				if( authorize.AuthenticateRequest(context) == false )
					ExceptionHelper.Throw403Exception(context);
			}

			// 调用方法
			object result = ExecuteActionInternal(context, vkInfo);

			// 设置OutputCache
			OutputCacheAttribute outputCache = vkInfo.GetOutputCacheSetting();
			if( outputCache != null )
				outputCache.SetResponseCache(context);

			// 处理方法的返回结果
			IActionResult executeResult = result as IActionResult;
			if( executeResult != null ) {
				executeResult.Ouput(context);
			}
			else {
				if( result != null ) {
					// 普通类型结果
					context.Response.ContentType = "text/plain";
					context.Response.Write(result.ToString());
				}
			}
		}

		internal static object ExecuteActionInternal(HttpContext context, InvokeInfo info)
		{
			// 准备要传给调用方法的参数
			object[] parameters = GetActionCallParameters(context, info.Action);

			// 调用方法
			if( info.Action.HasReturn )
				return info.Action.MethodInfo.Invoke(info.Instance, parameters);

			else {
				info.Action.MethodInfo.Invoke(info.Instance, parameters);
				return null;
			}
		}


		private static object[] GetActionCallParameters(HttpContext context, ActionDescription action)
		{
			if( action.Parameters == null || action.Parameters.Length == 0 )
				return null;

			object[] parameters = new object[action.Parameters.Length];

			for( int i = 0; i < action.Parameters.Length; i++ ) {
				ParameterInfo p = action.Parameters[i];

				if( p.IsOut )
					continue;

				if( p.ParameterType == typeof(NameValueCollection) ) {
					if( string.Compare(p.Name, "Form", StringComparison.OrdinalIgnoreCase) == 0 )
						parameters[i] = context.Request.Form;
					else if( string.Compare(p.Name, "QueryString", StringComparison.OrdinalIgnoreCase) == 0 )
						parameters[i] = context.Request.QueryString;
					else if( string.Compare(p.Name, "Headers", StringComparison.OrdinalIgnoreCase) == 0 )
						parameters[i] = context.Request.Headers;
					else if( string.Compare(p.Name, "ServerVariables", StringComparison.OrdinalIgnoreCase) == 0 )
						parameters[i] = context.Request.ServerVariables;
				}
				else{
					Type paramterType = p.ParameterType.GetRealType();

					// 如果参数是简单类型，则直接从HttpRequest中读取并赋值
					if( paramterType.IsSimpleType() ) {
						object val = ModelHelper.GetValueByKeyAndTypeFrommRequest(
														context.Request, p.Name, paramterType, null);
						if( val != null )
							parameters[i] = val;
					}
					else {
						// 自定义的类型。首先创建实例，然后给所有成员赋值。
						// 注意：这里不支持嵌套类型的自定义类型。
						object item = Activator.CreateInstance(paramterType);
						ModelHelper.FillModel(context.Request, item, p.Name);
						parameters[i] = item;
					}
				}
			}

			return parameters;
		}

	}
}
