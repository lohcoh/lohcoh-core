using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core
{
    /// <summary>
    /// Denotes dependencies between modules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        public Type ModuleType { get; private set; }
        public DependsOnAttribute(Type moduleType) {

            // If the denoted type is not a subclass of LohcohModule then ignore.
            // It could be that someone else is reusing this attribute for thier own purposes, that seems legit.
            if (moduleType.IsAssignableFrom(typeof(LohcohModule)))
            {
                this.ModuleType = moduleType;
            }
        }
    }
}
