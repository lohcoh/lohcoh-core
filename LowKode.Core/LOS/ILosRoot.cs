using System;

namespace LowKode.Core
{
    /// <summary>
    /// The root of an object tree retrieved from a LOS object system.
    /// The ILosRoot interface provides object-oriented to the properties 
    /// </summary>
    public interface ILosRoot : ILosObject, IDisposable
    {
        public int Revision { get; }

        public ILosRoot Branch();

        //public ILosObjectSystem LOS { get; }
    }
}