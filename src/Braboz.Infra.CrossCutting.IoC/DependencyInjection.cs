using System.Text.Json.Serialization;
using Braboz.Application.Products.CQS.Queries;
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

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(cfg => 
            { 
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Braboz.API", Version = "v1" });            
            });

            // MEDIATOR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetAllUsersQuery)));

            return services;
        }
    }
}
