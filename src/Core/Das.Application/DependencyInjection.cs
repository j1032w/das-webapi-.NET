using Das.Application.ResidentialProperties;
using Microsoft.Extensions.DependencyInjection;

namespace Das.Application; 

public static class DependencyInjection {
    public static IServiceCollection AddCoreApplication(this IServiceCollection services) {
        services.AddScoped<IResidentialPropertyService, ResidentialPropertyService>();

        services.AddAutoMapper(typeof(ResidentialPropertyMappingProfile));

        return services;
    }
}
