using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Endpoints
{
    public static class PokemonDetailsEndpoints
    {
        public static void AddPokemonDetailsEndpoints(this WebApplication app)
        {
            app.MapGet("/api/move/{name}", GetMoveAsync);
            app.MapGet("/api/type/{name}", GetTypeAsync);
        }

        public static async Task<IResult> GetMoveAsync(string name, IPokemonService pokemonService)
        {
            var move = await pokemonService.GetMoveAsync(name);
            return Results.Ok(move);
        }

        public static async Task<IResult> GetTypeAsync(string name, IPokemonService pokemonService)
        {
            var type = await pokemonService.GetTypeAsync(name);
            return Results.Ok(type);
        }
    }
}
