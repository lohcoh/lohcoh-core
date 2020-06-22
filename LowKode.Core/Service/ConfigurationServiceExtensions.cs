using LowKode.Core.Components;
using LowKode.Core.Metadata;
using System;

namespace LowKode.Core.Configuration
{
    public static class ConfigurationServiceExtensions
    {
      
        public static void ContributeMetadataForType<TEntity>(this ILowkoderConfigurationService config)
        {
            var typeMetadata = TypeDescriptor.ForSystemType(typeof(TEntity));
            config.Metadata.TypeDescriptors.Add(typeMetadata);
        }

        public static void UseDefaultUIKit(this ILowkoderConfigurationService config)
        {
            // todo:unfinished
            config.Metadata.ComponentTypes.Add(new ComponentTypeMapping()
            {
                ComponentType = typeof(LowkoderInputText),
                ModelType = TypeDescriptor.ForSystemType(typeof(String)),
                SiteType = typeof(Input)
            });

            config.Metadata.ComponentTypes.Add(new ComponentTypeMapping()
            {
                ComponentType = typeof(LowkoderDisplayName),
                SiteType = typeof(DisplayName)
            });

            config.Metadata.ComponentTypes.Add(new ComponentTypeMapping()
            {
                ComponentType = typeof(LowkoderInputDate),
                ModelType = TypeDescriptor.ForSystemType(typeof(DateTime)),
                SiteType = typeof(Input)
            });
        }

    }
}
