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
    /// The only way to access the metadata objects in the service is via the Find method.
    /// The Find method returns all the metadata objects available of the denoted Type.
    /// 
    /// You can discover the types of all available metadata object via the GetRoots method.
    /// 
    /// The only way to add metadata objects to the service is via the ILowKodeMetaProvider API.
    /// 
    /// </summary>
    public interface ILowKodeMetaService 
    {
        IEnumerable<Type> Roots { get; }

        IEnumerable<T> Find<T>();
        IEnumerable<Type> Find(Type modelType);

        //void Add<T>(T value);
        //void Add(Type modelType, object value);

        bool ContainsRoot<T>() where T : Type;
        bool ContainsRoot(Type modeltype);

        //bool Remove<T>(T key) where T : Type;

        bool TryGetValue<T, V>(T key, out V value) where T : Type where V : IEnumerable<T>;
    }
}
