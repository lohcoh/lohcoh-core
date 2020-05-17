using System;
using System.Collections;
using System.Collections.Generic;

namespace LowKode.Core.Common
{
	public struct LocalValueEnumerator : IEnumerator
	{
		private IDictionaryEnumerator propertyEnumerator;
		private Dictionary<DependencyProperty, object> properties;

		private int count;

		internal LocalValueEnumerator(Dictionary<DependencyProperty, object> properties)
		{
			this.count = properties.Count;
			this.properties = properties;
			this.propertyEnumerator = properties.GetEnumerator();
		}

		public int Count
		{
			get { return count; }
		}

		public LocalValueEntry Current
		{
			get
			{
				return new LocalValueEntry((DependencyProperty)propertyEnumerator.Key,
				  propertyEnumerator.Value);
			}
		}
		object IEnumerator.Current
		{
			get { return this.Current; }
		}

		public bool MoveNext()
		{
			return propertyEnumerator.MoveNext();
		}
		public void Reset()
		{
			propertyEnumerator.Reset();
		}

		public static bool operator !=(LocalValueEnumerator obj1, LocalValueEnumerator obj2)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(LocalValueEnumerator obj1, LocalValueEnumerator obj2)
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