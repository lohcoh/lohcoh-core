using System;

namespace LowKode.Core.Common
{
    public interface IDependencyObjectType
    {
        DependencyObjectType BaseType { get; }
        int Id { get; }
        string Name { get; }
        Type SystemType { get; }

        int GetHashCode();
        bool IsInstanceOfType(DependencyObject dependencyObject);
        bool IsSubclassOf(DependencyObjectType dependencyObjectType);
    }
}