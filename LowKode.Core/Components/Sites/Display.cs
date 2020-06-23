using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Displays the model in a non-editable way.
    /// </summary>
    public class Display : ComponentBase
    {       
        [Inject]
        public IComponentSite Site { get; set; }

        public Display() { }

        protected override void OnInitialized()
        {          
            Site.Context.ComponentSiteSpecification.SiteType = typeof(Display);
        }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            SiteRenderer.BuildSiteRenderer(builder, Site);
        }

    }
}
