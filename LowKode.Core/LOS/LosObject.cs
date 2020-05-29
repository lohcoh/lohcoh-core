using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Proxies;

namespace LowKode.Core.LOS
{
    /// <summary>
    /// A LOS object is a proxy that translates calls to the ILosObject interface to 
    /// commands passed to the underlying object system.
    /// </summary>
    class LosObject : ILosObject
    {
        int revision;
        int objectId;
        ILosObjectSystem los;

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosObject(ILosObjectSystem los, int revision, int objectId)
        {
            this.los= los;
            this.revision= revision;
            this.objectId= objectId;
        }

        public object Add(string propertyName, Type tProperty)
        {
            return los.Add(objectId, revision, propertyName, tProperty);
        }

        public object Get(string propertyName)
        {
            return los.Get(objectId, revision, propertyName);
        }

        public void Remove(string propertyName)
        {
            los.Remove(objectId, revision, propertyName);
        }
        /// <summary>
        /// Generates an object that implments ILosObject as well as objectInterface
        /// </summary>
        internal static object GetObjectProxy(Type objectInterface, LosObjectSystem losObjectSystem, int revision, int newObjectId)
        {
            throw new NotImplementedException();
        }
    }
}
