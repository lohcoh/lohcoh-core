using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Configuration;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// Gathers all the metadata for a type and it's properties available from the .Net Reflection API.
    /// </summary>
    public class ReflectionMetaProvider
    {
        public void Invoke(ILowKodeConfigurationService config, Type entityType)
        {
            var typeMetadata = new TypeDescriptor(entityType);
            config.Metadata.TypeDescriptors.Add(typeMetadata);
        }
    }
}
