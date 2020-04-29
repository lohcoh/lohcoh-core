using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// ILowKodeMetaService is a bare-bones but extensible metadata API.
    /// The service is a collection of metadata objects, that is, objects that hold metadata.
    /// Metadata objects may be nested, an individual metadata object may represent an entire REST api and be composed of many other metadata objects.
    /// 
    /// ILowKodeMetaService stores 'root' metadata objects by type.
    /// Use the Find method to retrieve all the metadata objects of a given type stored in the service.
    /// 
    /// You can discover the types of all available 'root' metadata objects via the Roots property.
    /// 
    /// This interface is meant to be used by components and only provides methods for fetching data.
    /// The only way to add metadata objects to the service is via the ILowKodeMetaRepository API, during Startup configuration.
    /// 
    /// </summary>
    public interface ILowKodeMetaService 
    {
        IEnumerable<Type> Roots { get; }

        IEnumerable<T> Find<T>();
        IEnumerable<Type> Find(Type modelType);

        bool ContainsRoot<T>() where T : Type;
        bool ContainsRoot(Type modeltype);

        bool TryGetValue<T, V>(T key, out V value) where T : Type where V : IEnumerable<T>;
    }
}
