using AutoMapper;
using Core.Mapping;

namespace Api.Extensions;

public static class AutoMapperConfigurations
{
    public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;

    }
}