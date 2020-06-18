using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core
{
    /// <summary>
    /// Defines an extensible metadata object
    /// </summary>
    public interface ILosObject
    {
        /// <summary>
        /// Adds a node to a LOS object tree, the new node is assigned the given node type.
        /// 
        /// Creates an entry named <paramref name="propertyName"/> in the tree node represented by this instance.
        /// The entry is assigned the <paramref name="objectInterface"/> type.
        /// </summary>
        public void Put(string propertyName, Type objectInterface, object value);

        public void Put<TProperty>(TProperty value) => Put(typeof(TProperty).FullName, typeof(TProperty), value);

        /// <summary>
        /// Returns a proxy that provides access to the type stored in the <paramref name="propertyName"/> entry of this instance.
        /// </summary>
        public object Get(string propertyName);
        public TProperty Get<TProperty>(string propertyName) => (TProperty)Get(propertyName);
        public TProperty Get<TProperty>() => Get<TProperty>(typeof(TProperty).FullName);

        public void Remove(string propertyName);
    }

}
