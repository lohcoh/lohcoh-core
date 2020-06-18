﻿using System;
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
        public void Invoke(ILowKodeConfigurationService lowkode, Type entityType)
        {
            var typeMetadata = new TypeDescriptor(entityType);
            typeMetadata.DisplayName= entityType.Name;

            foreach (var propertInfo in entityType.GetProperties())
            {
                var propertyMetadata = new PropertyDescriptor(propertInfo);
                typeMetadata.Properties.Add(propertyMetadata);
            }

            lowkode.Repository.AddMetadataRoot<ITypeMetadata>(typeMetadata);
        }
    }
}
