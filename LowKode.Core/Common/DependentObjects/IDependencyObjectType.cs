using System;
using System.Collections.Generic;

namespace LowKode.Core.Common
{
    //todo: implement dependency properties
    public interface IDependencyObjectType : IDependencyObject
    {
        DependencyObjectType BaseType { get; }
        int Id { get; }
        string Name { get; }
        Type SystemType { get; }

        bool IsInstanceOfType(DependencyObject dependencyObject);
        bool IsSubclassOf(DependencyObjectType dependencyObjectType);

        IReadOnlyCollection<IDependencyProperty> Properties { get; set; }
    }
}