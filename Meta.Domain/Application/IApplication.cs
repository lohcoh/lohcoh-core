using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lohcode.DDD
{
    /// <summary>
    /// An application exposes multiple services to clients.
    /// Those service can be accessable using multiple newtrok APIS like REST, GraphQL, gRPC, etc.
    /// 
    /// IApplication is a singleton.
    /// </summary>
    public interface IApplication
    {
        IReadOnlyCollection<IApplicationService> Services { get; }

        void AddService(IApplicationService applicationService);
        //Task RemoveService(IApplicationService applicationService);
    }
}