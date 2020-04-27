using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    public interface ITypeMetadata : ICommonMetadata
    {
        
        Type RuntimeType { get; }
        ICollection<IPropertyMetadata> Properties { get; } 
    }

    public interface ITypeMetadata<TType> : ITypeMetadata
    {
        
    }
}
