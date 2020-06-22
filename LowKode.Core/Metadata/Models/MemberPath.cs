using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
{
    public static class MemberSelectorExtensions
    {
        public static MemberPath ToMemberPath(this PropertyDescriptor descriptor) => new MemberPath(descriptor);
    }


    /// <summary>
    /// A selector that identifies a node in a LOS object tree.
    /// Basically a list of PropertyDescriptors that identify how to navigate from an object to some descendant of the object.
    /// </summary>
    public class MemberPath : IEnumerable<PropertyDescriptor>
    {
        PropertyDescriptor[] descriptors;
        public MemberPath(params PropertyDescriptor[] descriptors)
        {
            this.descriptors= descriptors;
        }

        public IEnumerator<PropertyDescriptor> GetEnumerator() => (IEnumerator<PropertyDescriptor>)descriptors.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => descriptors.GetEnumerator();

        /// <summary>
        /// Returns the last descriptor in the MemberPath.
        /// This descriptor identifies the property which the MemberPath identifies.
        /// </summary>
        public PropertyDescriptor TargetProperty { get => descriptors[descriptors.Length - 1]; }

        public virtual void Set(object model, object value)
        {
            // todo: unfinished, this isn't gonna work for nested properties
            foreach (var descriptor in descriptors)
            {
                descriptor.SetMethod(model, value);
            }
        }

        public virtual object Get(object model)
        {
            // todo: unfinished, this isn't gonna work for nested properties
            foreach (var descriptor in descriptors)
            {
                return descriptor.GetMethod(model);
            }
            return default(Object);
        }
    }
}
