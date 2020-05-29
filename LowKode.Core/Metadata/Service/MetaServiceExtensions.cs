using LowKode.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LowKode.Core.Metadata
{
    public static class MetaServiceExtensions
    {
        public static IDependencyObjectType ForSystemType(this ILowKodeMetadata metadata, Type systemType)
            => metadata.DependencyObjectTypes.Where(o => o.SystemType == systemType).First();


        public static IDependencyObjectType ForSystemType<TSystem>(this ILowKodeMetadata metadata)
            => ForSystemType(metadata, typeof(TSystem));
    }
    interface IDependencyObjectTypes { }

  

}
