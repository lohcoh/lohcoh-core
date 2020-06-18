using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// Maps TypeDescriptors to components that display the associated types.
    /// </summary>
    public class ComponentTypeMapping
    {
        /// <summary>
        /// The type of object t be displayed
        /// </summary>
        public TypeDescriptor ModelType { get; set; }

        /// <summary>
        /// The type of site.
        /// Will be a type associated with a site component like <Input/>, <Display/>, <Card/>, or <DisplayName/>
        /// </summary>
        public Type SiteType { get; set; }

        /// <summary>
        /// A subclass of SiteType that implements the site for the denoted ModelType
        /// </summary>
        public Type ComponentType { get; set; }
    }
}
