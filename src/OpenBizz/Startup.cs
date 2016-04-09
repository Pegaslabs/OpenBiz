using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using OpenBiz.Models;
using OpenBiz.Models.Core.Repositories;
using OpenBiz.Models.Persistence.Repositories;
using AutoMapper;
using OpenBiz.ViewModels;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileProviders;
using Newtonsoft.Json.Serialization;

namespace OpenBiz
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        private MapperConfiguration _mapperConfiguration { get; set; }

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelMapping.VMtoM.ViewModelToModel());
                cfg.AddProfile(new ModelMapping.MtoVM.ModelToViewModel());
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddMvc(config =>
            {
#if !DEBUG
        config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
      .AddJsonOptions(opt =>
      {
          opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      });

            //Adding Entity Framework 7 (ORM) with support for Sql Server.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<SCMSContext>();

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 5;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = true;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonLetterOrDigit = false;
                config.Lockout.MaxFailedAccessAttempts = 5;
                config.Lockout.DefaultLockoutTimeSpan = new TimeSpan(23, 59, 59);
                config.Cookies.ApplicationCookie.LoginPath = new PathString("/Auth/Login");
            })
            .AddEntityFrameworkStores<SCMSContext>();

            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRepository<Warehouse>, DBRepository<Warehouse>>();
            services.AddScoped<IRepository<ProductCategory>, DBRepository<ProductCategory>>();
            services.AddScoped<IRepository<ProductImage>, DBRepository<ProductImage>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //ILoggerProvider loggerprovider =new loggerp
#if DEBUG
            loggerFactory.AddDebug(LogLevel.Debug);
            app.UseDeveloperExceptionPage();
#endif
            
            app.UseIISPlatformHandler();
            app.UseFileServer(new FileServerOptions
            {
                //FileProvider = new PhysicalFileProvider(@"E:\OpenBiz\src\OpenBiz\wwwroot"),
                //RequestPath = new PathString(""),
            });
            app.UseIdentity();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{Param?}",
                    defaults: new { controller = "Dashboard", action = "Index" }
                    );
            }
                );

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
