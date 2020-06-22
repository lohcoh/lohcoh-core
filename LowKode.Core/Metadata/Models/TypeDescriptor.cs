using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// Describes a type of object.
    /// 
    /// Not intended just for representing .NET types.
    /// That is, eventually Lowkoder should support schemas that come from sources other than the .NET type system.
    /// For instance, TypeDescriptors could be generated from database views, or OpenAPI schemas, etc.
    /// </summary>
    public class TypeDescriptor 
    {
        static Dictionary<Type, TypeDescriptor> _descriptors = new Dictionary<Type, TypeDescriptor>();

        public static TypeDescriptor ForSystemType(Type systemType)
        {
            TypeDescriptor descriptor;
            if (!_descriptors.TryGetValue(systemType, out descriptor))
            {
                descriptor = new TypeDescriptor(systemType);
                _descriptors.Add(systemType, descriptor);
            }
            return descriptor;
        }

        private List<PropertyDescriptor> _properties = new List<PropertyDescriptor>();
        public string DisplayName { get; set; }

        /// <summary>
        /// Creates a TypeDescriptor that represents the given .NET type
        /// </summary>
        TypeDescriptor(Type t)
        {
            SystemType = t;
            DisplayName = t.FullName;

            var displayNameAttribute= (DisplayNameAttribute)t.GetCustomAttributes(typeof(DisplayNameAttribute), false).SingleOrDefault();
            if (displayNameAttribute != null)
                DisplayName = displayNameAttribute.DisplayName;

            foreach (var propertInfo in t.GetProperties())
            {
                var propertyMetadata = new PropertyDescriptor(propertInfo);
                _properties.Add(propertyMetadata);
            }

        }

        /// <summary>
        /// Returns null if this TypeDescriptor is not associated with a .NET type
        /// </summary>
        public Type SystemType { get; set; }

        public IReadOnlyCollection<PropertyDescriptor> Properties { get => _properties; }
    }

}
