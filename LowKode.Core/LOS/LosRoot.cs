using LowKode.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot : ILosRoot
    {

        internal protected int ObjectId;
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


        private class PutRequest { public int objectId; public string propertyName; public Type valueType; public object valueHolder; }
        void ILosObject.Put(string propertyNam, Type valueTyp, object valueHolde)
        {
            var requests = new Stack<PutRequest>();
            requests.Push(new PutRequest()
            {
                objectId = ObjectId,
                propertyName = propertyNam,
                valueType = valueTyp,
                valueHolder = valueHolde
            });

            while (0 < requests.Count)
            {
                var request = requests.Pop();

                int additionId = LOS.Insert(request.objectId, Revision, request.propertyName, request.valueType);

                foreach (var property in request.valueType.GetProperties())
                {
                    var propertyValue = request.valueHolder != null ? property.GetValue(request.valueHolder) : null;

                    //var isLosObject = !(property.PropertyType.IsSimpleType()
                    //    || typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType));

                    var isLosObject = property.PropertyType.Namespace == valueTyp.Namespace;

                    if (isLosObject)
                    {
                        requests.Push(new PutRequest()
                        {
                            objectId = additionId,
                            propertyName = property.Name,
                            valueType = property.PropertyType,
                            valueHolder = propertyValue
                        });
                    }
                    else
                    {
                        if (request.valueHolder != null)
                        {
                            LOS.Update(additionId, Revision, property.Name, propertyValue);
                        }
                    }
                }
            }
        }


        virtual public object Get(string propertyName)
        {
            return LOS.Get(ObjectId, Revision, propertyName);
        }



        void ILosObject.Remove(string propertyName)
        {
            // todo: leaving this unimplemented is causing memory leaks but I have bigger problems rights now
            throw new NotImplementedException();
        }

        public ILosRoot Branch()
        {
            return LOS.Branch(this);
        }

        public void Dispose()
        {
            LOS.Prune(this);
        }
    }
}
