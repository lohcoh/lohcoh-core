using Lohcode.DDD.Classic.Implementation;
using Meta.Domain;

/// <summary>
/// NOTE:  Adding my own classes to a third-party module seems wrong, but 
/// [the ASP.NET Core documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0) 
/// recommends putting extension mechanisms in the Microsoft.Extensions.DependencyInjection namespace.
/// </summary>
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseLohCodeDDDClassicApplication(this IServiceCollection services)
        {
            services.AddSingleton<IApplication, LohCodeDDDClassicApplication>();
            services.AddSingleton<IApplication, LohCodeDDDClassicApplication>();
        }
    }
}
