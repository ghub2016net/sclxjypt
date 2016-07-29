﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.CodeDom;
using System.Web.UI;


namespace MyMVC
{
	/// <summary>
	/// 一个“用户控件”基类
	/// </summary>
	[FileLevelControlBuilder(typeof(ViewUserControlControlBuilder))]
	public class MyBaseUserControl : System.Web.UI.UserControl
	{
		public virtual void SetModel(object model)
		{
		}
	}


	internal sealed class ViewUserControlControlBuilder : FileLevelUserControlBuilder
	{
		internal string UserControlBaseType
		{
			get;
			set;
		}

		public override void ProcessGeneratedCode(
			CodeCompileUnit codeCompileUnit,
			CodeTypeDeclaration baseType,
			CodeTypeDeclaration derivedType,
			CodeMemberMethod buildMethod,
			CodeMemberMethod dataBindingMethod)
		{

			// 如果分析器找到一个有效的类型，就使用它。
			if( UserControlBaseType != null ) {
				derivedType.BaseTypes[0] = new CodeTypeReference(UserControlBaseType);
			}
		}
	}
	


}
