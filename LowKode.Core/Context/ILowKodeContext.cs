using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Context
{
    public interface ILowKodeContext : IExtensibleResource
    {
        ILowKodeContext CreateScope();
    }
}
