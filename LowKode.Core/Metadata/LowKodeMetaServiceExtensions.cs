using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LowKode.Core.Metadata.Providers;

namespace LowKode.Core.Metadata
{
    public static class LowKodeMetaServiceExtensions
    {
        public static ITypeMetadata GetMetadataForType(this ILowKodeMetaService lowkode, Type modelType)
        {
            return lowkode.Find<ITypeMetadata>().First(t => t.RuntimeType == modelType);
        }
        public static ITypeMetadata<TModel> GetMetadataForType<TModel>(this ILowKodeMetaService lowkode)
        {
            return lowkode.Find<ITypeMetadata<TModel>>().First();
        }

        public static void ContributeMetadataForType<TEntity>(this ILowKodeConfigurationService lowkode)
        {
            new ReflectionMetaProvider().Invoke(lowkode, typeof(TEntity));
        }

    }
}
