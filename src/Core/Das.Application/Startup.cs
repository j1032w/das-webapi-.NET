using System.Reflection;
using Das.Application.ResidentialProperties;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Das.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config) {
            services.AddScoped<IResidentialPropertyService, ResidentialPropertyService>();
            
          return services;
        }
    }
}
