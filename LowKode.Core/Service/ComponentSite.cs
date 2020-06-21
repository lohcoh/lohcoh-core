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
        ILosObjectSystem los;
        ILosRoot root;
        LowkoderRoot lowkoderRoot;
        LowkoderContext context;
        LowkoderMetadata metadata;
        public ComponentSite(ILosObjectSystem los)
        {
            this.los= los;
            root= los.Open();
            lowkoderRoot= root.Get<LowkoderRoot>();
            context= lowkoderRoot.Context;
            metadata= lowkoderRoot.Metadata;
        }
        public ILosRoot LowkoderRoot => root;

        public LowkoderContext Context => context;

        public LowkoderMetadata Metadata => metadata;

        public RenderFragment RenderWithSite(RenderFragment content, Action<IComponentSite> siteInitializer)
        {
            throw new NotImplementedException();
        }
    }
}
