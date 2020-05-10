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

        /// <summary>
        /// Same as parameterless First but calls the given function to get a new root if no root is found
        /// </summary>
        TRoot First<TRoot>(Func<TRoot> p);

        void Add(Type root, object value);
        void Add<TRoot>(TRoot value) => Add(typeof(TRoot), value);
        void Add(object value) => Add(value.GetType(), value);

    }
}
