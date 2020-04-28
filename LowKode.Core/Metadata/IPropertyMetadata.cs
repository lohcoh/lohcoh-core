using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
{
    public interface IPropertyMetadata : ICommonMetadata
    {
        PropertyInfo PropertyInfo { get; }
    }
}
