using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pokemon.Application;
using Pokemon.Integrations.PokeApi.Client;

namespace Pokemon.Integrations.PokeApi.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPokeApiClient(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<PokeApiOptions>(
                config.GetSection("ExternalApis:PokeApiOptions"));

            services.AddHttpClient<IPokemonProvider, PokeApiClient>((sp, http) =>
            {
                var options = sp.GetRequiredService<IOptions<PokeApiOptions>>().Value;
                http.BaseAddress = new Uri(options.BaseUrl);
                http.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            });

            return services;
        }
    }
}
