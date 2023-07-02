using Das.Application.Interfaces;
using Das.Application.ResidentialProperties;
using Das.Data.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Das.Data;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureData(this IServiceCollection services) {
        services.AddSingleton<IDasDbContext, DasDbContext>();

        services.AddScoped<IResidentialPropertyRepository, ResidentialPropertyRepository>();


        return services;
    }
}



