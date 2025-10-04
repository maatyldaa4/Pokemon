using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application;
using Pokemon.Integrations.PokeApi.HttpClient;

namespace Pokemon.Integrations.PokeApi.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPokeApiClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IPokemonProvider, PokeApiClient>((http) =>
            {
                var options = config.GetSection(nameof(PokeApiOptions)).Get<PokeApiOptions>();
                http.BaseAddress = new Uri(options.BaseUrl);
                http.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            });

            return services;
        }
    }
}
