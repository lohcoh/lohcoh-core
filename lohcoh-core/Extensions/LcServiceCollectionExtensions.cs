using Lohcoh.Core;
using Lohcoh.Core.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LcServiceCollectionExtensions
    {
        private static LcStartup __startup= null;
        private static Type __applicationModuleType= null;

        /// <summary>
        /// Configures services.
        /// Among otjher things, discovers all modules and registers them as services.
        /// </summary>
        /// <typeparam name="TApplicationModule">Identifies the topmost module that represents the current application</typeparam>
        public static IServiceCollection AddLohcoh<TApplicationModule>(this IServiceCollection services)
            where TApplicationModule : LcModule
        {
            if (__startup != null)
                throw new LcException("The AddLohcoh method has already been called and may only be called once.");

            __applicationModuleType= typeof(TApplicationModule); // hack, cause we need this in UseLohCode

            __startup = new LcStartup();
            __startup.ConfigureServices<TApplicationModule>(services);
            return services;
        }

        /// <summary>
        /// Starts up the lohcoh application
        /// </summary>
        /// <typeparam name="TModule"></typeparam>
        /// <param name="app"></param>
        public static IApplicationBuilder UseLohCode(this IApplicationBuilder app)
        {
            if (__startup == null)
                throw new LcException("The AddLohcoh method needs to be called before app.UseLohcoh()");
            __startup.Startup(app, __applicationModuleType);
            return app;
        }

        
    }
}
