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

    public class MemberPath : IEnumerable<PropertyDescriptor>
    {
        PropertyDescriptor[] descriptors;
        public MemberPath(params PropertyDescriptor[] descriptors)
        {
            this.descriptors= descriptors;
        }

        public IEnumerator<PropertyDescriptor> GetEnumerator() => (IEnumerator<PropertyDescriptor>)descriptors.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => descriptors.GetEnumerator();

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
