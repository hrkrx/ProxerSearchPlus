using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProxerSearchPlus.Caching;
using ProxerSearchPlus.Caching.Database.MongoDB;
using ProxerSearchPlus.Controller.Proxer.v1;
using ProxerSearchPlus.Model.Proxer.v1;

namespace ProxerSearchPlus
{
    // this class is for testing purposes so that a browser is not needed for simple experimentation
    class Program
    {
        static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureKestrel((context, options) =>
                {
                    // Set properties and call methods on options
                })
                .Build();
            host.Run();

            #region old test code
            // var db = new MongoDBConnector();
            // var client = ApiClient.GetInstance();
            // var apiKey = File.ReadAllText("api.key");
            // client.ApiKey = apiKey;
            // client.ApiUserAgent = "DotNetCoreApiClientLtP";
            // var result = client.Search("OnePunch").GetAwaiter().GetResult();
            // var entries = result.data.OrderByDescending(x => x.rate_sum / (x.rate_count == 0 ? 1 : x.rate_count));
            
            // var fullEntry = client.GetFullEntry(entries.First().id).GetAwaiter().GetResult();

            // Console.WriteLine(fullEntry);
            
            // // CachingController.CacheAllCacheableProperties(fullEntry.data, fullEntry.data.id);

            // fullEntry = client.GetFullEntry(entries.First().id).GetAwaiter().GetResult();

            // // CachingController.PopulateEntryFromCache(data, data.id);

            // Console.WriteLine(fullEntry);

            // // db.Put(data);
            // // var test = db.Get(data.id, data.GetType());
            // // foreach (var item in test)
            // // {
            // //     Console.WriteLine(item);
            // // }
            #endregion
        }
    }
    internal class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, IConfiguration config, 
            ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                // Development service configuration

                logger.LogInformation("Development environment");
            }
            else
            {
                // Non-development service configuration

                logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            // Configuration is available during startup.
            // Examples:
            //   _config["key"]
            //   _config["subsection:suboption1"]
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}