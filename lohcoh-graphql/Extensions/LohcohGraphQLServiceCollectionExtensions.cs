using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcoh.GraphQL
{
    public static class LohcohGraphQLServiceCollectionExtensions
    {
        public static IServiceCollection AddLohcohGraphQL(this IServiceCollection services, Action<LohcohGraphQLServiceBuilder> setupAction = null)
        {
            return services;
        }
    }
}
