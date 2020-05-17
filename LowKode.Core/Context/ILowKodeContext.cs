using LowKode.Core.Common;

namespace LowKode.Core.Context
{
    public interface ILowKodeContext : IDependencyObject
    {
        ILowKodeContext CreateScope();
    }
}
