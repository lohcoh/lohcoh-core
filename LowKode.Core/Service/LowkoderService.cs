using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Configuration
{
   
    public class LowkoderService : ILowkoderService
    {
        public LosObjectSystem los { get; } = new LosObjectSystem();

        Stack<ComponentSite> sites = new Stack<ComponentSite>();

        public LowkoderService()
        {
            los.Master.Put(new LowkoderRoot());
            sites.Push(new ComponentSite(this, los.Master));
        }

        /// <summary>
        /// Creates a new site which will be injected into a component, presuamably a component that's a 
        /// direct child of the component that owns the current site.
        /// </summary>
        public IComponentSite CreateTransientService(IServiceProvider serviceProvider)
           => sites.Peek().Branch();        

        /// <summary>
        /// Creates a new site and renders the given context within the context of the new site.
        /// The siteInitializer delegate can be used to add/modify context data in the newly created site.
        /// </summary>
        public RenderFragment RenderWithSite(RenderFragment content, Action<IComponentSite> siteInitializer)
        {
            /*
             * A new site is created and the given content is wrapped in a component that holds the new site.
             * The wrapper component's BuildRenderTree method posts events to the lowkoder service to mark the 
             * start and end of rendering (would use before/after render lifecycle methods but Blazor has no before 
             * render method).  
             * The lowkoder service uses these notifications to track the 'active' site and, when the CreateTransientService 
             * method is called, inject branches of the active site into children.
             */
            var childSite = sites.Peek().Branch();
            if (siteInitializer != null)
                siteInitializer(childSite);

            return builder =>
            {
                sites.Push(childSite);
                try
                {
                    builder.OpenComponent(0, typeof(SiteWrapper));
                    builder.AddAttribute(1, "Site", childSite);
                    builder.AddContent(2, content);
                    builder.CloseComponent();
                }
                finally
                {
                    sites.Pop();
                }
            };
        }

    }
}
