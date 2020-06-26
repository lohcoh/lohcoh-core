using LowKode.Core.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Base class for site components.
    /// </summary>
    public class SiteBase<TSite> : ComponentBase
    {
        [Inject] public ILowkoderService lowkoder { get; set; }

        Type siteType;
        IComponentSite site;
        public SiteBase() 
        {
            this.siteType = typeof(TSite);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            site = lowkoder.CreateSite();
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            using (lowkoder.RenderWithSite(site))
            {
                var specification = site.Context.ComponentSiteSpecification;
                specification.SiteType = siteType;

                var modelType = specification.ModelType;
                if (specification.ModelMember != null)
                {
                    modelType = specification.ModelMember.TargetProperty.PropertyType;
                }

                var componentMapping = site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == modelType).FirstOrDefault();
                if (componentMapping == null)
                    componentMapping = site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == null).FirstOrDefault();
                if (componentMapping == null)
                    throw new Exception("No component mapping found for SiteType '" + siteType.FullName + "' and  ModelType '" + modelType.DisplayName + "'");

                var componentType = componentMapping.ComponentType;

                builder.OpenComponent(0, componentType);
                builder.CloseComponent();
            }

        }

    }
}
