using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Homemade.Services;
using Homemade.DataAccess;
using Homemade.DataAccess.EntityFramework;
using Homemade.Models;

namespace Homemade
{
    public class Startup {

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("app.json")
                                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            // Setup DataAccess
            // services.AddSingleton<IDataAccess<Book>, BookDataAccess>();
            
            #region EntityFrameworkCore Code
            
            var databaseSection = Configuration.GetSection("database");
            Homemade.Configuration.Database dbConfig = new Homemade.Configuration.Database();
            ConfigurationBinder.Bind(databaseSection, dbConfig);

            string dbConnStr = dbConfig.ToString();
            
            services.AddDbContext<LibraryDbContext>(options => options.UseMySQL(dbConnStr));
            services.AddScoped<IDataAccess<Book>, BookDataAccessEF>();
            
            #endregion

            // Setup Services
            services.AddScoped<ILibrary, Library>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}");
            });
            // Uses the wwwroot folder for all static files
            app.UseStaticFiles();
            // Allow node modules to show on '/libs' web root
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")
                ),
                RequestPath = new PathString("/libs")
            });
        }
    }
    
}