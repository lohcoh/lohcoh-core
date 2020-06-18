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
    }
}
