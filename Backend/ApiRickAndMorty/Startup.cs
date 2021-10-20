using ApiRickAndMorty.Implementaciones;
using ApiRickAndMorty.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty
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

            services.AddHttpClient("RickAndMortyApi", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:RickAndMortyApi"]);
            });

            services.AddScoped<IPersonajeServicio, PersonajeServicio>();
            services.AddScoped<ILocalizacionServicio, LocalizacionServicio>();
            services.AddScoped<IEpisodioServicio, EpisodioServicio>();

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Digevo.Ads API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"ApiRickAndMorty {groupName}",
                    Version = groupName,
                    Description = "ApiRickAndMorty v1",
                    Contact = new OpenApiContact()
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());                
            });
        }
    }
}
