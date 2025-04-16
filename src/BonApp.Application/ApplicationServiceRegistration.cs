using BonApp.Application.Interfaces;
using BonApp.Application.Services;
using BonApp.Domain.Interfaces.Service;
using BonApp.Infrastructure.Data.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BonApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        // services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
