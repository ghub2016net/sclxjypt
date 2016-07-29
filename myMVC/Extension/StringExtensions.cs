using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MyMVC
{
	/// <summary>
	/// 用于UI输出方面的常用字符串扩展
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// 将字符串转换为 HTML 编码的字符串。
		/// </summary>
		/// <param name="str">要编码的字符串。</param>
		/// <returns>一个已编码的字符串。</returns>
		public static string HtmlEncode(this string str)
		{
			if( string.IsNullOrEmpty(str) )
				return string.Empty;

			return HttpUtility.HtmlEncode(str);
		}

		/// <summary>
		/// 将字符串最小限度地转换为 HTML 编码的字符串。
		/// </summary>
		/// <param name="str">要编码的字符串。</param>
		/// <returns>一个已编码的字符串。</returns>
		public static string HtmlAttributeEncode(this string str)
		{
			if( string.IsNullOrEmpty(str) )
				return string.Empty;

			return HttpUtility.HtmlAttributeEncode(str);
		}

	}
}
