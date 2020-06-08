using System;
using System.Collections.Generic;
using System.Text;
using Castle.Components;
using Castle.Components.DictionaryAdapter;
using Castle.DynamicProxy;

namespace LowKode.Core.LOS
{
    public class LosObjectSystem : ILosObjectSystem
    {
        ILosRoot Prime { get; set; }

        private Dictionary<int, ObjectInfo> objectLookup = new Dictionary<int, ObjectInfo>();

        public LosObjectSystem()
        {
            var documentObject = new ObjectInfo(typeof(LosRoot));
            objectLookup.Add(documentObject.Id, documentObject);

            Prime = new LosRoot(this, revision:-1, objectId: documentObject.Id);
        }

        public ILosRoot Open() => Prime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId">The id of the object into which a document is being inserted.  For now, objectId must</param>
        /// <param name="revision">The revision # of the branch</param>
        /// <param name="propertyName"></param>
        /// <param name="documentType"></param>
        /// <param name="document"></param>
        public int Insert(int objectId, int revision, string propertyName, Type documentType)
        {
            ObjectInfo targetObject;
            if (!objectLookup.TryGetValue(objectId, out targetObject))
                throw new Exception("Unknown objectId:"+objectId);

            if (targetObject.PropertyLookup.ContainsKey(propertyName))
                throw new Exception("Object["+objectId+"] already contains property '"+propertyName+"'");

            // create new document object and add to system 
            var documentObject= new ObjectInfo(documentType);
            objectLookup.Add(documentObject.Id, documentObject);

            // add object as property to target object
            var propertyStore = new PropertyStore();
            propertyStore.AddValue(revision, documentObject);
            targetObject.PropertyLookup.Add(propertyName, propertyStore);

            return documentObject.Id;
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

            object value= propertyStore.GetValue(revision);
            if (!(value is ObjectInfo))
                return value;

            // The value being retrieved is a nested object, return a proxy.
            var vobjectInfo= value as ObjectInfo;
            return new ProxyGenerator().CreateClassProxy(
                vobjectInfo.DocumentType, new IInterceptor[] { });

        }


        public object GetObjectAdapter(Type DocumentType, IDictionary<string, object> valueHolder)
        {
            return new DictionaryAdapterFactory().GetAdapter<object>(DocumentType, valueHolder);
        }

    }

    class ObjectInfo
    {
        public Type DocumentType { get; private set; }

        public ObjectInfo(Type documentType)
        {
            DocumentType = documentType;
        }

        public Dictionary<string, PropertyStore> PropertyLookup { get; } = new Dictionary<string, PropertyStore>();
        public int Id { get=>GetHashCode(); }

        public object GetObjectAdapter(int revision)
        {
            new ProxyGenerator().CreateClassProxy(DocumentType, new IInterceptor[] { });

        }

    }
}
