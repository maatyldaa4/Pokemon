using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.ClientWrapper.Client;
using Pokemon.Integrations.PokeApi.Configuration;
using Pokemon.Integrations.PokeApi.DTOs;
using Pokemon.Integrations.PokeApi.Mapping;

namespace Pokemon.Integrations.PokeApi.Client
{
    public class PokeApiClient(
        IExternalApiClient _api, 
        IPokeApiMapping _pokeApiMapping,
        IMemoryCache memoryCache,
        IOptions<PokeApiOptions> options) : IPokemonProvider
    {
        private readonly IMemoryCache _cache = memoryCache;
        private readonly TimeSpan _ttl = TimeSpan.FromMinutes(options.Value.CacheMinutes);

        async Task<PokemonCard> IPokemonProvider.GetPokemonAsync(string name, CancellationToken ct)
        {
            var key = $"pokemon-{name}";
            if (_cache.TryGetValue(key, out PokemonCard? cachedPokemon))
            {
                return cachedPokemon!;
            }

            var pokemonInfo = await _api.GetDataAsync<PokemonDto>($"pokemon/{name}", ct);
            var pokemonModel = _pokeApiMapping.ToPokemonCard(pokemonInfo);

            _cache.Set(key, pokemonModel, _ttl);

            return await Task.FromResult(pokemonModel);
        }

        async Task<IList<string>> IPokemonProvider.GetPokemonsAsync(
            CancellationToken ct,
            int? limit,
            int? offset)
        {
            var key = $"pokemons-{limit}-{offset}";
            if (_cache.TryGetValue(key, out IList<string>? cachedPokemons))
            {
                return cachedPokemons!;
            }
            var pokemonsInfo = await GetPokemonsRawAsync(ct, limit, offset);
            var pokemonsModel = pokemonsInfo.PokemonsRef.Select(p => p.Name).ToList();
            
            _cache.Set(key, pokemonsModel, _ttl);

            return await Task.FromResult(pokemonsModel);
        }

        async Task<IList<string>> IPokemonProvider.FetchAllPokemonsAsync(CancellationToken ct)
        {
            var key = "all-pokemons";
            if (_cache.TryGetValue(key, out IList<string>? cachedPokemons))
            {
                return cachedPokemons!;
            }
            var firstPage = await GetPokemonsRawAsync(ct);
            var total = firstPage.Count;

            const int batchSize = 100;
            var allNames = new List<string>(capacity: total);
            for (int offset = 0; offset < total; offset += batchSize)
            {
                var page = await ((IPokemonProvider)this).GetPokemonsAsync(ct, batchSize, offset);
                allNames.AddRange(page);
            }

            _cache.Set(key, allNames, _ttl);

            return allNames.ToList();
        }

        private async Task<PokemonsCollectionDto> GetPokemonsRawAsync(
           CancellationToken ct,
           int? limit = null,
           int? offset = null)
        {
            var key = $"pokemons-raw-{limit}-{offset}";
            if (_cache.TryGetValue(key, out PokemonsCollectionDto? cachedPokemons))
            {
                return cachedPokemons!;
            }
            var query = QueryBuilder(limit, offset);
            var pokemonsInfo = await _api.GetDataAsync<PokemonsCollectionDto>(query, ct);

            _cache.Set(key, pokemonsInfo, _ttl);

            return await Task.FromResult(pokemonsInfo);
        }

        private static string QueryBuilder(int? limit = null, int? offset = null)
        {
            var query = "pokemon?";
            if (limit.HasValue)
            {
                query += $"limit={limit.Value}&";
            }
            if (offset.HasValue)
            {
                query += $"offset={offset.Value}&";
            }
            return query.TrimEnd('&');
        }
    }
}
