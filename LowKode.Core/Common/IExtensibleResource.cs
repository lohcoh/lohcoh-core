using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// 
    /// IExtensibleResource extends IDiscoverableResource with methods for adding values.
    /// 
    /// </summary>
    public interface IExtensibleResource : IDiscoverableResource
    {


        void Add(Type root, object value);
        void Add<TRoot>(TRoot value) => Add(typeof(TRoot), value);
        void Add(object value) => Add(value.GetType(), value);

    }
}
