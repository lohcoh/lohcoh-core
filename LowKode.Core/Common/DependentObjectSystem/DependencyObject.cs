using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LowKode.Core.Common
{
	
		public class DependencyObject : IDependencyObject
		{
			internal static Dictionary<Type, Dictionary<string, IDependencyProperty>> propertyDeclarations = new Dictionary<Type, Dictionary<string, IDependencyProperty>>();
			internal Dictionary<IDependencyProperty, object> properties = new Dictionary<IDependencyProperty, object>();

			public bool IsSealed
			{
				get { return false; }
			}

			public DependencyObjectType DependencyObjectType
			{
				get { return DependencyObjectType.FromSystemType(GetType()); }
			}

			public void ClearValue(IDependencyProperty dp)
			{
				if (IsSealed)
					throw new InvalidOperationException("Cannot manipulate property values on a sealed DependencyObject");

				properties[dp] = null;
			}

			public void ClearValue(DependencyPropertyKey key)
			{
				ClearValue(key.DependencyProperty);
			}

			public void CoerceValue(IDependencyProperty dp)
			{
				PropertyMetadata pm = dp.GetMetadata(this);
				if (pm.CoerceValueCallback != null)
					pm.CoerceValueCallback(this, GetValue(dp));
			}

			public sealed override bool Equals(object obj)
			{
				throw new NotImplementedException("Equals");
			}

			public sealed override int GetHashCode()
			{
				throw new NotImplementedException("GetHashCode");
			}


			public LocalValueEnumerator GetLocalValueEnumerator()
			{
				return new LocalValueEnumerator(properties);
			}

			public object GetValue(IDependencyProperty dp)
			{
				object val = properties.ContainsKey(dp) ? properties[dp] : null;
				return val == null ? dp.DefaultMetadata.DefaultValue : val;
			}

			public void InvalidateProperty(IDependencyProperty dp)
			{
				throw new NotImplementedException("InvalidateProperty(DependencyProperty dp)");
			}

		public virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
			{
				PropertyMetadata pm = e.Property.GetMetadata(this);
				if (pm.PropertyChangedCallback != null)
					pm.PropertyChangedCallback(this, e);
			}

			public object ReadLocalValue(IDependencyProperty dp)
			{
				object val = properties.ContainsKey(dp) ? properties[dp] : null;
				return val == null ? DependencyProperty.UnsetValue : val;
			}

			public void SetValue(IDependencyProperty dp, object value)
			{
				if (IsSealed)
					throw new InvalidOperationException("Cannot manipulate property values on a sealed DependencyObject");

				if (!dp.IsValidType(value))
					throw new ArgumentException("value not of the correct type for this DependencyProperty");

				ValidateValueCallback validate = dp.ValidateValueCallback;
				if (validate != null && !validate(value))
					throw new Exception("Value does not validate");
				else
					properties[dp] = value;
			}

			public void SetValue(DependencyPropertyKey key, object value)
			{
				SetValue(key.DependencyProperty, value);
			}

		public virtual bool ShouldSerializeProperty(IDependencyProperty dp)
			{
				throw new NotImplementedException();
			}

		public static void register(Type t, IDependencyProperty dp)
			{
				if (!propertyDeclarations.ContainsKey(t))
					propertyDeclarations[t] = new Dictionary<string, IDependencyProperty>();
				var typeDeclarations = propertyDeclarations[t];
				if (!typeDeclarations.ContainsKey(dp.Name))
					typeDeclarations[dp.Name] = dp;
				else
					throw new ArgumentException("A property named " + dp.Name + " already exists on " + t.Name);
			}

		public TProperty GetValue<TProperty>(IDependencyProperty<TProperty> dp)
		{
			// todo:
			throw new NotImplementedException();
		}

		public void SetValue<TProperty>(IDependencyProperty<TProperty> dp, TProperty value)
		{
			// todo:
			throw new NotImplementedException();
		}
	}
	
}
