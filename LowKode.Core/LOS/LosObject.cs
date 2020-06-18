using System;
using System.Collections.Generic;
using System.Text;


namespace LowKode.Core.LOS
{
    /// <summary>
    /// ILosObject a proxy that represents objects outside of the LOS object system.
    /// That is, LOS presents a object-oriented API to it's users, but internally LOS saves 
    /// it's data in tables and such.   So, when the user selects data from a LOS object system 
    /// a proxy is created by LOS that the user can use to access that object's data.
    /// 
    /// A LOS proxy also tracks changes in order to efficiently saved a mutated object tree to a new branch in LOS.
    /// 
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

        virtual public void Put(string propertyName, Type interfaceType, object value)
        {
            throw new Exception("Unimplemented");
        }

    }
}
