using LowKode.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// ILowKodeMetaService is meant to be a bare-bones but extensible metadata API.
    /// </summary>
    public interface ILowKodeMetaService : IDependencyObject
    {
        //IEnumerable<Type> Roots { get; }

        //IEnumerable<T> Find<T>();
        //IEnumerable<object> Find(Type modelType);
        //T First<T>();
        //object First(Type modelType);

        //bool ContainsRoot<T>() where T : Type;
        //bool ContainsRoot(Type modeltype);

        //bool TryGetValue<T, V>(T key, out V value) where T : Type where V : IEnumerable<T>;
    }
}
