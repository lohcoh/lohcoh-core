using Meta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Lohcode.ApplicationAPI.GraphQL
{
    public class GraphQLApplicationAPI : IApplicationAPI
    {
        public void AddAllApplicationServices(IEnumerable<IApplicationService> services)
        {
            foreach (var service in services)
                AddApplicationService(service);
        }

        public void AddApplicationService(IApplicationService service)
        {
            throw new NotImplementedException();
        }
    }
}
