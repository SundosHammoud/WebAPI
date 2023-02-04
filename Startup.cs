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
using Microsoft.AspNetCore.Authentication;
using ceconsoftAPI.Service;
using ceconsoftAPI.Domain;
using Microsoft.EntityFrameworkCore;
using ceconsoftAPI.Infrastructure;
using AutoMapper;

namespace ceconsoftAPI
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
            ConfigureControllers(services);
            ConfigureDBConnetion(services);
            ConfigureContainer(services);
            ConfigureAutoMapper(services);
            
            
        }

        public void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureDBConnetion(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");        
            services.AddDbContext<MyContext>(opt => opt.UseNpgsql(connectionString));
        }

        public void ConfigureContainer(IServiceCollection services)
        {
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        }

        public void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
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
        }
    }
}
