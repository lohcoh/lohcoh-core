using System;
using System.Collections.Generic;
using System.Linq;

namespace LowKode.Core.LOS
{
    /**
     * Maintains a tree of value revisions
     */
    class PropertyStore
    {

        SortedDictionary<int, object> values = new SortedDictionary<int, object>();

        internal void AddValue(RevisionTag revision, object value)
        {
            if (values.ContainsKey(revision))
                throw new Exception("Property already Added");
            values.Add(revision, value);
        }
        internal void UpdateValue(RevisionTag revision, object value)
        {
            values[revision]= value;
        }

        internal object GetValue(RevisionTag revision)
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
