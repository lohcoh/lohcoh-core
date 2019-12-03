using System;
using System.Threading.Tasks;

namespace Lohcode.DDD
{
    /// <summary>
    /// A Fixture Provider populates persistent storage with default data
    /// 
    /// Fixture implementations are contributed by developers.
    /// Fixture classes must be marked with this interface.
    /// 
    /// </summary>
    public interface IFixtureProvider
    {
        Task Seed<TContext>(TContext dbContext);

    }


}
