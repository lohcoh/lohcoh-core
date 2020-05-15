using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    public static class ContentExtensions
    {
      
        public static ILowKodeContext WithModelType(this ILowKodeContext ctx, Type modelType)
        {
            var scope= ctx.CreateScope();

            var siteSpecification= scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());
            siteSpecification.ModelType= modelType;

            return scope;
        }

        public static ILowKodeContext WithModelType<TModel>(this ILowKodeContext ctx) => WithModelType(ctx, typeof(TModel));

        public static ILowKodeContext WithModel(this ILowKodeContext ctx, object model)
        {
            var scope = ctx.CreateScope();

            var siteSpecification = scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());
            siteSpecification.Model = model;

            return scope;
        }

        public static ILowKodeContext WithProperty(this ILowKodeContext ctx, MemberExpression modelMember)
        {
            var scope = ctx.CreateScope();

            var siteSpecification = scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());
            siteSpecification.ModelMember = modelMember;

            return scope;
        }

        public static ILowKodeContext WithProperty(this ILowKodeContext ctx, IPropertyMetadata propertyMetadata)
        {
            var scope = ctx.CreateScope();

            var siteSpecification = scope.First<ComponentSiteSpecification>(() => new ComponentSiteSpecification());

            // todo: create an expression from the propertyMetedata
            //siteSpecification.ModelMember = propertyMetadata.;

            return scope;
        }

    }
}
