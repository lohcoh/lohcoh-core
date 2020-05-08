using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// ILowKodeMetaService is a bare-bones but extensible metadata API.
    /// The service is a collection of metadata objects, that is, objects that hold metadata.
    /// This API is meant to be used by components, for generating and assembling UI elements, and only provides methods for retrieving data.  
    /// This API needs to be extensible and discoverable, that is, this API needs to support scenarios where third-parties add 
    /// metadata during startup (extensible) and then use that metadata later, in rules (discoverable).  
    /// And this API should provide type-safe ways to do those things, when possible.  
    /// To satisfy the these requirements, ILowKodeMetaService stores 'root' metadata objects by type.  
    /// 
    /// To access metadata you must know the type of structure that contains the metadata of interest.  
    /// Metadata providers must document these Types in order for developers to use the provided metadata in rules.
    /// Among other metadata root types, LowKode provides ITypeMetadata<TType>, which contains metadata about the Type denoted by the type parameter TType.  
    /// 
    /// Use the Find method to retrieve all the metadata objects of a given type stored in the service.
    /// If the metedata type of interest is a singletom then you can use the First method.
    /// For example, use LowKode's ITypeMetadata type to retrieve metadata about the 'StarShip' class, like so...
    ///     > ITypeMetadata<StarShip> starshipMetadata=  metadataService.First<ITypeMetadata<StarShip>)();
    ///     
    /// Another example... suppose you want to create a metadata-driven list of available reports.  
    /// You would create a class for holding the report list...
    ///     ```
    ///     public interface IAvailableReports : IReadOnlyList<string> {  }
    ///     public class AvailableReports : ReadOnlyList<string>, IAvailableReports { }
    ///     ````
    /// then, an instance of this class is added to the metadata service at startup...
    /// ```
    ///     services.AddLowKode(configuration => {
    ///         configuration.AddMetadataRoot<IAvailableReports>(new AvailableReports() {
    ///             "Customer List",
    ///             "Profit Report",
    ///             "Pending Lawsuits"
    ///         });
    ///     });
    /// ````
    /// finally, a Blazor component retrieves the list from the metadata service for rendering purposes...
    ///     ```
    ///     AvailableReports reportList= lkMetaService.First<IAvailableReports>();
    ///     ```
    /// You can discover the types of all available 'root' metadata objects via the Roots property.
    /// 
    /// This interface is meant to be used by components, for generating and assembling UI elements, and only provides methods for accessing data.  
    /// Metadata is meant to be invariant during the lifetime of the application...
    /// - the only way to add metadata objects to the service is via the ILowKodeMetaRepository API, during Startup configuration.  
    /// - Root objects need not be immutable but they should be registered with an immutable type.  
    ///   Changes to root objects will cause the LowKode metadata service to misbehave.
    ///   
    /// Currently, LowKode only provides a client-side metadata service.  
    /// That is, metadata is initialized using only metadata and rules registered when the client application Startup.
    /// In the future it's possible that there will be web service implementation of this interface, so metadata root types should be Serializable.
    /// 
    /// </summary>
    public interface ILowKodeMetaService 
    {
        IEnumerable<Type> Roots { get; }

        IEnumerable<T> Find<T>();
        IEnumerable<object> Find(Type modelType);
        T First<T>();
        object First(Type modelType);

        bool ContainsRoot<T>() where T : Type;
        bool ContainsRoot(Type modeltype);

        bool TryGetValue<T, V>(T key, out V value) where T : Type where V : IEnumerable<T>;
    }
}
