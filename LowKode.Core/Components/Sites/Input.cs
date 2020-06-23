using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Creates a view suitable for editing the Model object.
    /// </summary>
    public class Input : ComponentBase
    {

        [Inject]
        public IComponentSite Site { get; set; }

        public Input() { }

        protected override void OnInitialized()
        {
            /*
             * Basically all this component does is set SiteType to the type of this site.
             * The logic necessary to render a complete site specification is encapsulated in SiteRenderer
             */
            Site.Context.ComponentSiteSpecification.SiteType = typeof(Input);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            SiteRenderer.BuildSiteRenderer(builder, Site);
        }

    }
}
