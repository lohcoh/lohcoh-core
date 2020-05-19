using System;

namespace LowKode.Core.Common
{
	public sealed class DependencyPropertyKey
	{
		internal DependencyPropertyKey(DependencyProperty dependencyProperty)
		{
			this.dependencyProperty = dependencyProperty;
		}

		private DependencyProperty dependencyProperty;
		public DependencyProperty DependencyProperty
		{
			get { return dependencyProperty; }
		}

		public void OverrideMetadata(Type forType, PropertyMetadata typeMetadata)
		{
			dependencyProperty.OverrideMetadata(forType, typeMetadata, this);
		}
	}
}