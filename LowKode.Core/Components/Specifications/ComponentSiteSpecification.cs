using LowKode.Core.Common;
using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Encapsulates information required to create a component for a specific site.
    /// </summary>
    public class ComponentSiteSpecification : DependencyObject, IComponentSiteSpecification
    {
        public object Model { get; set; }
        public IDependencyObjectType ComponentType { get; set; }

        public IDependencyObjectType ModelType { get; set; } 

        public IDependencyPath ModelMember { get; set; }
    }
}
