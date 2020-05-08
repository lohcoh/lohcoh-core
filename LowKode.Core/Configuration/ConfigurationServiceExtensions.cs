using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LowKode.Core.Metadata;
using LowKode.Core.Configuration;

namespace LowKode.Core.Configuration
{
    public static class ConfigurationServiceExtensions
    {
      
        public static void ContributeMetadataForType<TEntity>(this ILowKodeConfigurationService lowkode)
        {
            new ReflectionMetaProvider().Invoke(lowkode, typeof(TEntity));
        }

    }
}
