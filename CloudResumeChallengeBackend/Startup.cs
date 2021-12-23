using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CloudResumeChallengeBackend.Repository;
using System.IO;

namespace CloudResumeChallengeBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            

            var cs = Environment.GetEnvironmentVariable("ConnectionString");
            services.AddControllers();
            services.AddSingleton<VisitorsRepository>(_ => new VisitorsRepository(cs));
            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();

                
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
               options => options.WithOrigins("https://lightwaves.me").AllowAnyMethod().AllowAnyHeader()
           );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                
            });
            

        }
    }
}
