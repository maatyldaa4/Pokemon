using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.ClientWrapper.Client;
using Pokemon.Integrations.PokeApi.DTOs;
using Pokemon.Integrations.PokeApi.Mapping;
using TypeModel = Pokemon.Application.Models.Type;

namespace Pokemon.Integrations.PokeApi.Client
{
    public class PokeApiClient(IExternalApiClient _api) : IPokemonProvider
    {
        async Task<PokemonInfo> IPokemonProvider.GetPokemonAsync(string name)
        {
            var pokemonInfo = await _api.GetDataAsync<PokemonDto>($"pokemon/{name}");
            var pokemonModel = pokemonInfo.ToPokemonModel();

            return await Task.FromResult(pokemonModel);
        }

        async Task<IList<string>> IPokemonProvider.GetPokemonsAsync()
        {
            var pokemonsInfo = await _api.GetDataAsync<PokemonsCollectionDto>($"pokemon");
            var pokemonsModel = pokemonsInfo.PokemonsRef.Select(p => p.Name).ToList();

            return await Task.FromResult(pokemonsModel);
        }

        async Task<Move> IPokemonProvider.GetMoveAsync(string name)
        {
            var move = await _api.GetDataAsync<MoveDto>($"move/{name}");

            return await Task.FromResult(move.ToMoveModel());
        }

        async Task<TypeModel> IPokemonProvider.GetTypeAsync(string name)
        {
            TypeDto typeModel = await _api.GetDataAsync<TypeDto>($"type/{name}");

            return await Task.FromResult(typeModel.ToTypeModel());
        }
    }
}
