using System;

namespace LowKode.Core.Common
{
    public interface IDependencyObject
    {
        bool IsSealed { get; }
        DependencyObjectType DependencyObjectType { get; }

        void ClearValue(IDependencyProperty dp);
        void ClearValue(DependencyPropertyKey key);
        void CoerceValue(IDependencyProperty dp);
        bool Equals(object obj);
        int GetHashCode();

        LocalValueEnumerator GetLocalValueEnumerator();
        object GetValue(IDependencyProperty dp);
        TProperty GetValue<TProperty>(IDependencyProperty<TProperty> dp);
        void InvalidateProperty(IDependencyProperty dp);
        void OnPropertyChanged(DependencyPropertyChangedEventArgs e);
        object ReadLocalValue(IDependencyProperty dp);

        void SetValue(IDependencyProperty dp, object value);
        void SetValue<TProperty>(IDependencyProperty<TProperty> dp, TProperty value);
        void SetValue(DependencyPropertyKey key, object value);
        bool ShouldSerializeProperty(IDependencyProperty dp);
    }
}