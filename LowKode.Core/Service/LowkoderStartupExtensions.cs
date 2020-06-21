using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Configuration;
using LowKode.Core.Components;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LowkoderStartupExtensions
    {
        public static void AddLowKode(this IServiceCollection services, Action<ILowkoderConfigurationService> initConfig)
        {
            // TODO : Unimplemented

            var lowkoder = new LowkoderService();
            services.AddSingleton(typeof(ILowkoderService), lowkoder);
            services.AddTransient(typeof(IComponentSite), serviceProvider => lowkoder.CreateComponentSite(serviceProvider));

            using (var config = new LowkoderConfigurationService(lowkoder))
            {
                config.UseDefaultUIKit();
                initConfig(config);
            }
        }
    }
}
