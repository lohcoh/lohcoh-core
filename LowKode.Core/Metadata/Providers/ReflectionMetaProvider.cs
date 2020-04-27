using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata.Providers
{
    /// <summary>
    /// Gathers all the metadata for a type and it's properties available from the .Net Reflection API.
    /// </summary>
    public class ReflectionMetaProvider
    {
        public void Invoke(ILowKodeConfigurationService lowkode, Type entityType)
        {
            var typeMetadata = new TypeMetadata(entityType);
            lowkode.Repository.Add

            foreach (var propertInfo in entityType.GetProperties())
            {
                var propertyMetadata = new PropertyMetadata(propertInfo);
                typeMetadata.Properties.Add(propertyMetadata);
            }

        }
    }
}
