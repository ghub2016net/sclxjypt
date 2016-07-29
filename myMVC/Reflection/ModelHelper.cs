using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Configuration;
using System.Web.Configuration;


namespace MyMVC
{
	internal static class ModelHelper
	{
		public static readonly bool IsDebugMode;

		static ModelHelper()
		{
			CompilationSection configSection = 
						ConfigurationManager.GetSection("system.web/compilation") as CompilationSection;
			if( configSection != null )
				IsDebugMode = configSection.Debug;
		}

		/// <summary>
		/// 根据HttpRequest填充一个数据实体。
		/// 这里不支持嵌套类型的数据实体，且要求各数据成员都是简单的数据类型。
		/// </summary>
		/// <param name="request"></param>
		/// <param name="model"></param>
		public static void FillModel(HttpRequest request, object model, string paramName)
		{
			ModelDescripton descripton = ReflectionHelper.GetModelDescripton(model.GetType());

			object val = null;
			foreach( DataMember field in descripton.Fields ) {

				// 这里的实现方式不支持嵌套类型的数据实体。
				// 如果有这方面的需求，可以将这里改成递归的嵌套调用。

				val = GetValueByKeyAndTypeFrommRequest(
									request, field.Name, field.Type.GetRealType(), paramName);
				if( val != null )
					field.SetValue(model, val);
			}
		}


		/// <summary>
		/// 读取一个HTTP参数值。这里只读取QueryString以及Form
		/// </summary>
		/// <param name="request"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetHttpValue(HttpRequest request, string key)
		{
			string val = request.QueryString[key];
			if( val == null )
				val = request.Form[key];

			return val;
		}
		
		public static object GetValueByKeyAndTypeFrommRequest(
							HttpRequest request, string key, Type type, string paramName)
		{
			// 不支持复杂类型
			if( type.IsSimpleType() == false )
				return null;

			string val = GetHttpValue(request, key);
			if( val == null ) {
				// 再试一次。有可能是多个自定义类型，Form表单元素采用变量名做为前缀。
				if( string.IsNullOrEmpty(paramName) == false ) {
					val = GetHttpValue(request, paramName + "." + key);
				}

				if( val == null )
					return null;
			}

			return SafeChangeType(val.Trim(), type);
		}


		public static object SafeChangeType(string value, Type conversionType)
		{
			if( conversionType == typeof(string) )
				return value;

			if( value == null || value.Length == 0 ) {
				// 空字符串根本不能做任何转换，所以直接返回null
				return null;
			}

			try {
				// 为了简单，直接调用 .net framework中的方法。
				// 如果转换失败，则会抛出异常。
				return Convert.ChangeType(value, conversionType);
			}
			catch {
				if( IsDebugMode )
					throw;			// Debug 模式下抛异常
				else {
					// Release模式下忽略异常（防止恶意用户错误输入）
					return null;
				}
			}
		}

	}


	
}
