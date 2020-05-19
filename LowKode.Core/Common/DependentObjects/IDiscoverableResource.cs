using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{


    /// <summary>
    /// LowKode needs several of its interfaces to be extensible and discoverable.  
    /// That is, these APIs need to support scenarios where third-parties add 
    /// thier own data (extensible), and then later some other party discovers and uses that metadata (discoverable).  
    /// IDiscoverableResource and IExtensibleResource provides a common API for the parts of 
    /// LowKode that need to be extensible, including but not limited to, most of the service interfaces and 
    /// metadata interfaces defined by LowKode.
    /// 
    /// An extensible resource is a collection of 'extensions', indexed by the Type of the extension.
    /// 
    /// This API is intended to be bare-boned, type safe, C# implementation of the Extension Point pattern 
    /// found in may other extensible frameworks.
    /// 
    /// </summary>
    public interface IDiscoverableResource
    {
        /// <summary>
        /// Returns all the types associated with all the values contained in this resource 
        /// </summary>
        IEnumerable<Type> Roots { get; }

        /// <summary>
        /// Returns all the values that were added to the resource using the given root type
        /// </summary>
        IEnumerable<T> Find<T>();
        /// <summary>
        /// Returns all the values that were added to the resource using the given root type
        /// </summary>
        IEnumerable<object> Find(Type root);
        /// <summary>
        /// Returns the first value found that was added to the resource using the given root type
        /// </summary>
        T First<T>();
        /// <summary>
        /// Returns the first value found that was added to the resource using the given root type
        /// </summary>
        object First(Type root);

        /// <summary>
        /// Returns true if this resource conatins a value that was added to the resource using the given root type
        /// </summary>
        bool Contains<T>() where T : Type;
        /// <summary>
        /// Returns true if this resource conatins a value that was added to the resource using the given root type
        /// </summary>
        bool Contains(Type root);

        /// <summary>
        /// Returns all the values that were added to the resource using the given root type
        /// </summary>

        bool TryGetValue<T, V>(T key, out V value) where T : Type where V : IEnumerable<T>;
    }
}
