using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class PropertyDescriptor 
    {
        public PropertyDescriptor(PropertyInfo propertyInfo)
        {
            this.CanRead = propertyInfo.CanRead;
            this.CanWrite = propertyInfo.CanWrite;
            this.Name = propertyInfo.Name;
            this.SystemType = propertyInfo.PropertyType;
            this.GetMethod = (instance) => propertyInfo.GetMethod.Invoke(instance,null);
            this.SetMethod = (instance, value) => propertyInfo.SetMethod.Invoke(instance, new object[] { value });
        }

        public virtual string Name { get; }
        public virtual Func<Object, Object> GetMethod { get; }
        public virtual bool CanWrite { get; }
        public virtual bool CanRead { get; }

        public virtual Type SystemType { get; }
        public virtual Action<Object, Object> SetMethod { get; }

    }
}
