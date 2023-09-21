using Das.Application.Interfaces;
using Das.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Das.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
    {
        services.AddSingleton<IDbContext, DbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IResidentialPropertyRepository, ResidentialPropertyRepository>();



        return services;
    }
}



