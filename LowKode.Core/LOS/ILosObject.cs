using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
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
        /// Returns a proxy that implements objectInterface.
        /// The proxy is used to populate the values defined by <paramref name="objectInterface">objectInterface</paramref>.
        /// </summary>
        public object Put(string propertyName, Type objectInterface);

        public ILosObject Put<TProperty>(Action<TProperty> init) { 
            var o= (TProperty)Put(typeof(TProperty).FullName, typeof(TProperty));
            init(o);
            return this;
        }

        /// <summary>
        /// Returns a proxy that provides access to the type stored in the <paramref name="propertyName"/> entry of this instance.
        /// </summary>
        public object Get(string propertyName);
        public TProperty Get<TProperty>(string propertyName) => (TProperty)Get(propertyName);
        public TProperty Get<TProperty>() => Get<TProperty>(typeof(TProperty).FullName);
        public ILosObject Get<TProperty>(Action<TProperty> init)
        {
            var o = Get<TProperty>(typeof(TProperty).FullName);
            init(o);
            return this;
        }

        public void Remove(string propertyName);
    }

}
