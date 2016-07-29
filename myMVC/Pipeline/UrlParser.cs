using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace MyMVC
{
/*
	可以解析以下格式的URL：（前三个表示包含命名空间的）

	/Fish.AA.AjaxTest/Add.cspx
	/Fish.BB.AjaxTest.Add.cspx
	/Fish/BB/AjaxTest/Add.cspx
	/AjaxDemo/GetMd5.cspx
	/AjaxDemo.GetMd5.cspx
*/

	internal static class UrlParser
	{
		// 用于匹配Ajax请求的正则表达式，
		// 可以匹配的URL：/AjaxClass/method.cspx?id=2
		// 注意：类名必须Ajax做为前缀
		internal static readonly string AjaxUrlPattern
			= @"/(?<name>(\w[\./\w]*)?(?=Ajax)\w+)[/\.](?<method>\w+)\.[a-zA-Z]+";

		public static ControllerActionPair ParseAjaxUrl(string path)
		{
			if( string.IsNullOrEmpty(path) )
				throw new ArgumentNullException("path");

			Match match = Regex.Match(path, AjaxUrlPattern);
			if( match.Success == false )
				return null;

			return new ControllerActionPair {
				Controller = match.Groups["name"].Value.Replace("/", "."),
				Action = match.Groups["method"].Value
			};
		}
	}
}
