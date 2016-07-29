﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMVC
{
	/// <summary>
	/// 用于描述一个Action可以处理哪些请求路径。
	/// 注意：这个Attribute可以多次使用，表示可以处理多个请求路径。
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public class PageUrlAttribute : Attribute
	{
		/// <summary>
		/// 指示可以处理的请求路径。比如："/abc.aspx" 
		/// （Ajax请求【不使用】此参数）
		/// </summary>
		public string Url { get; set; }
	}


	/// <summary>
	/// 将一个方法标记为一个Action
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class ActionAttribute : Attribute
	{
		// 目前没有任何属性，就只是个空的标记
	}


	

}
