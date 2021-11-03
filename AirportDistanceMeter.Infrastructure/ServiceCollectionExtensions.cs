using AirportDistanceMeter.Application.Queries.AirportDistanceMeter;
using AirportDistanceMeter.Application.Repositories;
using AirportDistanceMeter.Infrastructure.Abstractions;
using AirportDistanceMeter.Infrastructure.Repositories;
using AirportDistanceMeter.Infrastructure.Services;
using Common.Infrastructure.Tools.Behaviors;
using Common.Infrastructure.Tools.Constants;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace AirportDistanceMeter.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        private static int _retryCount = HttpClientConst.NumberOfAttempts;

        public static IServiceCollection AddAirportDistanceMeter(this IServiceCollection services, IMvcBuilder mvcBuilder)
        {

            mvcBuilder.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining<AirportDistanceMeterQueryValidator>();
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            services.AddTransient<IAirportDistanceMeterQueryRepository, AirportDistanceMeterQueryRepository>();

            services.AddHttpClient("AirportDistanceMeter", option =>
                {
                    option.DefaultRequestHeaders.Add("User-Agent", "AirportDistanceMeter");
                })
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(_retryCount))
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(_retryCount, TimeSpan.FromSeconds(30)));

            services.AddMediatR(typeof(AirportDistanceMeterQuery).Assembly);

            services.AddTransient<IAirportInformationService, CTeleportAirportInfromationProvider>();
            services.AddTransient<IAirportDistanceMeterService, HaversineDistanceMeterProvider>();

            return services;
        }

    }
}
