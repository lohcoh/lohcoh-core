using System;

namespace LowKode.Core.Common
{
	public class PropertyMetadata
	{
		private object defaultValue;
		private bool isSealed;
		private PropertyChangedCallback propertyChangedCallback;
		private CoerceValueCallback coerceValueCallback;

		protected bool IsSealed
		{
			get { return isSealed; }
		}

		public object DefaultValue
		{
			get { return defaultValue; }
			set
			{
				if (IsSealed)
					throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");
				if (value == DependencyProperty.UnsetValue)
					throw new ArgumentException("Cannot set property metadata's default value to 'Unset'");

				defaultValue = value;
			}
		}

		public PropertyChangedCallback PropertyChangedCallback
		{
			get { return propertyChangedCallback; }
			set
			{
				if (IsSealed)
					throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");
				propertyChangedCallback = value;
			}
		}

		public CoerceValueCallback CoerceValueCallback
		{
			get { return coerceValueCallback; }
			set
			{
				if (IsSealed)
					throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");
				coerceValueCallback = value;
			}
		}

		public PropertyMetadata()
			: this(null, null, null)
		{
		}

		public PropertyMetadata(object defaultValue)
			: this(defaultValue, null, null)
		{
		}

		public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
			: this(null, propertyChangedCallback, null)
		{
		}

		public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
			: this(defaultValue, propertyChangedCallback, null)
		{
		}

		public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
		{
			if (defaultValue == DependencyProperty.UnsetValue)
				throw new ArgumentException("Cannot initialize property metadata's default value to 'Unset'");

			this.defaultValue = defaultValue;
			this.propertyChangedCallback = propertyChangedCallback;
			this.coerceValueCallback = coerceValueCallback;
		}

		protected virtual void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
		{
			if (defaultValue == null)
				defaultValue = baseMetadata.defaultValue;
			if (propertyChangedCallback == null)
				propertyChangedCallback = baseMetadata.propertyChangedCallback;
			if (coerceValueCallback == null)
				coerceValueCallback = baseMetadata.coerceValueCallback;
		}

		protected virtual void OnApply(DependencyProperty dp, Type targetType)
		{
		}

		internal void DoMerge(PropertyMetadata baseMetadata, DependencyProperty dp, Type targetType)
		{
			Merge(baseMetadata, dp);
			OnApply(dp, targetType);
			isSealed = true;
		}
	}
}