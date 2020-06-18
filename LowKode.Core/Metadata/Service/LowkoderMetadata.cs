using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// Metadata supplied by Lowkoder
    /// </summary>
    public class LowkoderMetadata 
    {
        public virtual ICollection<TypeDescriptor> TypeDescriptors { get; } = new List<TypeDescriptor>();
        public virtual ICollection<ComponentTypeMapping> ComponentTypes { get; } = new List<ComponentTypeMapping>();
    }
}
