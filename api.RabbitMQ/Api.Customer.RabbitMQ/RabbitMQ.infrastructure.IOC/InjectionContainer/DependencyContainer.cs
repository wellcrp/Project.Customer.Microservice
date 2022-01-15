using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Application;
using RabbitMQ.Application.Interfaces;

namespace RabbitMQ.infrastructure.IOC.InjectionContainer
{
    public static class DependencyContainer
    {
        public static void RegisterApplicationService(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {                    
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });

            service.AddScoped<ICustomer, CustomerApplication>();
        }
    }
}
