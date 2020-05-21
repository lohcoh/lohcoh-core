using LowKode.Core.Common;
using LowKode.Core.Context;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{


    /// <summary>
    /// Encapsulates all the basic information required to create a component.
    /// Can be extended with additional properties.
    /// The IComponentSiteSpecification interface only declares values that will be universally required to create a component.
    /// 
    /// todo: implement dependency properties
    /// </summary>
    public interface ISiteSpecification : IDependencyObject
    {

        /// <summary>
        /// The type of component to create, like <Input/> or <DisplayName/>
        /// The actual component created from this specification must be an instance of ComponentType or a subclass.
        /// Required, may not be null.
        /// </summary>
        IDependencyObjectType ComponentType { get; set; }

        /// <summary>
        /// The actual value to be displayed by the component
        /// Can be null, because some components just display some essentially hard-coded content and they don't need a value.
        /// </summary>
        Object Model { get; set;  }

        /// <summary>
        /// The ModelType property denotes the Type of data to be displayed by the component associated with this specification.
        /// 
        /// If ModelType is denotes a type that represents a primitive value (int, string, date, etc) 
        /// then the component created from this specification will display a scalar value, not 
        /// a property of some model object.
        /// 
        /// Otherwise, the component created from this specification will displayed all, or some part of, a model object.
        /// 
        /// Required, may not be null.
        /// </summary>
        IDependencyObjectType ModelType { get; set; }

        /// <summary>
        /// Denotes the part of the model to be displayed by the component associated with this specification.
        /// </summary>
        IDependencyPath ModelMember { get; set; }
    }


}
