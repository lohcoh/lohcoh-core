using LowKode.Core.Common;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    public static class ContentExtensions
    {
      
        public static IComponentSite WithModelType(this IComponentSite site, Type modelType)
        {
            var type = site.Metadata.ForSystemType(modelType);
            site.Context.ComponentSiteSpecification.ModelType= type;
            return site;
        }

        public static IComponentSite WithModelType<TModel>(this IComponentSite site) 
            => WithModelType(site, typeof(TModel));

        public static IComponentSite WithModel(this IComponentSite site, object model)
        {
            var siteSpecification = site.Context.ComponentSiteSpecification;
            siteSpecification.Model = model;

            if (siteSpecification.ModelType == null)
            {
                siteSpecification.ModelType = site.Metadata.ForSystemType(model.GetType());
            }

            return site;
        }
        public static IComponentSite WithModel<TModel>(this IComponentSite site, TModel model)
        {
            var siteSpecification = site.Context.ComponentSiteSpecification;
            siteSpecification.Model = model;

            if (siteSpecification.ModelType == null)
            {
                siteSpecification.ModelType = site.Metadata.ForSystemType(typeof(TModel));
            }

            return site;
        }

        public static IComponentSite WithModelMember(this IComponentSite site, IDependencyPath modelMember)
        {
            var siteSpecification = site.Context.ComponentSiteSpecification;
            siteSpecification.ModelMember = modelMember;
            return site;
        }
        public static IComponentSite WithModelMember(this IComponentSite site, IDependencyProperty modelMember)
            => WithModelMember(site, new DependencyPath(modelMember));

    }
}
