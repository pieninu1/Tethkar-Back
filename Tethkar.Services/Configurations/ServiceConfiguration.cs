using Microsoft.Extensions.DependencyInjection;
using Tethkar.Services.IService;
using Tethkar.Services.Service;

namespace Tethkar.Services.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IEventService, EventService>();
        //services.AddScoped<ITicketTypeService, TicketTypeService>();
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<IPaymentMethodService, PaymentMethodService>();
        //services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}
