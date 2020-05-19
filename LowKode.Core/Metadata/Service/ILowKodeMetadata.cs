using LowKode.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// ILowKodeMetadata is meant to be a bare-bones but extensible metadata API.
    /// </summary>
    public interface ILowKodeMetadata : IDependencyObject
    {
        IEnumerable<IDependencyObjectType> DependencyObjectTypes { get; set; }
    }
}
