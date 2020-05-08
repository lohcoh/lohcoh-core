using System;
using System.Linq;

namespace LowKode.Core.Metadata
{
    public static class MetaServiceExtensions
    {
        public static ITypeMetadata ForType(this ILowKodeMetaService lowkode, Type modelType)
        {
            return lowkode.Find<ITypeMetadata>().First(t => t.RuntimeType == modelType);
        }
        public static ITypeMetadata<TModel> ForType<TModel>(this ILowKodeMetaService lowkode)
        {
            return lowkode.Find<ITypeMetadata<TModel>>().First();
        }

    }
}
