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
        public ILosRoot Master { get; private set; }

        private Dictionary<int, ObjectInfo> objectLookup = new Dictionary<int, ObjectInfo>();
        PropertyStore<LosRoot> Roots { get; } = new PropertyStore<LosRoot>();

        public LosObjectSystem()
        {
            var documentObject = new ObjectInfo(typeof(LosRoot));
            objectLookup.Add(documentObject.Id, documentObject);

            Master = new LosRoot(this, RevisionTag.ROOT, objectId: documentObject.Id);
            Roots.AddValue(Master.Revision, Master);
        }

        internal LosRoot Branch(LosRoot root)
        {
            var rootRevision = root.Revision;
            var rootNode = Roots.GetNode(root.Revision);
            int nextBranchId = rootNode.Children != null ? rootNode.Children.Count : 0;
            var branchRevision = rootRevision.AddBranch(nextBranchId);
            var branch= new LosRoot(this, branchRevision, ((LosRoot)Master).ObjectId);
            Roots.AddValue(branchRevision, branch);
            return branch;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId">The id of the object into which a document is being inserted.  For now, objectId must</param>
        /// <param name="revision">The revision # of the branch</param>
        /// <param name="propertyName"></param>
        /// <param name="documentType"></param>
        /// <param name="document"></param>
        public int Insert(int objectId, RevisionTag revision, string propertyName, Type documentType)
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
        public void Update(int objectId, RevisionTag revision, string propertyName, object value)
        {
            ObjectInfo targetObject;
            if (!objectLookup.TryGetValue(objectId, out targetObject))
                throw new Exception("Unknown objectId:" + objectId);

            // add object as property to target object
            PropertyStore propertyStore;
            if (!targetObject.PropertyLookup.TryGetValue(propertyName, out propertyStore))
            {
                propertyStore = new PropertyStore();                
                targetObject.PropertyLookup.Add(propertyName, propertyStore);
            }
            propertyStore.UpdateValue(revision, value);
           
        }

        internal void Prune(LosRoot losRoot)
        {
            Roots.RemoveValue(losRoot.Revision);
        }


        public void Remove(int objectId, RevisionTag revision, string propertyName)
        {
            ObjectInfo objectInfo;
            if (!objectLookup.TryGetValue(objectId, out objectInfo))
                throw new Exception("Unknown object id: "+objectId);

            PropertyStore propertyStore;
            if (!objectInfo.PropertyLookup.TryGetValue(propertyName, out propertyStore))
                throw new Exception("Object[" + objectId + "] does not have a proiperty named '" + propertyName + "'");

            propertyStore.RemoveValue(revision);
        }

        public object Get(int objectId, RevisionTag revision, string propertyName)
        {
            ObjectInfo objectInfo;
            if (!objectLookup.TryGetValue(objectId, out objectInfo))
                throw new Exception("Unknown object id: " + objectId);

            PropertyStore propertyStore;
            if (!objectInfo.PropertyLookup.TryGetValue(propertyName, out propertyStore))
                throw new Exception("Object[" + objectId + "] does not have a property named '" + propertyName + "'");

            object value= propertyStore.GetValue(revision);
            if (!(value is ObjectInfo))
                return value;

            // The value being retrieved is a nested object, return a proxy.
            var vobjectInfo= value as ObjectInfo;
            return vobjectInfo.CreateProxy(
                (propertyName) => Get(vobjectInfo.Id, revision, propertyName),
                (propertyName, value) => { Update(vobjectInfo.Id, revision, propertyName, value); });
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

        internal object CreateProxy(Func<string, object> getHandler, Action<string, object> setHandler)
        {
            return new ProxyGenerator().CreateClassProxy(
                DocumentType, 
                new IInterceptor[] { 
                    new ObjectIntercetor(getHandler, setHandler) 
                }); 
        }

        class ObjectIntercetor : IInterceptor
        {
            Func<string, object> getHandler;
            Action<string, object> setHandler;
            public ObjectIntercetor(Func<string, object> getHandler, Action<string, object> setHandler)
            {
                this.getHandler = getHandler;
                this.setHandler = setHandler;
            }
            public void Intercept(IInvocation invocation)
            {
                if (invocation.Method.Name.StartsWith("set"))
                {
                    setHandler(invocation.Method.Name.Substring(4), invocation.Arguments[0]);
                }
                else if (invocation.Method.Name.StartsWith("get"))
                {
                    invocation.ReturnValue = getHandler(invocation.Method.Name.Substring(4));
                }
                //invocation.Proceed();
            }
        }
    }
}
