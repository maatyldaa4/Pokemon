using Microsoft.Extensions.Options;
using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.Integrations.PokeApi.Configuration;
using Pokemon.Integrations.PokeApi.DTOs;
using Pokemon.Integrations.PokeApi.Mapping;
using TypeModel = Pokemon.Application.Models.Type;

namespace Pokemon.Integrations.PokeApi.Client
{
    public class PokeApiClient(HttpClient httpClient, IOptions<PokeApiOptions> options) : IPokemonProvider
    {
        private readonly HttpClient _httpClient = httpClient;

        async Task<PokemonInfo> IPokemonProvider.GetPokemonAsync(string name)
        {
            var pokemonInfo = await GetAsync<PokemonDto>($"pokemon/{name}");
            var pokemonModel = pokemonInfo.ToPokemonModel();

            return await Task.FromResult(pokemonModel);
        }


        async Task<IList<string>> IPokemonProvider.GetPokemonsAsync()
        {
            var pokemonsInfo = await GetAsync<PokemonsCollectionDto>($"pokemon");
            var pokemonsModel = pokemonsInfo.PokemonsRef.Select(p => p.Name).ToList();

            return await Task.FromResult(pokemonsModel);
        }

        async Task<Move> IPokemonProvider.GetMoveAsync(string name)
        {
            var move = await GetAsync<MoveDto>($"move/{name}");

            return await Task.FromResult(move.ToMoveModel());
        }

        async Task<TypeModel> IPokemonProvider.GetTypeAsync(string name)
        {
            TypeDto typeModel = await GetAsync<TypeDto>($"type/{name}");

            return await Task.FromResult(typeModel.ToTypeModel());
        }

        async Task<T> GetAsync<T> (string endpoint)
        {
            var httpResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + endpoint);
            var responseContent = httpResponse.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<T>(responseContent.Result);

            return result;
        }
    }
}
