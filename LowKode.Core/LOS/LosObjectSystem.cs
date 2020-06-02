using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Castle.Components;
using Castle.Components.DictionaryAdapter;

namespace LowKode.Core.LOS
{
    public class LosObjectSystem : ILosObjectSystem
    {
        public ILosRoot Prime { get; private set; }

        private Dictionary<int, ObjectInfo> objectLookup = new Dictionary<int, ObjectInfo>();

        public LosObjectSystem()
        {
            var documentObject = new ObjectInfo(typeof(LosRoot));
            objectLookup.Add(documentObject.Id, documentObject);

            Prime = new LosRoot(this, revision:-1, objectId: documentObject.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId">The id of the object into which a document is being inserted.  For now, objectId must</param>
        /// <param name="revision">The revision # of the branch</param>
        /// <param name="propertyName"></param>
        /// <param name="documentType"></param>
        /// <param name="document"></param>
        public object Insert(int objectId, int revision, string propertyName, Type documentType)
        {
            ObjectInfo targetObject;
            if (!objectLookup.TryGetValue(objectId, out targetObject))
                throw new Exception("Unknown objectId:"+objectId);

            if (targetObject.PropertyLookup.ContainsKey(propertyName))
                throw new Exception("Object["+objectId+"] already contains property '"+propertyName+"'");

            // create new document object and add property to target object
            var documentObject= new ObjectInfo(documentType);
            objectLookup.Add(documentObject.Id, documentObject);
            var propertyStore= new PropertyStore();
            propertyStore.AddValue(revision, documentObject);
            targetObject.PropertyLookup.Add(propertyName, propertyStore);

            return documentObject.GetProxy(revision);
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
            return (value as ObjectInfo).GetProxy(revision);

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

        public object GetProxy(int revision)
        {
            return new DictionaryAdapterFactory().GetAdapter(DocumentType, new LosObjectAdapter(revision));
        }
    }

    class LosObjectAdapter : IDictionary<string, object>
    {
        public object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<object> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        int Revision { get; set; }

        public LosObjectAdapter(int revision)
        {
            this.Revision = revision;
        }

        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
