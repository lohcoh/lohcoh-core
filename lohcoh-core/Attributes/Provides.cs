using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core
{
    /// <summary>
    /// Denotes dependencies between modules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ProvidesAttribute : Attribute
    {
        public Type InterfaceType { get; set; }
        public Type ImplementationType { get; set; }
        public ProvidesAttribute(Type implementationType) {
            this.ImplementationType = implementationType;
        }
    }
}
