using System;
using System.Collections;
using System.Collections.Generic;

namespace LowKode.Core.LOS
{

    /// <summary>
    /// 
    /// LosObjectAdapter is a proxy that represents objects outside of the LOS object system.
    /// That is, LOS presents a object-oriented API to it's users, but internally LOS saves 
    /// it's data in tables and such.  So, when the user selects data from a LOS object system 
    /// a proxy is created by LOS that the user can use to access that object's data.
    /// 
    /// A LOS proxy also tracks changes in order to efficiently saved a mutated object tree to a new branch in LOS.
    /// 
    /// Castle.Core.DictionaryAdapter is used to adapt LosObjectAdapter to a specific Type interface.
    /// Property get/sets on the Type are translated by Castle into Dictionary methods calls.
    /// LosObjectAdapter translates gets into calls to a LOS object system to fetch the associated data.
    /// LosObjectAdapter tracks sets, when the associated object tree is saved property changes are persisted to 
    /// the object system.
    /// 
    /// </summary>
    class LosObjectAdapter : IDictionary<string, object>
    {
        Dictionary<string, object> _values = new Dictionary<string, object>();

        public object this[string key] { 
            get => ((IDictionary<string, object>)_values)[key]; 
            set => ((IDictionary<string, object>)_values)[key] = value; 
        }

        public ICollection<string> Keys => ((IDictionary<string, object>)_values).Keys;

        public ICollection<object> Values => ((IDictionary<string, object>)_values).Values;

        public int Count => ((IDictionary<string, object>)_values).Count;

        public bool IsReadOnly => ((IDictionary<string, object>)_values).IsReadOnly;

        public void Add(string key, object value)
        {
            ((IDictionary<string, object>)_values).Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            ((IDictionary<string, object>)_values).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<string, object>)_values).Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ((IDictionary<string, object>)_values).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, object>)_values).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((IDictionary<string, object>)_values).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return ((IDictionary<string, object>)_values).GetEnumerator();
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, object>)_values).Remove(key);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return ((IDictionary<string, object>)_values).Remove(item);
        }

        public bool TryGetValue(string key, out object value)
        {
            return ((IDictionary<string, object>)_values).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<string, object>)_values).GetEnumerator();
        }
    }
}
