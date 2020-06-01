using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public class LosObjectSystem : ILosObjectSystem
    {
        public ILosRoot Prime { get; private set; }

        private Dictionary<int, ObjectInfo> objectLookup = new Dictionary<int, ObjectInfo>();

        public LosObjectSystem()
        {
            var documentObject = new ObjectInfo();
            objectLookup.Add(documentObject.Id, documentObject);

            Prime = new LosRoot(this, revision:0, objectId: documentObject.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId">The id of the object into which a document is being inserted.  For now, objectId must</param>
        /// <param name="revision">The revision # of the branch</param>
        /// <param name="propertyName"></param>
        /// <param name="documentType"></param>
        /// <param name="document"></param>
        public void Insert(int objectId, int revision, string propertyName, Type documentType, object document)
        {
            ObjectInfo targetObject;
            if (!objectLookup.TryGetValue(objectId, out targetObject))
                throw new Exception("Unknown objectId:"+objectId);

            if (targetObject.PropertyLookup.ContainsKey(propertyName))
                throw new Exception("Object["+objectId+"] already contains property '"+propertyName+"'");

            // create new document object and add property to target object
            var documentObject= new ObjectInfo();
            objectLookup.Add(documentObject.Id, documentObject);
            var propertyStore= new PropertyStore();
            propertyStore.AddValue(revision, documentObject);
            targetObject.PropertyLookup.Add(propertyName, propertyStore);

            // Construct the document tree
            RenderDocumentTree(revision, documentType, documentObject, document);
        }

        void RenderDocumentTree(int revision, Type documentType, ObjectInfo documentObject, object document)
        {
            foreach (var propertyInfo in documentType.GetProperties())
            {
                // todo: this just saves value types, must properly handle nested objects by inserting them into the LOS DOM
                var propertyStore = new PropertyStore();
                var value= propertyInfo.GetValue(document);
                propertyStore.AddValue(revision, value);
                documentObject.PropertyLookup.Add(propertyInfo.Name, propertyStore);
            }
        }

        public void Remove(int objectId, int revision, string propertyName)
        {
            ObjectInfo objectInfo;
            if (!objectLookup.TryGetValue(objectId, out objectInfo))
                throw new Exception("Unknown object id: "+objectId);

            PropertyStore propertyStore;
            if (!objectInfo.PropertyLookup.TryGetValue(propertyName, out propertyStore))
                throw new Exception("Object[" + objectId + "] does not have a proiperty named '" + propertyName + "'");

            propertyStore.RemoveValue(revision);
        }

        public object Get(int objectId, int revision, string propertyName)
        {
            ObjectInfo objectInfo;
            if (!objectLookup.TryGetValue(objectId, out objectInfo))
                throw new Exception("Unknown object id: " + objectId);

            PropertyStore propertyStore;
            if (!objectInfo.PropertyLookup.TryGetValue(propertyName, out propertyStore))
                throw new Exception("Object[" + objectId + "] does not have a proiperty named '" + propertyName + "'");

            return propertyStore.GetValue(revision);
        }

    }

    class ObjectInfo
    {
        public Dictionary<string, PropertyStore> PropertyLookup { get; } = new Dictionary<string, PropertyStore>();
        public int Id { get=>GetHashCode(); }
    }
}
