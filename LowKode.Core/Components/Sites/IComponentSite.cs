using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// A service that provides access to context and metadata for rendering UI elements.
    /// </summary>
    public interface IComponentSite :IDisposable
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

    }
}
