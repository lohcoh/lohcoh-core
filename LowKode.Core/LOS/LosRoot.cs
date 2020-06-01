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

        override public void Add(string propertyName, Type valueType, object value)
        {
            Additions.Add(propertyName, new DocumentInfo() {  DocumentType= valueType, Document= value });
        }


        public ILosRoot Save()
        {
            // todo: need a proper generator of branch ids
            var branch= new LosRoot(los, revision+1, objectId);
            foreach (var propertyName in Additions.Keys)
            {
                var documentInfo= Additions[propertyName];
                los.Insert(objectId, branch.revision, propertyName, documentInfo.DocumentType, documentInfo.Document);
            }
            return branch;
        }
    }
}
