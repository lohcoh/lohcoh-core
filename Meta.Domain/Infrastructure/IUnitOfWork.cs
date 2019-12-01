using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.Domain
{
    /// <summary>
    /// Application Services execute thier business functions within a unit of work.
    /// At runtime, a UnitOfWork is backed by an instance of DbContext.
    /// </summary>
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}
