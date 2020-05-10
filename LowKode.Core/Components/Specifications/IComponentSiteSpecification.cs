using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    public interface PropertyIdentifier
    {
        string Name { get; }
        Type Type {  get; }
    }

    /// <summary>
    /// Specifies all the information required to create a component.
    /// The IComponentSpecification interface only declares values that will be universally required to create a component.
    /// It's intended that there will be many implementations of this interface that require additional values.
    /// </summary>
    public interface IComponentSiteSpecification
    {

        /// <summary>
        /// The type of component to create.
        /// The actual component created from this specification must be an instance of ComponentType or a subclass.
        /// Required, may not be null.
        /// </summary>
        Type ComponentType { get; }

        /// <summary>
        /// The actual value to be displayed by the component
        /// Can be null, because some components just display some essentially hard-coded content and they don't need a value.
        /// </summary>
        Object Model { get; }

        /// <summary>
        /// If ModelType is denotes a type that represents a primitive value (int, string, date, etc) 
        /// then the component created from this specification will display a scalar value, not 
        /// a property of some model object.
        /// 
        /// Otherwise, the component created from this specification will displayed all, or some part of, a model object.
        /// The ModelType property denotes the Type of the model object.
        /// 
        /// Required, may not be null.
        /// </summary>
        ITypeMetadata ModelType { get; }

        MemberExpression ModelMember {  get; }
    }


}
