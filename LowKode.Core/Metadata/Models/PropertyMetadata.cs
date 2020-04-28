using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class PropertyMetadata : CommonMetadata, IPropertyMetadata
    {
        public PropertyMetadata(PropertyInfo propertyInfo)
        {
            this.PropertyInfo= propertyInfo;
        }

        public PropertyInfo PropertyInfo { get; private set; }
    }
}
