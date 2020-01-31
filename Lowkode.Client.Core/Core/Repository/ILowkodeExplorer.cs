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
    public interface ILowkodeExplorer 
    {
        IModelMetadata MetadataForType<TModel>();
    }
}
