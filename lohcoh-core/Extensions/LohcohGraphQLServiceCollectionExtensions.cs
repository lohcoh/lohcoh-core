using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LohcohCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddLohcoh(this IServiceCollection services)
        {
            services.AddSingleton(new Lohcoh.Core.LohcohCoreModule());
            return services;
        }
    }
}
