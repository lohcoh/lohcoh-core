using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public class LosObjectSystem : ILosObjectSystem
    {
        public ILosRoot Master { get; private set; }

        private Dictionary<int, Dictionary<string, PropertyStore>> objectLookup = new Dictionary<int, Dictionary<string, PropertyStore>>();

        public LosObjectSystem()
        {
            Dictionary<string, PropertyStore> propertyLookup = new Dictionary<string, PropertyStore>();
            int newObjectId = propertyLookup.GetHashCode();
            objectLookup.Add(newObjectId, propertyLookup);

            Master = new LosRoot(this, revision:0, objectId:newObjectId);
        }

        public object Add(int objectId, int revision, string propertyName, Type tProperty)
        {
            // create new object
            int newObjectId;
            {
                Dictionary<string, PropertyStore> propertyLookup = new Dictionary<string, PropertyStore>();
                newObjectId = propertyLookup.GetHashCode();
                objectLookup.Add(newObjectId, propertyLookup);
            }

            // add new object to specified object and property name
            {
                PropertyStore propertyStore = new PropertyStore();
                propertyStore.AddValue(revision, newObjectId);

                var propertyLookup = GetPropertyLookup(objectId);
                propertyLookup.Add(propertyName, propertyStore);
            }

            return LosObject.GetObjectProxy(tProperty, this, revision, newObjectId);
        }

        public void Remove(int objectId, int revision, string propertyName)
        {
            PropertyStore propertyStore = GetPropertyStore(objectId, propertyName);

            propertyStore.RemoveValue(revision);
        }

        public object Get(int objectId, int revision, string propertyName)
        {
            PropertyStore propertyStore = GetPropertyStore(objectId, propertyName);

            return propertyStore.GetValue(revision);
        }

        private Dictionary<string, PropertyStore> GetPropertyLookup(int objectId)
        {
            Dictionary<string, PropertyStore> propertyLookup;
            if (!this.objectLookup.TryGetValue(objectId, out propertyLookup))
                throw new Exception("Unknown object id: " + objectId);
            return propertyLookup;
        }

        private PropertyStore GetPropertyStore(int objectId, string propertyName)
        {
            Dictionary<string, PropertyStore> propertyLookup= GetPropertyLookup(objectId);

            PropertyStore propertyStore;
            if (!propertyLookup.TryGetValue(propertyName, out propertyStore))
                throw new Exception("Unknow property: " + propertyName);
            return propertyStore;
        }
    }
}
