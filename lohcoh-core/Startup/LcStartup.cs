using Lohcoh.Core.ContributionProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core.Startup
{
    class LcStartup
    {
        private static ISet<Type> ALL_MODULES_TYPES = new HashSet<Type>();

        public LcStartup()
        {
        }

        public void ConfigureServices<TApplicationModule>(IServiceCollection services) 
        {
            DiscoverAndRegisterModules<TApplicationModule>(services);
            DiscoverAndRegisterServiceProviders(services);
        }

        internal static void InitializeModule(LcModule lcModule)
        {
            // populate 
            throw new NotImplementedException();
        }

        static void DiscoverAndRegisterModules<TApplicationModule>(IServiceCollection services)
        {
            ALL_MODULES_TYPES.Add(typeof(LcCoreModule));
            ALL_MODULES_TYPES.Add(typeof(TApplicationModule));


            var dependencies= DiscoverDependencies(typeof(TApplicationModule));
            while (0 < dependencies.Count)
            {
                var dependency= dependencies[0];
                dependencies.RemoveAt(0);

                if (!ALL_MODULES_TYPES.Contains(dependency))
                {
                    ALL_MODULES_TYPES.Add(dependency);

                    var children= DiscoverDependencies(dependency);
                    foreach (var c in children)
                    {
                        if (!ALL_MODULES_TYPES.Contains(c))
                            dependencies.Add(c);
                    }
                }
            }

            foreach(var t in ALL_MODULES_TYPES)
            {
                services.AddSingleton(t);
            }
        }

        static void DiscoverAndRegisterServiceProviders(IServiceCollection services)
        {
            var serviceProvider= new ProvidesAttributeHandler();
            foreach (var moduleType in ALL_MODULES_TYPES)
            {
                serviceProvider.RegisterServiceProviders(services, moduleType);
            }
        }

        internal static List<Type> DiscoverDependencies(Type moduleType)
        {
            var dependencies= new List<Type>();
            var dependsOn= moduleType.GetCustomAttributes(typeof(DependsOnAttribute), true);
            foreach (var attribute in dependsOn)
            {
                dependencies.Add((attribute as DependsOnAttribute).ModuleType);
            }
            return dependencies;
        }

        public void Startup(IApplicationBuilder app, Type applicationModuleType)
        {
            var applicationModule= app.ApplicationServices.GetRequiredService(applicationModuleType) as LcModule;

            // populate the DependsOn property of all the modules before proceeding
            var moduleTypes= new List<Type>(ALL_MODULES_TYPES);
            var allModules= new HashSet<LcModule>();
            foreach(var moduleType in moduleTypes)
            {
                var dependencies = DiscoverDependencies(moduleType);

                var dependsOn = new List<LcModule>();
                foreach (var dependentType in dependencies)
                {
                    var dependentModule = app.ApplicationServices.GetRequiredService(dependentType) as LcModule;
                    dependsOn.Add(dependentModule);
                }

                var module= app.ApplicationServices.GetRequiredService(moduleType) as LcModule;
                module.DependsOn= dependsOn;
                allModules.Add(module);
            }
            var core = app.ApplicationServices.GetRequiredService<LcCoreModule>();
            allModules.Add(core);
            core.AllModules= allModules;

            applicationModule.Start();
        }
    }
}
