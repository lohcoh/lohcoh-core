using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.Domain
{
    /// <summary>
    /// An Application API is a service that provides a network API for accessing an 
    /// application service, like REST API, GraphQL, or gRPC.
    /// 
    /// Given an Application Service, a Application API can exposes the service to clients 
    /// using the underlying protocol.
    /// 
    /// </summary>
    public interface IApplicationAPI
    {
        /// <summary>
        /// Exposes the given service to clients using the underlying protocol.
        /// </summary>
        void AddApplicationService(IApplicationService service);

        /// <summary>
        /// A convenience method that adds a collection of services
        /// </summary>
        void AddAllApplicationServices(IEnumerable<IApplicationService> services);
    }
}