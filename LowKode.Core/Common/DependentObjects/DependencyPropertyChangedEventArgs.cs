using System;

namespace LowKode.Core.Common
{
    public class DependencyPropertyChangedEventArgs
    {

		public DependencyPropertyChangedEventArgs(DependencyProperty property, object oldValue, object newValue)
		{
			this.Property = property;
			this.OldValue = oldValue;
			this.NewValue = newValue;
		}

		public object NewValue
		{
			get; private set;
		}

		public object OldValue
		{
			get; private set;
		}

		public DependencyProperty Property
		{
			get; private set;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is DependencyPropertyChangedEventArgs))
				return false;

			return Equals((DependencyPropertyChangedEventArgs)obj);
		}

		public bool Equals(DependencyPropertyChangedEventArgs args)
		{
			return (Property == args.Property &&
				NewValue == args.NewValue &&
				OldValue == args.OldValue);
		}

		public static bool operator !=(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}