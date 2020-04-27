using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LowKode.Core.Metadata
{
    public static class LowKodeMetaServiceExtensions
    {
        public static TypeMetadata GetMetadataForType(this ILowKodeMetaService lowkode, Type modelType)
        {
            return lowkode.Find<TypeMetadata>().First(t => t.RuntimeType == modelType);
        }
        public static TypeMetadata<TModel> GetMetadataForType<TModel>(this ILowKodeMetaService lowkode)
        {
            return lowkode.Find<TypeMetadata<TModel>>().First();
        }

    }
}
