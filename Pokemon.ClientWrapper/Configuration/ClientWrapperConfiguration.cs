using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pokemon.ClientWrapper.Client;

namespace Pokemon.ClientWrapper.Configuration
{
    public static class ClientWrapperConfiguration
    {
        public static IServiceCollection AddClientWrapper<T>(this IServiceCollection services, IConfiguration config) where T: class, IApiOptions
        {
            services.AddHttpClient<IExternalApiClient, ExternalApiClient>((sp, http) =>
            {
                var options = sp.GetRequiredService<IOptions<T>>().Value;
                http.BaseAddress = new Uri(options.BaseUrl);
                http.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            });
       
            return services;
        }
    }
}
