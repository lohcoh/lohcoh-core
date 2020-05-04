using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// TODO: Unimplemented
    /// </summary>

    public class LowKodeMetaService : ILowKodeMetaRepository
    {
        public IEnumerable<Type> Roots => throw new NotImplementedException();

        public void Add(object value)
        {
            throw new NotImplementedException();
        }

        public ILowKodeMetaRepository AddMetadataRoot(Type rootType, object metadataRoot)
        {
            throw new NotImplementedException();
        }

        public bool ContainsRoot<T>() where T : Type
        {
            throw new NotImplementedException();
        }

        public bool ContainsRoot(Type modeltype)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> Find(Type modelType)
        {
            throw new NotImplementedException();
        }

        public T First<T>()
        {
            throw new NotImplementedException();
        }

        public object First(Type modelType)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue<T, V>(T key, out V value)
            where T : Type
            where V : IEnumerable<T>
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ILowKodeMetaService.Find(Type modelType)
        {
            throw new NotImplementedException();
        }
    }
}
