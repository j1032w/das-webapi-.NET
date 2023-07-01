using Das.Application.Interfaces;
using Das.Application.ResidentialProperties;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Das.Data;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IDasDbContext, DasDbContext>();

        services.AddScoped<IResidentialPropertyRepository, IResidentialPropertyRepository>();


        return services;
    }
}
