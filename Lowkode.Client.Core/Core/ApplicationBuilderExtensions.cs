using Lowkode.Client.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// NOTE:  Adding my own classes to a third-party module seems wrong, but 
/// [the ASP.NET Core documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0) 
/// recommends putting extension mechanisms in the Microsoft.Extensions.DependencyInjection namespace.
/// </summary>
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddLowkodeClient<TProvider>(this IServiceCollection services, TProvider openApiProvider)
            where TProvider : IOpenApiProvider
        {
            services.AddSingleton<IOpenApiProvider>(openApiProvider);
            services.AddSingleton<IPartProvider, DefaultPartProvider>();
            //services.AddSingleton<ILowkodeContext, MetadataProvider>();
        }
    }
}

