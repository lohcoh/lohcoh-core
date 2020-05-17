using System;

namespace LowKode.Core.Common
{
    public interface IDependencyObject
    {
        bool IsSealed { get; }
        DependencyObjectType DependencyObjectType { get; }

        void ClearValue(DependencyProperty dp);
        void ClearValue(DependencyPropertyKey key);
        void CoerceValue(DependencyProperty dp);
        bool Equals(object obj);
        int GetHashCode();

        LocalValueEnumerator GetLocalValueEnumerator();
        object GetValue(DependencyProperty dp);
        void InvalidateProperty(DependencyProperty dp);
        void OnPropertyChanged(DependencyPropertyChangedEventArgs e);
        object ReadLocalValue(DependencyProperty dp);

        void SetValue(DependencyProperty dp, object value);
        void SetValue(DependencyPropertyKey key, object value);
        bool ShouldSerializeProperty(DependencyProperty dp);
    }
}