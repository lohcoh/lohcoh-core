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
    /// Interface to be implemented by components that generate content for a site
    /// </summary>
    public interface ISiteContentProvider 
    {
        /// <summary>
        /// Instead of having the site injected into a content provider component, like most other lowkode components, 
        /// a site passes it's context .....er, hold on.....
        /// </summary>
        [Parameter]
        public IComponentSite Site { get; set; }
    }
}
