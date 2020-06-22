using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Linq;

namespace LowKode.Core.Components
{
    public class SiteComponent : ComponentBase
    {
        [Inject]
        [Parameter]
        public IComponentSite Site { get; set; }

        public SiteComponent() { }

        protected LowkoderContext Context { get => Site.Context; }
        protected LowkoderMetadata Metadata { get => Site.Metadata; }

        Type ComponentType;
        protected override void OnInitialized()
        {
            // This component's only job is create the component used to render this site.         
            var siteType = this.GetType();  // Will be the type of a 'site' component, like <Display/> or <Input/>
            var componentSpecification = Context.ComponentSiteSpecification;
            componentSpecification.SiteType = siteType;
            var modelType= componentSpecification.ModelType;
            var componentMapping = Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == modelType).FirstOrDefault();
            if (componentMapping == null)
                componentMapping = Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == null).FirstOrDefault();
            if (componentMapping == null)
                throw new Exception("No component mapping found for SiteType '"+siteType.FullName +"' and  ModelType '"+modelType.Name+"'");

            ComponentType = componentMapping.ComponentType;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, ComponentType);
            builder.AddAttribute(1, "Site", Site);
            builder.CloseComponent();
        }
    }
}
