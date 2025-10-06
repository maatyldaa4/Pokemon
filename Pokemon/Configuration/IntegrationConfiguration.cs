using Pokemon.Integrations.PokeApi.Configuration;

namespace Pokemon.Api.Configuration
{
    public static class IntegrationConfiguration
    {
        public static IServiceCollection AddIntegrations(this IServiceCollection services, IConfiguration config)
        {
            services.AddIntegrationPokeApi(config);
            
            return services;
        }
    }
}
