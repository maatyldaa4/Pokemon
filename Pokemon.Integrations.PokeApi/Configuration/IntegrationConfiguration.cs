using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.Provider;
using Pokemon.ClientWrapper.Configuration;
using Pokemon.Integrations.PokeApi.Client;

namespace Pokemon.Integrations.PokeApi.Configuration
{
    public static class IntegrationConfiguration
    {
        public static IServiceCollection AddIntegrationPokeApi(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<PokeApiOptions>(
                config.GetSection("ExternalApis:PokeApiOptions"));

            services.AddClientWrapper<PokeApiOptions>();
            services.AddScoped<IPokemonProvider, PokeApiClient>();

            return services;
        }
    }
}
