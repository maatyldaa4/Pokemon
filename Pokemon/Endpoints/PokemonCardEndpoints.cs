using Pokemon.Api.Requests;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Endpoints
{
    public static class PokemonCardEndpoints
    {
        public static void AddPokemonCardsEndpoints(this WebApplication app)
        {
            app.MapGet("/api/pokemon-card/{name}", GetPokemonCardAsync);
            app.MapGet("/api/pokemon-card", GetPokemonCardsAsync);
        }

        public static async Task<IResult> GetPokemonCardAsync(string name, 
            IPokemonService pokemonService,
            CancellationToken ct)
        {
            var pokemonCard = await pokemonService.GetPokemonCardAsync(name, ct);

            return Results.Ok(pokemonCard);
        }

        public static async Task<IResult> GetPokemonCardsAsync(
            IPokemonService pokemonService,
            [AsParameters] PokemonCardsQuery query,
            CancellationToken ct)
        {
            var pokemons = await pokemonService.GetPokemonCardsAsync(query.Search, query.MinBaseExperience, query.Sort, query.Order, ct);

            return Results.Ok(pokemons);
        }
    }
}
