using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Lohcode.DDD.Classic.Implementation;
using Lohcode.Domain;
using Lohcode.ApplicationAPI.GraphQL;

namespace Lohcode.eShopOnWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.UseLohCodeDDDClassicApplication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureShopOnWebApplication(app);

        }

        /// <summary>
        /// Assemble the eShopOnWeb application
        /// </summary>
        private void ConfigureShopOnWebApplication(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;

            // Configure the GraphQL service...
            var application = serviceProvider.GetRequiredService<IApplication>();
            var graphQL = serviceProvider.GetRequiredService<GraphQLApplicationAPI>();
            graphQL.AddAllApplicationServices(application.Services);
        }
    }
}
