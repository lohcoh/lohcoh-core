using System;

namespace LowKode.Core.Common
{
    /// <summary>
    /// A selector that denotes a path through a tree of DependencyObjects to a particular DependencyProperty.
    /// </summary>
    public interface IDependencyPath
    {
        object Invoke(IDependencyObject dependencyObject);
    }
}