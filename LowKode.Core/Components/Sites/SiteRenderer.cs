using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Linq;

namespace LowKode.Core.Components
{
    /// <summary>
    ///     This component renders a site specification.
    ///     The renderer will use the specification located at Site.Context.ComponentSiteSpecification.
    /// </summary>
    public class SiteRenderer : ComponentBase
    {
        public static void BuildSiteRenderer(RenderTreeBuilder builder, IComponentSite site)
        {
            builder.OpenComponent(0, typeof(SiteRenderer));
            builder.AddAttribute(1, "Site", site);
            builder.CloseComponent();
        }

        [Parameter]
        public IComponentSite Site { get; set; }

        public SiteRenderer() { }

        Type ComponentType;
        protected override void OnInitialized()
        {
            var specification= Site.Context.ComponentSiteSpecification;
            var siteType = specification.SiteType;

            var modelType= specification.ModelType;
            if (specification.ModelMember != null)
            {
                modelType = specification.ModelMember.TargetProperty.PropertyType;
            }

            var componentMapping = Site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == modelType).FirstOrDefault();
            if (componentMapping == null)
                componentMapping = Site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == null).FirstOrDefault();
            if (componentMapping == null)
                throw new Exception("No component mapping found for SiteType '"+siteType.FullName +"' and  ModelType '"+modelType.DisplayName+"'");

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
