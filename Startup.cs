using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            // services.AddTransient<IDataAccess<Book>, BookDataAccess>();
            
            #region EntityFrameworkCore Code
            
            var databaseSection = Configuration.GetSection("database");
            Homemade.Configuration.Database dbConfig = new Homemade.Configuration.Database();
            ConfigurationBinder.Bind(databaseSection, dbConfig);

            string dbConnStr = dbConfig.ToString();

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<LibraryDbContext>(options => options.UseSqlServer(dbConnStr));
            services.AddScoped<IDataAccess<Book>, BookDataAccessEF>();
            
            #endregion

            // Setup Services
            services.AddScoped<ILibrary, Library>();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
    
}