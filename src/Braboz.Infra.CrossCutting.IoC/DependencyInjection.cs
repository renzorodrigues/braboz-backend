﻿using System.Text.Json.Serialization;
using Braboz.Application.Products.CQS.Queries;
using Braboz.Core.Interfaces;
using Braboz.Core.Middlewares;
using Braboz.Core.Settings;
using Braboz.Infra.Services.HttpClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Braboz.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            services.AddHttpClient();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Braboz.API", Version = "v1" });
            });

            var httpClientSettings = new HttpClientSettings();
            configuration.Bind("HttpClientSettings", httpClientSettings);
            services.AddSingleton(httpClientSettings);

            services.AddScoped<ValidationMiddleware>();

            // SERVICES
            services.AddScoped<IHttpClient, HttpClientFactory>();

            // MEDIATOR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetAllUsersQuery)));

            return services;
        }
    }
}
