using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot :  ILosRoot
    {

        protected int ObjectId;
        public int Revision { get; private set; }
        public LosObjectSystem LOS { get; private set; }

        class DocumentInfo { public Type DocumentType; public object Document; }
        Dictionary<string, DocumentInfo> Additions= new Dictionary<string, DocumentInfo>();


        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosRoot(LosObjectSystem los, int revision, int objectId) 
        {
            this.LOS = los;
            this.Revision = revision;
            this.ObjectId = objectId;
        }


        void ILosObject.Put(string propertyName, Type valueType, object valueHolder)
        {
            // record the addition, when the Save method is called these additions will be inserted into object system.            
            Additions.Add(propertyName, new DocumentInfo() {  DocumentType= valueType, Document= valueHolder });
        }


        public ILosRoot Save()
        {
            // first: create the objects that have been added to the object tree
            // todo: need a proper generator of branch ids

            foreach (var propertyName in Additions.Keys)
            {
                var documentInfo= Additions[propertyName];
                int additionId= LOS.Insert(ObjectId, Revision, propertyName, documentInfo.DocumentType);

                foreach (var property in documentInfo.DocumentType.GetProperties())
                {
                    var propertyValue = property.GetValue(documentInfo.Document);
                    if (propertyValue != null)
                    {
                        LOS.Update(additionId, Revision, property.Name, property.GetValue(documentInfo.Document));
                    }                    
                }
            }

            return new LosRoot(LOS, Revision + 1, ObjectId);
        }


        virtual public object Get(string propertyName)
        {
            return LOS.Get(ObjectId, Revision, propertyName);
        }

       

        void ILosObject.Remove(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
