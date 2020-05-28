using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    /// <summary>
    /// A LOS object is a proxy that translates calls to the ILosObject interface to 
    /// commands passed to the underlying object system.
    /// </summary>
    public class LosObject : ILosObject
    {
        int revision;
        int objectId;
        ILosObjectSystem los;

        LosObject(ILosObjectSystem los, int revision, int objectId)
        {
            this.los= los;
            this.revision= revision;
            this.objectId= objectId;
        }

        public object Add(string propertyName, Type tProperty)
        {
            return los.Add(this, propertyName, tProperty);
        }

        public object Get(string propertyName)
        {
            return los.Get(this, propertyName);
        }

        public object Remove(string propertyName)
        {
            return los.Remove(this, propertyName);
        }
    }
}
