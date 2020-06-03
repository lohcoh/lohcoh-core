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
        protected int ObjectId;

        public int Revision { get; private set; }
        public ILosObjectSystem LOS { get; private set; }

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosObject(ILosObjectSystem los, int revision, int objectId)
        {
            this.LOS= los;
            this.Revision= revision;
            this.ObjectId= objectId;
        }       

        virtual public object Get(string propertyName)
        {
            return LOS.Get(ObjectId, Revision, propertyName);
        }

        virtual public void Remove(string propertyName)
        {
            LOS.Remove(ObjectId, Revision, propertyName);
        }

        virtual public object Put(string propertyName, Type interfaceType)
        {
            return LOS.Insert(ObjectId, Revision, propertyName, interfaceType);
        }

    }
}
