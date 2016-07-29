using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyMVC
{
	public sealed class ControllerActionPair
	{
		public string Controller;
		public string Action;
	}

	internal class BaseDescription
	{
		public OutputCacheAttribute OutputCache { get; protected set; }
		public SessionModeAttribute SessionMode { get; protected set; }
		public AuthorizeAttribute Authorize { get; protected set; }

		protected BaseDescription(MemberInfo m)
		{
			this.OutputCache = m.GetMyAttribute<OutputCacheAttribute>();
			this.SessionMode = m.GetMyAttribute<SessionModeAttribute>();
			this.Authorize = m.GetMyAttribute<AuthorizeAttribute>(true /* inherit */);
		}
	}

	internal sealed class ControllerDescription : BaseDescription
	{
		public Type ControllerType { get; private set; }

		public ControllerDescription(Type t) : base(t)
		{
			this.ControllerType = t;
		}
	}

	internal sealed class ActionDescription : BaseDescription
	{
		public ControllerDescription PageController; //为PageAction保留
		public MethodInfo MethodInfo { get; private set; }
		public ActionAttribute Attr { get; private set; }
		public ParameterInfo[] Parameters { get; private set; }
		public bool HasReturn { get; private set; }

		public ActionDescription(MethodInfo m, ActionAttribute atrr) : base(m)
		{
			this.MethodInfo = m;
			this.Attr = atrr;
			this.Parameters = m.GetParameters();
			this.HasReturn = m.ReturnType != ReflectionHelper.VoidType;
		}
	}

	internal sealed class InvokeInfo
	{
		public ControllerDescription Controller;
		public ActionDescription Action;
		public object Instance;

		public OutputCacheAttribute GetOutputCacheSetting()
		{
			if( this.Action != null && this.Action.OutputCache != null )
				return this.Action.OutputCache;
			if( this.Controller != null && this.Controller.OutputCache != null )
				return this.Controller.OutputCache;			
			return null;
		}
		public SessionMode GetSessionMode()
		{
			if( this.Action != null && this.Action.SessionMode != null )
				return this.Action.SessionMode.SessionMode;
			if( this.Controller != null && this.Controller.SessionMode != null )
				return this.Controller.SessionMode.SessionMode;			
			return SessionMode.NotSupport;
		}
		public AuthorizeAttribute GetAuthorize()
		{
			if( this.Action != null && this.Action.Authorize != null )
				return this.Action.Authorize;
			if( this.Controller != null && this.Controller.Authorize != null )
				return this.Controller.Authorize;
			return null;
		}
	}

	internal sealed class ModelDescripton
	{
		public DataMember[] Fields;
	}
	
}
