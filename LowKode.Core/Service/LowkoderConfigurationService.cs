using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Metadata;
using LowKode.Core.Configuration;

namespace LowKode.Core.Configuration
{

    public class LowkoderConfigurationService : ILowkoderConfigurationService
    {


        public LowkoderConfigurationService(LowkoderService lowkoder)
        {
            this.Metadata = lowkoder.los.Master.Get<LowkoderRoot>().Metadata;
        }

        public LowkoderMetadata Metadata { get; private set; }

        public void Dispose()
        {
            // do nothing
        }
    }
}
