using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.Services;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Application.Configuration
{
    public static class ApplicationConfigurationd
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddScoped<IPokemonService, PokemonService>();
        }
    }
}
