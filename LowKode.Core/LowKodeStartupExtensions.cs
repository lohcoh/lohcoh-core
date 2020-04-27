using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LowKodeStartupExtensions
    {
        public static void AddLowKode(this IServiceCollection services, Action<ILowKodeMetaRepository> config)
        {

        }
    }
}
