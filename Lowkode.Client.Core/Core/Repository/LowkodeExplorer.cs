using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;



namespace Lowkode.Client.Core
{

    public class LowkodeExplorer : ILowkodeExplorer
    {
        private Dictionary<Type, IModelMetadata> typeMetadata = new Dictionary<Type, IModelMetadata>();

        public LowkodeExplorer()
        {
        }

        public IModelMetadata MetadataForType<TModel>()
        {
            IModelMetadata metadata = null;
            if (!typeMetadata.TryGetValue(typeof(TModel), out metadata))
            {
                var type = typeof(TModel);
                metadata = new ModelMetadata(type);
                typeMetadata.Add(type, metadata);
            }
            return metadata;
        }

    }
}
