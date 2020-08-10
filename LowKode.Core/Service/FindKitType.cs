using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Components
{
    public class FindKitType : IContextRequest<Type> 
    {
        SiteSpecification SiteSpecification {  get; set; }
        public FindKitType(SiteSpecification specification)
        {
            SiteSpecification= specification;
        }
    }
    public class FindKitTypeHandler : IContextHandler<FindKitType>
    {
        public Type Handle(FindKitType request, CancellationToken cancellationToken)
        {
            var siteSpecification = request.SiteSpecification;

            // set site type, one of: Input, Display, etc...
            var siteType = typeof(TSite);
            var specification = site.Context.SiteSpecification;
            specification.SiteType = siteType;

            // get model type
            var modelType = specification.ModelType;
            if (specification.ModelMember != null)
            {
                modelType = specification.ModelMember.TargetProperty.PropertyType;
            }

            // get kit component type
            ComponentTypeMapping componentMapping = null;
            if (componentMapping == null && specification.ModelMember.TargetProperty.EnumType != null)
            {
                componentMapping = site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == TypeDescriptor.ForSystemType(typeof(Enum))).FirstOrDefault();
            }
            if (componentMapping == null)
                componentMapping = site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == modelType).FirstOrDefault();
            if (componentMapping == null)
                componentMapping = site.Metadata.ComponentTypes.Where(t => t.SiteType == siteType && t.ModelType == null).FirstOrDefault();
            if (componentMapping == null)
                throw new Exception("No component mapping found for SiteType '" + siteType.FullName + "' and  ModelType '" + modelType.DisplayName + "'");

            // render 'kit' component
            var componentType = componentMapping.ComponentType;

            return componentType;
        }
    }
    static public class FindKitComponentTypeExtension
    {
        public static Type FindKitType(this Scope scope, SiteSpecification siteSpecification)
        {
            return scope.Accept(new FindKitType(siteSpecification));
        }
    }
}
