using System;
using System.Threading.Tasks;

namespace Meta.Domain
{
    /// <summary>
    /// Populates Repositories with default data
    /// </summary>
    public interface IFixtureProvider
    {
        Task Seed<TContext>(TContext dbContext);

    }
}
