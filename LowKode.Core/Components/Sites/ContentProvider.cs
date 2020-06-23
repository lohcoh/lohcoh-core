using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Linq;

namespace LowKode.Core.Components
{
    /// <summary>
    ///     Base class for components that serve as replacements for 'site' components.
    ///     ContentProviders must subclass the site component that they replace.
    ///     
    ///     Unlike 
    /// </summary>
    public class ContentProvider : ComponentBase
    {
        [Parameter]
        public IComponentSite Site { get; set; }

        public ContentProvider() { }

        Type ComponentType;
        protected override void OnInitialized()
        {
            var siteType = this.GetType();  // Will be the type of a 'site' component, like <Display/> or <Input/>

            var SiteSpecification = Site.Context.ComponentSiteSpecification;
            SiteSpecification.SiteType = siteType;

            var modelType= SiteSpecification.ModelType;
            if (SiteSpecification.ModelMember != null)
            {
                modelType = SiteSpecification.ModelMember.TargetProperty.PropertyType;
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
