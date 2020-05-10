using LowKode.Core.Context;
using LowKode.Core.Metadata;

namespace LowKode.Core.Components
{
    public static class ContentExtensions
    {
      
        public static ILowKodeContext WithModelType(this ILowKodeContext ctx, ITypeMetadata modelType)
        {
            var scope= ctx.CreateScope();

            var siteSpecification= scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());
            siteSpecification.ModelType= modelType;

            return scope;
        }
        public static ILowKodeContext WithModel(this ILowKodeContext ctx, object model)
        {
            var scope = ctx.CreateScope();

            var siteSpecification = scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());
            siteSpecification.Model = model;

            return scope;
        }

    }
}
