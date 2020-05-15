using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Encapsulates information required to create a component for a specific site.
    /// </summary>
    public class ComponentSiteSpecification : IComponentSiteSpecification
    {
        public Type ComponentType { get; set; }

        public object Model { get; set; }

        public Type ModelType { get; set; }
        public MemberExpression ModelMember {  get; set; }

    }
}
