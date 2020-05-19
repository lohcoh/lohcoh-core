using System;

namespace LowKode.Core.Common
{
	public struct LocalValueEntry
	{
		private IDependencyProperty property;
		private object value;

		internal LocalValueEntry(IDependencyProperty property, object value)
		{
			this.property = property;
			this.value = value;
		}

		public IDependencyProperty Property
		{
			get { return property; }
		}

		public object Value
		{
			get { return value; }
		}

		public static bool operator !=(LocalValueEntry obj1, LocalValueEntry obj2)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(LocalValueEntry obj1, LocalValueEntry obj2)
		{
			throw new NotImplementedException();
		}

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}