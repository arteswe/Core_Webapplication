using System;
using BloodpressureApp.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace BlodpressureApp
{
    public class Startup
    {
        public static IConfigurationRoot Configuration; 
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()))
            .AddJsonOptions(o =>
             {
                 if (o.SerializerSettings.ContractResolver != null)
                 {
                     var castedResolver = o.SerializerSettings.ContractResolver
                         as DefaultContractResolver;
                     castedResolver.NamingStrategy = null;
                 }
             });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:60196"));
            });
            //var connectionString = @"Data Source=AM;Initial Catalog=Bloodpressure;Integrated Security=True";

            var connectionString = Startup.Configuration["connectionStrings:bloodpressureDbConnection"];
            var x = services.AddDbContext<BloodPressureInfoContext>(o => o.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
                    
            app.UseMvc();
            app.UseCors("CorsSpecificOrigin");

        }
    }
}
