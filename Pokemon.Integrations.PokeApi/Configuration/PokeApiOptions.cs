namespace Pokemon.Integrations.PokeApi.Configuration
{
    public class PokeApiOptions
    {
        public string BaseUrl { get; set; } = "";
        public int TimeoutSeconds { get; set; } = 10;
    }
}
