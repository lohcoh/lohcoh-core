using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{

    /// <summary>
    /// Displays a name that identifies the associated model.
    /// </summary>
    public class DisplayName : ComponentBase
    {
        [Inject]
        public IComponentSite Site { get; set; }

        public DisplayName() { }

        protected override void OnInitialized()
        {
            /*
             * Basically all this component does is set SiteType to the type of this site.
             * The logic necessary to render a complete site specification is encapsulated in SiteRenderer
             */
            Site.Context.ComponentSiteSpecification.SiteType = typeof(DisplayName);
        }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            SiteRenderer.BuildSiteRenderer(builder, Site);
        }

    }
}
