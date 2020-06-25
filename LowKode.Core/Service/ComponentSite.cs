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
        ILosRoot root;
        public ComponentSite(LowkoderService lowkoder, ILosRoot root)
        {
            this.lowkoder= lowkoder;
            this.root = root;
            var lowkoderRoot= root.Get<LowkoderRoot>();
            Context= lowkoderRoot.Context;
            Metadata= lowkoderRoot.Metadata;
        }

        public ComponentSite Branch() => new ComponentSite(lowkoder, root.Branch());

        public LowkoderContext Context { get; }

        public LowkoderMetadata Metadata { get; }

        public void Dispose()
        {
            root.Dispose();
        }
    }
}
