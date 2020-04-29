using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    // Adds methods to ILowKodeMetaService for mutating data 
    public interface ILowKodeMetaRepository : ILowKodeMetaService
    {

        /// <summary>
        /// Add a new 'root' object to the repository.
        /// </summary>
        void Add(object value);
        bool Remove(object value);
    }
}
