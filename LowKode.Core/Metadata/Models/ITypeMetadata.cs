using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    // todoL implement dependency properties
    public interface ITypeMetadata : ICommonMetadata
    {
        Type SystemType { get; }
        ICollection<IPropertyMetadata> Properties { get; } 
    }

    public interface ITypeMetadata<TType> : ITypeMetadata
    {
        
    }
}
