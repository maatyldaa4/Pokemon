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
            var httpResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"pokemon/{name}");

            var responseContent = httpResponse.Content.ReadAsStringAsync();
            var pokemonInfo = System.Text.Json.JsonSerializer.Deserialize<PokemonDto>(responseContent.Result);
            var pokemonModel = pokemonInfo.ToPokemonModel();

            return await Task.FromResult(pokemonModel);
        }


        async Task<IList<string>> IPokemonProvider.GetPokemonsAsync()
        {
            var httpResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"pokemon");

            var responseContent = httpResponse.Content.ReadAsStringAsync();
            var pokemonsInfo = System.Text.Json.JsonSerializer.Deserialize<PokemonsCollectionDto>(responseContent.Result);

            var pokemonsModel = pokemonsInfo.PokemonsRef.Select(p => p.Name).ToList();

            return await Task.FromResult(pokemonsModel);
        }

        async Task<Move> IPokemonProvider.GetMoveAsync(string name)
        {
            var httpResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"move/{name}");

            var responseContent = httpResponse.Content.ReadAsStringAsync();
            var move = System.Text.Json.JsonSerializer.Deserialize<MoveDto>(responseContent.Result);

            return await Task.FromResult(move.ToMoveModel());
        }

        async Task<TypeModel> IPokemonProvider.GetTypeAsync(string name)
        {
            var httpResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"type/{name}");

            var responseContent = httpResponse.Content.ReadAsStringAsync();
            var type = System.Text.Json.JsonSerializer.Deserialize<TypeDto>(responseContent.Result);

            return await Task.FromResult(type.ToTypeModel());
        }

    }
}
