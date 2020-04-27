using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata.Service
{
    public class LowKodeMetaService : ILowKodeMetaRepository
    {
        public IEnumerable<Type> Roots => throw new NotImplementedException();

        public void Add<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Add(Type modelType, object value)
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

        public bool Remove<T>(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Type modelType, object value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue<T, V>(T key, out V value)
            where T : Type
            where V : IEnumerable<T>
        {
            throw new NotImplementedException();
        }
    }
}
