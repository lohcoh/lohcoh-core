using System;

namespace LowKode.Core.Common
{
    public interface IDependencyProperty
    {
        PropertyMetadata DefaultMetadata { get; }
        int GlobalIndex { get; }
        string Name { get; }
        Type OwnerType { get; }
        Type PropertyType { get; }
        bool ReadOnly { get; }
        ValidateValueCallback ValidateValueCallback { get; }

        DependencyProperty AddOwner(Type ownerType);
        DependencyProperty AddOwner(Type ownerType, PropertyMetadata typeMetadata);
        int GetHashCode();
        PropertyMetadata GetMetadata(DependencyObject dependencyObject);
        PropertyMetadata GetMetadata(DependencyObjectType dependencyObjectType);
        PropertyMetadata GetMetadata(Type forType);
        bool IsValidType(object value);
        bool IsValidValue(object value);
        void OverrideMetadata(Type forType, PropertyMetadata typeMetadata);
        void OverrideMetadata(Type forType, PropertyMetadata typeMetadata, DependencyPropertyKey key);
        string ToString();
    }
}