using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Metadata;

namespace LowKode.Core.Metadata.Service
{
   
    public class LowKodeConfigurationService : ILowKodeConfigurationService
    {

        ILowKodeMetaRepository repository = new LowKodeMetaService();
        public LowKodeConfigurationService()
        {
        }

        public ILowKodeMetaRepository Repository => repository;
    }
}
