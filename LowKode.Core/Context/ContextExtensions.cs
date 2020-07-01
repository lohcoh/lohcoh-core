using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    public static class ContentExtensions
    {
      
        public static IComponentSite UseModelType(this IComponentSite site, Type modelType)
        {
            var type = site.Metadata.ForSystemType(modelType);
            site.Context.SiteSpecification.ModelType= type;
            return site;
        }
        public static IComponentSite UseModelType(this IComponentSite site, Type modelType, out TypeDescriptor descriptor)
        {
            var type = site.Metadata.ForSystemType(modelType);
            site.Context.SiteSpecification.ModelType = type;
            descriptor = type;
            return site;
        }

        public static IComponentSite UseModelType<TModel>(this IComponentSite site) 
            => UseModelType(site, typeof(TModel));
        public static IComponentSite UseModelType<TModel>(this IComponentSite site, out TypeDescriptor descriptor)
        {
            TypeDescriptor t = null;
            UseModelType(site, typeof(TModel), out t);
            descriptor = t;
            return site;
        }

        public static IComponentSite UseModel(this IComponentSite site, object model)
        {
            var siteSpecification = site.Context.SiteSpecification;
            siteSpecification.Model = model;

            if (siteSpecification.ModelType == null)
            {
                siteSpecification.ModelType = site.Metadata.ForSystemType(model.GetType());
            }

            return site;
        }
        public static IComponentSite UseModel<TModel>(this IComponentSite site, TModel model)
        {
            var siteSpecification = site.Context.SiteSpecification;
            siteSpecification.Model = model;

            if (siteSpecification.ModelType == null)
            {
                siteSpecification.ModelType = site.Metadata.ForSystemType(typeof(TModel));
            }

            return site;
        }

        public static IComponentSite UseModelMember(this IComponentSite site, MemberPath memberPath)
        {
            var siteSpecification = site.Context.SiteSpecification;
            siteSpecification.ModelMember = memberPath;
            return site;
        }
        public static IComponentSite UseModelMember(this IComponentSite site, PropertyDescriptor modelMember)
            => UseModelMember(site, modelMember.ToMemberPath());

    }
}
