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
        protected int revision;
        protected int objectId;
        protected ILosObjectSystem los;

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosObject(ILosObjectSystem los, int revision, int objectId)
        {
            this.los= los;
            this.revision= revision;
            this.objectId= objectId;
        }

        virtual public void Add(string propertyName, Type valueType, object value)
        {
            los.Insert(objectId, revision, propertyName, valueType, value);
        }

        virtual public object Get(string propertyName)
        {
            return los.Get(objectId, revision, propertyName);
        }

        virtual public void Remove(string propertyName)
        {
            los.Remove(objectId, revision, propertyName);
        }
    }
}
