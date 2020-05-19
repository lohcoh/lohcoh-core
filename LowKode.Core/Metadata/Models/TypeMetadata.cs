using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class TypeMetadata : CommonMetadata, ITypeMetadata
    {

        public TypeMetadata(Type t)
        {
            SystemType = t;

            foreach (var propertInfo in t.GetProperties())
            {
                var propertyMetadata = new PropertyMetadata(propertInfo);
                Properties.Add(propertyMetadata);
            }

        }
        public Type SystemType { get; set; }

        public ICollection<IPropertyMetadata> Properties { get; } = new List<IPropertyMetadata>();
      
    }

    public class TypeMetadata<TType> : TypeMetadata, ITypeMetadata<TType>
    {
        public TypeMetadata() : base(typeof(TType)) 
        {
        }
    }
}
