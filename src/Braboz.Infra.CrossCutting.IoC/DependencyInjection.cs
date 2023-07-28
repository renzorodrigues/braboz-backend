using System.Text.Json.Serialization;
using Braboz.Application.Products.CQS.Commands.Invoice;
using Braboz.Application.Products.CQS.Queries;
using Braboz.Application.Services.Interfaces.HttpClient;
using Braboz.Application.Services.Interfaces.Invoice;
using Braboz.Core.Settings;
using Braboz.Infra.Services.HttpClient;
using Braboz.Infra.Services.Invoice;
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

            services.Configure<HttpClientSettings>(configuration.GetSection("HttpClient"));

            // SERVICES
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IHttpClient, HttpClientFactory>();

            // MEDIATOR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetAllUsersQuery)));
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(CreateInvoiceCommand)));

            return services;
        }
    }
}
