using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyMVC
{
	internal abstract class DataMember
	{
		public abstract object GetValue(object obj);
		public abstract void SetValue(object obj, object val);
		public abstract Type Type { get; }
		public abstract string Name { get; }
	}

	internal sealed class PropertyMember : DataMember
	{
		private PropertyInfo _pi;
		public PropertyMember(PropertyInfo pi)
		{
			if( pi == null )
				throw new ArgumentNullException("pi");
			_pi = pi;
		}

		public override object GetValue(object obj)
		{
			return _pi.GetValue(obj, null);
		}

		public override void SetValue(object obj, object val)
		{
			_pi.SetValue(obj, val, null);
		}

		public override Type Type
		{
			get { return _pi.PropertyType; }
		}

		public override string Name
		{
			get { return _pi.Name; }
		}
	}


	internal sealed class FieldMember : DataMember
	{
		private FieldInfo _field;
		public FieldMember(FieldInfo fi)
		{
			if( fi == null )
				throw new ArgumentNullException("fi");
			_field = fi;
		}

		public override object GetValue(object obj)
		{
			return _field.GetValue(obj);
		}

		public override void SetValue(object obj, object val)
		{
			_field.SetValue(obj, val);
		}

		public override Type Type
		{
			get { return _field.FieldType; }
		}

		public override string Name
		{
			get { return _field.Name; }
		}
	}



}
