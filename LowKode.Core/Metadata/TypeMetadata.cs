using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class TypeMetadata : CommonMetadata
    {
        public TypeMetadata(Type runtimeType)
        {
            RuntimeType= runtimeType;
        }

        public Type RuntimeType { get; private set; }
        public ICollection<PropertyMetadata> Properties { get; } = new List<PropertyMetadata>();
    }

    public class TypeMetadata<TType> : TypeMetadata
    {
        public TypeMetadata() : base(typeof(TType))
        {
        }
    }
}
