using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LowKodeStartupExtensions
    {
        public static void AddLowKode(this IServiceCollection services, Action<ILowKodeConfigurationService> config)
        {
            // TODO : Unimplemented
        }
    }
}
