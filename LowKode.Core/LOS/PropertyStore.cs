using System;
using System.Collections.Generic;
using System.Linq;

namespace LowKode.Core.LOS
{
    class PropertyStore
    {

        SortedDictionary<int, object> values = new SortedDictionary<int, object>();

        internal void AddValue(int revision, object value)
        {
            if (values.ContainsKey(revision))
                throw new Exception("Property already Added");
            values.Add(revision, value);
        }
        internal void UpdateValue(int revision, object value)
        {
            values[revision]= value;
        }

        internal object GetValue(int revision)
        {
            if (values.ContainsKey(revision))
                return values[revision];
            var lastRevision = values.Keys.Last(k => k <= revision);
            if (values.ContainsKey(lastRevision))
                return values[lastRevision];

            return null;
        }

        internal void RemoveValue(int revision)
        {
            values.Remove(revision);
        }
    }

}
