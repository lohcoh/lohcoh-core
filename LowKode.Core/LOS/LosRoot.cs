using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot : LosObject, ILosRoot
    {

        class DocumentInfo { public Type DocumentType; public object Document; }
        Dictionary<string, DocumentInfo> Additions= new Dictionary<string, DocumentInfo>();

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosRoot(ILosObjectSystem los, int revision, int objectId) : base(los, revision, objectId)
        {
        }

        override public void Put(string propertyName, Type valueType, object value)
        {
            // record the addition, when the Save method is called these additions will be inserted into object system.
            Additions.Add(propertyName, new DocumentInfo() {  DocumentType= valueType, Document= value });
        }


        public ILosRoot Save()
        {
            // todo: need a proper generator of branch ids
            var branch= new LosRoot(LOS, Revision+1, ObjectId);
            foreach (var propertyName in Additions.Keys)
            {
                var documentInfo= Additions[propertyName];
                LOS.Insert(ObjectId, branch.Revision, propertyName, documentInfo.DocumentType, documentInfo.Document);
            }
            return branch;
        }
    }
}
