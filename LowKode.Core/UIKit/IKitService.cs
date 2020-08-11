using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Provides access to a collection of components (a kit) that can be plugged into Lowkoder site components
    /// </summary>
    public interface IKitService 
    {
        /// <summary>
        /// Return the Type of a component that should be used to render the specified UI site.
        /// </summary>
        Type FindKitType(SiteSpecification siteSpecification);
    }
}
