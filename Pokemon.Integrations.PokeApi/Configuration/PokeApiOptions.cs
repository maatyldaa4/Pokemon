using Pokemon.ClientWrapper.Configuration;

namespace Pokemon.Integrations.PokeApi.Configuration
{
    public class PokeApiOptions: IApiOptions
    {
        public string BaseUrl { get; set; } = "";
        public int TimeoutSeconds { get; set; } = 60;
    }
}
