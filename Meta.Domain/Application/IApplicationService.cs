
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Lohcode.DDD
{

    /// <summary>
    /// 
    /// Application Services...
    /// - are the interfaces through which Bounded Contexts connect to each other.
    /// - expose a collection of methods for querying and applying mutations.
    /// - are responsible for managing application 
    ///     aspects like authorization, transaction management, and audit logging.
    /// - use Entities and Domain Services 
    /// 
    /// IApplicationService is just a wrapper around a native ASP.NET Core Controller implementation.
    /// Use the implementation type to discover the query and mutation operations provided.
    /// 
    /// Since application services will be used from the client (Blazor), an 
    /// Application Service MUST have an interface and an implemention.
    /// 
    /// Query methods are methods that return IEnumerable<T> or <T> where T : IEntity or T : IDataTransferObject.
    /// All other methods are mutation methods.
    /// 
    /// </summary>
    /// <typeparam name="TInterface">The interfacce provided by the service</typeparam>
    /// <typeparam name="TImplementation">The class that implements the service interface</typeparam>

    public interface IApplicationService<TInterface, TImplementation> : IApplication
    {
        Type InterfaceType { get; }
        Type ImplementationType { get; }


        /// <summary>
        /// Returns the set of methods from the service interface that represent queries
        /// </summary>
        IReadOnlyCollection<MethodInfo> Queries { get; }

        /// <summary>
        /// Returns the set of methods from the service interface that represent mutations
        /// </summary>
        IReadOnlyCollection<MethodInfo> Mutations { get; }

    }

    /// <summary>
    /// marker interface for application services.
    /// </summary>
    public interface IApplicationService {  }
}
