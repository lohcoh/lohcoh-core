using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LowKode.Core.Metadata;
using LowKode.Core.Configuration;
using LowKode.Core.Components;

namespace LowKode.Core.Configuration
{
    public static class ConfigurationServiceExtensions
    {
      
        public static void ContributeMetadataForType<TEntity>(this ILowkoderConfigurationService config)
        {
            var typeMetadata = new TypeDescriptor(typeof(TEntity));
            config.Metadata.TypeDescriptors.Add(typeMetadata);
        }

        public static void UseDefaultUIKit(this ILowkoderConfigurationService config)
        {
            // todo:unfinished
            config.Metadata.ComponentTypes.Add(new ComponentTypeMapping()
            {
                ComponentType = typeof(Input),
                ModelType = new TypeDescriptor(typeof(String)),
                SiteType = typeof(Input)
            });
        }

    }
}
