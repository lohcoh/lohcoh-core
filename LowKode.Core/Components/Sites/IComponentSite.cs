using LowKode.Core.Common;
using LowKode.Core.Context;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// A scoped service through which a lowkode component accesses lowkode services and data.
    /// Injected into every lowkode component.
    /// </summary>
    public interface IComponentSite 
    {
        // todo: use dependency property
        IContext Context { get; }
        ILowKodeMetadata Metadata { get; }

        /// <summary>
        /// Creates a new site and renders the given fragment within the context of the new site
        /// </summary>
        RenderFragment RenderWithSite(RenderFragment content, Action<IComponentSite> siteInitializer);
    }
}
