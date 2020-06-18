using LowKode.Core.Common;
using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core
{
    /// <summary>
    /// Encapsulates information required to create a component for a specific site.
    /// </summary>
    public class SiteSpecification 
    {

        /// <summary>
        /// The site type indicates a general category of UI component that should be used to display the associated context.
        /// This will be a type like <Edit/>, <Display/>, or <DisplayName/>
        /// The actual component used to render the associated site is specified by the ComponentType property.
        /// ComponentType must be a subclass of SiteType.
        /// Required, may not be null.
        /// </summary>
        public virtual Type SiteType { get; set; }

        /// <summary>
        /// The actual component that will be used to render the associated content.
        /// Required, may not be null.
        /// </summary>
        public virtual Type ComponentType { get; set; }

        /// <summary>
        /// The actual value to be displayed by the component
        /// Can be null, because some components just display hard-coded content and they don't need a value.
        /// Must be an instance of ModelType.
        /// </summary>
        public virtual Object Model { get; set; }

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
        public virtual TypeDescriptor ModelType { get; set; }

        /// <summary>
        /// Denotes the part of the model to be displayed by the component associated with this specification.
        /// </summary>
        public virtual MemberPath ModelMember { get; set; }
    }
}
