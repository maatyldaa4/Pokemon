using Pokemon.Api.Requests;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Endpoints
{
    public static class PokemonEndpoints
    {
        public static void AddPokemonEndpoints(this WebApplication app)
        {
            app.MapGet("/api/pokemon/{name}", GetPokemonAsync);
            app.MapGet("/api/pokemon", GetPokemonsAsync);
        }

        public static async Task<IResult> GetPokemonAsync(string name, 
            IPokemonService pokemonService,
            CancellationToken ct)
        {
            var pokemon = await pokemonService.GetPokemonAsync(name, ct);

            return Results.Ok(pokemon);
        }

        public static async Task<IResult> GetPokemonsAsync(
            IPokemonService pokemonService,
            [AsParameters] PokemonIconsQuery query,
            CancellationToken ct)
        {
            var pokemons = await pokemonService.GetPokemonIconsAsync(query.Search, query.Order, ct);

            return Results.Ok(pokemons);
        }
    }
}
