using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot : LosObjectAdapter, ILosRoot
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


        void ILosObject.Put(string propertyName, Type valueType)
        {
            // record the addition, when the Save method is called these additions will be inserted into object system.
            var valueHolder = new Dictionary<string, object>();
            Additions.Add(propertyName, new DocumentInfo() {  DocumentType= valueType, Document= valueHolder });

            //var objectAdapter = LOS.GetObjectAdapter(valueType, valueHolder);
            //return objectAdapter;
        }


        public ILosRoot Save()
        {
            // first: create the objects that have been added to the object tree
            // todo: need a proper generator of branch ids
            var branch= new LosRoot(LOS, Revision+1, ObjectId);
            foreach (var propertyName in Additions.Keys)
            {
                var documentInfo= Additions[propertyName];
                LOS.Insert(ObjectId, branch.Revision, propertyName, documentInfo.DocumentType);
            }


            return branch;
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
