using Microsoft.Extensions.Options;
using Pokemon.Application;
using Pokemon.Application.Models;
using Pokemon.Integrations.PokeApi.Configuration;
using Pokemon.Integrations.PokeApi.DTOs;
using Pokemon.Integrations.PokeApi.Mapping;

namespace Pokemon.Integrations.PokeApi.Client
{
    public class PokeApiClient(HttpClient httpClient, IOptions<PokeApiOptions> options) : IPokemonProvider
    {
        private readonly HttpClient _httpClient = httpClient;

        async Task<PokemonInfo> IPokemonProvider.GetPokemonAsync(string name)
        {
            var httpResponse = _httpClient.GetAsync(_httpClient.BaseAddress + $"pokemon/{name}");

            var responseContent = httpResponse.Result.Content.ReadAsStringAsync();
            var pokemonInfo = System.Text.Json.JsonSerializer.Deserialize<PokemonDto>(responseContent.Result);
            var pokemonModel = pokemonInfo.ToPokemonModel();

            return await Task.FromResult(pokemonModel);
        }


        Task<IList<PokemonInfo>> IPokemonProvider.GetPokemonsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
