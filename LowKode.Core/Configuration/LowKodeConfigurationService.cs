using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Metadata;
using LowKode.Core.Configuration;

namespace LowKode.Core.Metadata
{
   
    public class LowKodeConfigurationService : ILowKodeConfigurationService
    {

        ILowKodeMetaRepository repository;
        public LowKodeConfigurationService()
        {
        }

        public ILowKodeMetaRepository Repository => repository;
    }
}
