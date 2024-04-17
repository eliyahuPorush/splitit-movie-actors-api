using Domain.Models.Configuration;

namespace Api.Extensions;

public static class AppConfigurations
{
    public static IServiceCollection AddConfigurationsModels(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<ActorsSourceConfig>(options => configuration.GetSection("ActorsSource").Bind(options));

        return services;
    }
}