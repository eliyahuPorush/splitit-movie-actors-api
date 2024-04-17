using Services;
using Services.Interfaces;

namespace Api.Extensions;

public static class AppServices
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IActorsScrapperService, ActorsScrapperService>();
        services.AddScoped<IActorsService, ActorsService>();
        return services;
    }
}