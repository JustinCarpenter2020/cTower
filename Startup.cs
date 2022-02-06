using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using cTower.Repositories;
using cTower.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace cTower
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

                    services.AddCors(options =>
        {
          options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder.WithOrigins(new string[]{
                            "http://localhost:4200",
                            "http://localhost:4201"
                          })
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
              });
        });

            services.AddControllers();

            services.AddTransient<TowerEventService>();
            services.AddTransient<TowerEventRepo>();
            
            services.AddScoped<IDbConnection>(x => CreateDbConnection());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "cTower", Version = "v1" });
            });


    

        }


         private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration["db:gearhost"];
      return new MySqlConnection(connectionString);
    }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "cTower v1"));
                 app.UseCors("CorsDevPolicy");
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
