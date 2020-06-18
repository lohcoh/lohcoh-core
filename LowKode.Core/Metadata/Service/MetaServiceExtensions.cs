using System;
using System.Linq;

namespace LowKode.Core.Metadata
{
    public static class MetaServiceExtensions
    {
        public static TypeDescriptor ForSystemType(this LowkoderMetadata metadata, Type systemType)
            => metadata.TypeDescriptors.Where(o => o.SystemType == systemType).First();


        public static TypeDescriptor ForSystemType<TSystem>(this LowkoderMetadata metadata)
            => ForSystemType(metadata, typeof(TSystem));
    }
    interface IDependencyObjectTypes { }

  

}
