using LowKode.Core.Common;
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
        public virtual IEnumerable<TypeDescriptor> TypeDescriptors { get; set; }
    }
}
