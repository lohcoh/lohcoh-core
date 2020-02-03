using System;
using Microsoft.OpenApi.Models;



namespace Lowkode.Client.Core
{
    /// <summary>
    /// The entry point to all lowkode metadata.
    ///
    /// This class provides methods for...
    /// - getting metadata
    /// - adding metadata contributers
    /// - defining 'scope'
    /// </summary>
    public interface IMetadataProvider 
    {
        /// <summary>
        /// Returns metadata associated with the given object.
        /// The For method is meant to be overloaded with many types of model objects.
        /// </summary>
        IModelMetadata For(Type modelType);
    }
}
