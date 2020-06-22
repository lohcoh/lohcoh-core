using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;

namespace LowKode.Core.Configuration
{
   
    public class LowkoderService : ILowkoderService
    {
        public LosObjectSystem los { get; } = new LosObjectSystem();

        public LowkoderService()
        {
            los.Master.Put(
                new LowkoderRoot()
                {
                    Metadata= new LowkoderMetadata(),
                    Context= new LowkoderContext()
                    {
                        ComponentSiteSpecification= new SiteSpecification()
                    }
                });
        }
        public IComponentSite CreateComponentSite(IServiceProvider serviceProvider)
        {
            return new ComponentSite(los);
        }
    }
}
