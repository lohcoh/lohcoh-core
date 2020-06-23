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
        /// <summary>
        /// The ILosRoot that contains the Context and Metadata documents.
        /// todo: Remove.  Not sure its necessary to expose this.
        /// </summary>
        //ILosRoot LowkoderRoot { get; }

        /// <summary>
        /// Context document root for this site.
        /// </summary>
        LowkoderContext Context { get; }

        /// <summary>
        /// Metadata document root for this site.
        /// </summary>
        LowkoderMetadata Metadata { get; }

        /// <summary>
        /// Creates a new site and renders the given fragment within the context of the new site
        /// </summary>
        RenderFragment RenderWithSite(RenderFragment content, Action<IComponentSite> siteInitializer);
    }
}
