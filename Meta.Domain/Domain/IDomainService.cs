using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Meta.Domain
{
    /// <summary>
    /// Domain service implementations must 
    /// 
    /// A Domain Service only provides methods for mutating domain objects.
    /// A Domain Service does not provide any query methods, that's what Repositories are for.
    /// </summary>
    /// <typeparam name="TImplementationType">The C# type that implements the service</typeparam>
    public interface IDomainService<TImplementationType> 
    {
        Type ServiceType { get; }
    }
}
