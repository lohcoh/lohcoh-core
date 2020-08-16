using LowKode.Core.Metadata;
using System;
using System.Linq.Expressions;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Encapsulates information required to instantiate a component for a specific site.
    /// </summary>
    public class SiteSpecification 
    {
        public SiteSpecification() { }
        public SiteSpecification(SiteSpecification specification)
        {

        }

        /// <summary>
        /// The site type indicates a general category of UI component that should be used to display the associated context.
        /// 
        /// Examples: <Input/>, <Display/>, <DisplayName/>, <Card/>, <DataTable/>
        /// Required, may not be null.
        /// </summary>
        public Type SiteType { get; set; }

        /// <summary>
        /// The actual component that will be used to render the associated content.
        /// ComponentType must be a subclass of SiteType.
        /// Required, may not be null.
        /// </summary>
        public Type ComponentType { get; set; }

        /// <summary>
        /// The actual value to be displayed by the component
        /// Can be null, because some components just display hard-coded content and they don't need a value.
        /// Must be an instance of ModelType.
        /// </summary>
        public Object Model { get; set; }

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
        public TypeDescriptor ModelType { get; set; }

        /// <summary>
        /// Denotes the part of the model to be displayed by the component associated with this specification.
        /// </summary>
        public MemberPath ModelMember { get; set; }
    }
}
