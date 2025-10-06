using Pokemon.Api.Endpoints;

namespace Pokemon.Api.Configuration
{
    public static class EndpointsConfiguration
    {
        public static void AddEndpoints(this WebApplication app)
        {
            app.AddPokemonEndpoints();
            app.AddPokemonDetailsEndpoints();         
        }
    }
}
