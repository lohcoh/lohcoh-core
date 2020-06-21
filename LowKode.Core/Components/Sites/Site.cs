using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Linq;

namespace LowKode.Core.Components
{
    public class Site : ComponentBase
    {
        protected IComponentSite site;

        public Site(IComponentSite site)
        {
            this.site = site;
        }

        protected LowkoderContext Context { get => site.Context; }
        protected LowkoderMetadata Metadata { get => site.Metadata; }

        SiteSpecification componentSpecification;
        protected override void OnInitialized()
        {
            // This component's only job is create the component used to render this site.         
            var siteType = this.GetType();  // Will be the type of a 'site' component, like <Display/> or <Input/>
            componentSpecification = Context.ComponentSiteSpecification;
            componentSpecification.SiteType = siteType;

            componentSpecification.ComponentType = Metadata.ComponentTypes.Where(t => t.SiteType == siteType).FirstOrDefault().ComponentType;
            //componentFragment = new ComponentSiteFragment(Context);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, componentSpecification.ComponentType);
            builder.AddAttribute(1, "Site", site);
            builder.CloseComponent();
        }
    }
}
