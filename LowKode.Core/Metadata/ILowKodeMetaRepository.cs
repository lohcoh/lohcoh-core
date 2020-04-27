using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    // Adds methods for mutating data to ILowKodeMetaService
    public interface ILowKodeMetaRepository : ILowKodeMetaService
    {
        void Add<T>(T value);
        void Add(Type modelType, object value);
        bool Remove<T>(T value);
        bool Remove(Type modelType, object value);
    }
}
