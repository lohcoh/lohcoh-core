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

        internal object GetValue(int revision)
        {
            if (values.ContainsKey(revision))
                return values[revision];
            throw new NotImplementedException();
        }

        internal void RemoveValue(int revision)
        {
            values.Remove(revision);
        }
    }
}
