using System;

namespace LowKode.Core.Common
{
    /// <summary>
    /// A selector that denotes a path through a tree of DependencyObjects to a particular DependencyProperty.
    /// </summary>
    public class DependencyPath : IDependencyPath
    {
        protected IDependencyProperty property;
        public DependencyPath(IDependencyProperty property)
        {
            this.property= property;
        }
        public object Invoke(IDependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(property);
        }
    }
    public class DependencyPath<TValue> : DependencyPath
    {
        public DependencyPath(IDependencyProperty<TValue> property) : base(property)
        {
        }

        new TValue Invoke(IDependencyObject dependencyObject)
        {
            return (TValue)base.Invoke(dependencyObject);
        }
    }
}