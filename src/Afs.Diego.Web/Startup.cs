using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Afs.Diego.Data.Repository;
using Afs.Diego.Data.SqlServer.Repository;
using Afs.Diego.Web.Services.ApiRequestServices;
using System;
using Afs.Diego.Data.AppSettings;
using Afs.Diego.Common.TypeMapping;
using Afs.Diego.Web.AutoMappingConfiguration;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Reflection;
using Afs.Diego.Data.SqlServer.Storage.EF;
using Microsoft.EntityFrameworkCore;

namespace Afs.Diego.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //Add EF services
            services.AddDbContext<AfsDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationsAssembly));
            });

            // Add framework services.
            services.AddMvc();

            ConfigureAutoMapper(services);
            BootstrapAppConfiguration(services);
            BootstrapServices(services);
            BootstrapRepositories(services);
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddSingleton<IAutoMapper, AutoMapperAdapter>(); //service to inject for mapping

            //type configurators for each conversion
            services.AddSingleton<IAutoMapperTypeConfigurator, ApiRequestEntityToApiRequestTypeConfigurator>();
        }

        private void BootstrapAppConfiguration(IServiceCollection services)
        {
            services.Configure<MashapeOptions>(Configuration.GetSection("Mashape"));
        }

        private void BootstrapServices(IServiceCollection services)
        {
            services.AddScoped<IApiRequestService, ApiRequestService>();
        }

        private void BootstrapRepositories(IServiceCollection services)
        {
            services.AddScoped<IApiRequestRepository, ApiRequestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, ILoggerFactory loggerFactory,
            AfsDbContext context,
            IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //Plug AutoMapper in pipeline
            Mapper.Initialize(config =>
            {
                autoMapperTypeConfigurations.ToList()
                    .ForEach(x => x.Configure(config));
            });
            Mapper.Configuration.AssertConfigurationIsValid();

            // Apply Migrations automatically
            context.Database.Migrate();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
