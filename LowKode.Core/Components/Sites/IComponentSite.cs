using LowKode.Core.Common;
using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// A scoped service through which a lowkode component accessed lowkode services and data.
    /// Injected into every lowkode component.
    /// </summary>
    public interface IComponentSite : IDependencyObject
    {
        // todo: use dependency property
        IContext Context { get; }
        ILowKodeMetadata Metadata { get; }
    }
}
