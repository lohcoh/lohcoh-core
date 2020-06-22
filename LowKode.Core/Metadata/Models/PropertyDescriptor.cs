using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class PropertyDescriptor 
    {
        private PropertyInfo propertyInfo;
        public PropertyDescriptor(PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
        }

        public virtual string Name { get => propertyInfo.Name; }
        public virtual bool CanWrite { get=> propertyInfo.CanWrite; }
        public virtual bool CanRead { get=> propertyInfo.CanRead; }

        public virtual TypeDescriptor PropertyType { get => TypeDescriptor.ForSystemType(propertyInfo.PropertyType);  }
        public virtual Type SystemType { get=> propertyInfo.PropertyType; }

        public virtual Func<Object, Object> GetMethod { get => (instance) => propertyInfo.GetMethod.Invoke(instance, null); }
        public virtual Action<Object, Object> SetMethod { get=> (instance, value) => propertyInfo.SetMethod.Invoke(instance, new object[] { value }); }

    }
}
