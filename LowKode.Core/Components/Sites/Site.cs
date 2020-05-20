using LowKode.Core.Context;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    public class Site : ComponentBase
    {
        IComponentSite site;

        public Site(IComponentSite site)
        {
            this.site = site;
        }

        protected IContext Context { get => site.Context; }
        protected ILowKodeMetadata Metadata { get => site.Metadata; }

        IComponentSiteSpecification componentSpecification;
        protected override void OnInitialized()
        {
            // this component's only job is to set the value of the Context.ComponentSiteSpecification.ComponentType 
            // property before passing the context to ComponentSiteFragment to finish the real work of rendering the component.
            //
            // By the time this code is executed a new context has been created for this component.
            // Changing the componentSpecification.ComponentType property only alters the value of componentSpecification.ComponentType 
            // in this component's context.
            var type = this.GetType();
            componentSpecification = Context.ComponentSiteSpecification;
            componentSpecification.ComponentType = Metadata.ForSystemType(typeof(DisplayName));
            //componentFragment = new ComponentSiteFragment(Context);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, componentSpecification.ComponentType.SystemType);
            builder.AddAttribute(1, "Site", site);
            builder.CloseComponent();
        }
    }
}
