using Microsoft.Extensions.DependencyInjection;
//using Tethkar.Services.IService;
//using Tethkar.Services.Service;

namespace Tethkar.Services.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IGenreService, GenreService>();
        //services.AddScoped<IMovieService, MovieService>();

        return services;
    }
}