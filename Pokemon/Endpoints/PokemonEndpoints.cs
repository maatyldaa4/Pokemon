using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Endpoints
{
    public static class PokemonEndpoints
    {
        public static void AddPokemonEndpoints(this WebApplication app)
        {
            app.MapGet("/api/pokemon/{name}", GetPokemonAsync);
            app.MapGet("/api/pokemons", GetPokemonsAsync);
            app.MapGet("/api/pokemon-card/{name}", GetPokemonCardAsync);
        }

        public static async Task<IResult> GetPokemonAsync(string name, IPokemonService pokemonService)
        {
            var pokemon = await pokemonService.GetPokemonAsync(name);

            return Results.Ok(pokemon);
        }

        public static async Task<IResult> GetPokemonsAsync(IPokemonService pokemonService)
        {
            var pokemons = await pokemonService.GetPokemonsAsync();
            return Results.Ok(pokemons);
        }

        public static async Task<IResult> GetPokemonCardAsync(string name, IPokemonService pokemonService)
        {
            var pokemonCard = await pokemonService.GetPokemonCardAsync(name);
            return Results.Ok(pokemonCard);
        }

    }
}
