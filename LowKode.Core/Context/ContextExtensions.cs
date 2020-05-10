using LowKode.Core.Context;
using LowKode.Core.Metadata;

namespace LowKode.Core.Components
{
    public static class ContentExtensions
    {
      
        public static ILowKodeContext WithModelType(this ILowKodeContext ctx, ITypeMetadata modelType)
        {
            var scope= ctx.CreateScope();

            var siteSpecification= scope.First<ComponentSiteSpecification>();
            if (siteSpecification == null) { 
                siteSpecification= new ComponentSiteSpecification();
                scope.Add<IComponentSiteSpecification>(siteSpecification);
            }
            siteSpecification.ModelType= modelType;

            return scope;
        }

    }
}
