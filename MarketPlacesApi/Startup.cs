using MarketPlaces.Entity.Context;
using MarketPlaces.Data.Interfaces;
using MarketPlaces.Data.Services;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using MarketPlaces.Data.Repositories;

namespace MarketPlacesApi
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
         
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketPlacesApi", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddApiVersioning();
            services.AddDbContext<MarketPlacesContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ISeedDataService, SeedDataService>();
            services.AddScoped<IQualificationService,QualificationService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IApplicantCardRepository,ApplicantCardRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<ICardRepository, CardRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketPlacesApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDB(app.ApplicationServices);
        }

        private void InitializeDB(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var _services = scope.ServiceProvider;
                try
                {
                    var context = _services.GetRequiredService<MarketPlacesContext>();
                    var dbInitializer = _services.GetRequiredService<ISeedDataService>();
                    dbInitializer.Initialize(context).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Startup>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
