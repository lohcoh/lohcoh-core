using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Configuration
{

    public class ComponentSite : IComponentSite
    {
        LowkoderService lowkoder;
        public ComponentSite(LowkoderService lowkoder, ILosRoot root)
        {
            this.lowkoder= lowkoder;
            var lowkoderRoot= root.Get<LowkoderRoot>();
            Context= lowkoderRoot.Context;
            Metadata= lowkoderRoot.Metadata;
        }

        public LowkoderContext Context { get; }

        public LowkoderMetadata Metadata { get; }

        public RenderFragment RenderWithSite(RenderFragment content, Action<IComponentSite> siteInitializer)
        {
            /*
             * A new site is created and the given content is wrapped in a component that holds the new site.
             * The wrapper component's BuildRenderTree method posts events to the lowkoder service to mark the 
             * start and end of rendering (would use before/after render lifecycle methods but Blazor has no before 
             * render method).  
             * The lowkoder service uses these notifications to inject branches of the site associated with the 
             * currently rendering component into children.
             */
            throw new NotImplementedException();
        }
    }
}
