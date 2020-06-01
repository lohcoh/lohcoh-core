using System;
using System.Collections.Generic;
using System.Text;


namespace LowKode.Core.LOS
{
    /// <summary>
    /// A LOS object is a proxy that translates calls to the ILosObject interface to 
    /// commands passed to the underlying object system.
    /// </summary>
    class LosObject : ILosObject
    {
        protected int objectId;

        public int Revision { get; private set; }
        public ILosObjectSystem LOS { get; private set; }

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosObject(ILosObjectSystem los, int revision, int objectId)
        {
            this.LOS= los;
            this.Revision= revision;
            this.objectId= objectId;
        }

        virtual public void Add(string propertyName, Type valueType, object value)
        {
            LOS.Insert(objectId, Revision, propertyName, valueType, value);
        }

        virtual public object Get(string propertyName)
        {
            return LOS.Get(objectId, Revision, propertyName);
        }

        virtual public void Remove(string propertyName)
        {
            LOS.Remove(objectId, Revision, propertyName);
        }
    }
}
