using AirportDistanceMeter.Infrastructure;
using Common.Infrastructure.Tools.Filters;
using Common.Infrastructure.Tools.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace AirportDistanceMeter.WebHost
{
    public class Startup
    {
        private const string _swaggerDocName = "Airport Distance Meter";
        private readonly string _swaggerCurrentVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var mvcBuilder = services.AddControllers(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(
                        new SlugifyParameterTransformer()));
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                })
                .AddNewtonsoftJson();

            services.AddAirportDistanceMeter(mvcBuilder);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_swaggerCurrentVersion,
                    new OpenApiInfo { Title = _swaggerDocName, Version = _swaggerCurrentVersion });
                //options.CustomSchemaIds(type => type.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DocumentTitle = $"Swagger UI - {_swaggerDocName}";
                    options.SwaggerEndpoint($"/swagger/{_swaggerCurrentVersion}/swagger.json",
                    $"{_swaggerDocName} {_swaggerCurrentVersion}");
                });
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
