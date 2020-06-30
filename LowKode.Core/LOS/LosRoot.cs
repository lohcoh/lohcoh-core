using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot :  ILosRoot
    {

        protected int ObjectId;
        public RevisionTag Revision { get; private set; }
        public LosObjectSystem LOS { get; private set; }

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosRoot(LosObjectSystem los, RevisionTag revision, int objectId) 
        {
            this.LOS = los;
            this.Revision = revision;
            this.ObjectId = objectId;
        }


        void ILosObject.Put(string propertyName, Type valueType, object valueHolder)
        {
            int additionId = LOS.Insert(ObjectId, Revision, propertyName, valueType);

            foreach (var property in valueType.GetProperties())
            {
                var propertyValue = property.GetValue(valueHolder);
                if (propertyValue != null)
                {
                    LOS.Update(additionId, Revision, property.Name, property.GetValue(valueHolder));
                }
            }
        }


        virtual public object Get(string propertyName)
        {
            return LOS.Get(ObjectId, Revision, propertyName);
        }

       

        void ILosObject.Remove(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ILosRoot Branch()
        {
            return new LosRoot(LOS, Revision + 1, ObjectId);
        }

        public void Dispose()
        {
            LOS.Prune(this);
        }
    }
}
