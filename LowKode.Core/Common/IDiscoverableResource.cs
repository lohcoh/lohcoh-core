using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// LowKode needs several of its interfaces to be extensible and discoverable.
    /// That is, these APIs need to support scenarios where third-parties add 
    /// thier own data, and then later some other party discovers and uses that metadata (discoverable).  
    /// 
    /// Using labels to identify properties is not a good solution, it's susceptable to namespace collisions.
    /// I have chosen to use Types to identify properties.
    /// 
    /// 
    /// I'm a fan of RDF, this interface is meant to define objects similar to RDF resources.
    /// I understand an RDF resource to be a collection of values indexed by property identifiers, 
    /// where the property identifiers are essentially the name of the associated property type (in RDF, 
    /// properties are types).
    /// 
    /// This API is intended to be a C#, type safe, equivalent of something like an RDF resource.
    /// IDiscoverableResource is a collection of values indexed by thier associated Types.
    /// The types associated with the values contained in a resource are called 'roots'.
    /// IDiscoverableResource provides methods for discovering roots and getting the values associated with roots.
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
