using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;



namespace Lowkode.Client.Core
{

    public class MetadataProvider : IMetadataProvider
    {
        private Dictionary<Type, IModelMetadata> typeMetadata = new Dictionary<Type, IModelMetadata>();

        public MetadataProvider()
        {
        }

        /// <summary>
        /// Returns metadata associated with the TModel type.
        /// </summary>
        public IModelMetadata For(Type modelType)
        {
            IModelMetadata metadata = null;
            if (!typeMetadata.TryGetValue(modelType, out metadata))
            {
                metadata = new ModelMetadata(modelType);
                typeMetadata.Add(modelType, metadata);
            }
            return metadata;
        }

    }
}
