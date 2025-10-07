using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.Application.Services.Interfaces;
using System.Collections.Concurrent;

namespace Pokemon.Application.Services
{
    public class PokemonService(IPokemonProvider pokemonProvider) : IPokemonService
    {
        private readonly IPokemonProvider _pokemonProvider = pokemonProvider;

        public async Task<PokemonCard> GetPokemonCardAsync(string name, CancellationToken ct)
        {
            PokemonCard pokemonInfo = await _pokemonProvider.GetPokemonAsync(name, ct);

            return new PokemonCard(
                pokemonInfo.Id,
                pokemonInfo.Name,
                pokemonInfo.BaseExperience,
                pokemonInfo.Height,
                pokemonInfo.Weight,
                pokemonInfo.PokemonSprites);
        }

        public async Task<IList<PokemonIcon>> GetPokemonIconsAsync(
            string? search,
            string order,
            CancellationToken ct)
        {
            IList<string> names = await _pokemonProvider.GetPokemonsAsync(ct);
            IList<PokemonIcon> icons = new List<PokemonIcon>();
            foreach (var name in names)
            {
                var pokemonCard = await _pokemonProvider.GetPokemonAsync(name, ct);
                icons.Add(new PokemonIcon(pokemonCard.Name, pokemonCard.PokemonSprites.FrontDefault));
            }

            if (!string.IsNullOrWhiteSpace(search))
            { 
                icons = icons.Where(p => 
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList(); 
            }

            icons = order.ToLower() switch
            {
                "desc" => icons.OrderByDescending(p => p.Name).ToList(),
                _ => icons.OrderBy(p => p.Name).ToList(),
            };

            return icons;
        }

        public async Task<PokemonIcon> GetPokemonAsync(string name, CancellationToken ct)
        {
            var pokemonCard = await _pokemonProvider.GetPokemonAsync(name, ct);

            return new PokemonIcon(pokemonCard.Name, pokemonCard.PokemonSprites.FrontDefault);
        }

        public async Task<IList<PokemonCard>> GetPokemonCardsAsync(string? search, int? minBaseExperience,
            string sort, string order, CancellationToken ct)
        {
            IList<string> names = await _pokemonProvider.FetchAllPokemonsAsync(ct);
            var pokemonCards = new ConcurrentBag<PokemonCard>();

            await Parallel.ForEachAsync(names, new ParallelOptions
            {
                MaxDegreeOfParallelism = 10,   
                CancellationToken = ct
            },
            async (name, token) =>
            {

                var pokemonCard = await GetPokemonCardAsync(name, token);
                pokemonCards.Add(pokemonCard);
                
            });

            var pokemonCardsList = pokemonCards.ToList();

            if (!string.IsNullOrWhiteSpace(search))
            { 
                pokemonCardsList = pokemonCardsList
                    .Where(p => p.Name
                    .Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList(); 
            }

            if(minBaseExperience.HasValue)
            {
                pokemonCardsList = pokemonCardsList
                    .Where(p => p.BaseExperience >= minBaseExperience.Value)
                    .ToList();
            }

            return sort switch
            {
                "weight" => (
                    order == "desc" ?
                        pokemonCardsList.OrderByDescending(p => p.Weight) :
                        pokemonCardsList.OrderBy(p => p.Weight)).ToList(),
                "height" => (
                order == "desc" ?
                    pokemonCardsList.OrderByDescending(p => p.Height) :
                    pokemonCardsList.OrderBy(p => p.Height)).ToList(),
                _ => pokemonCardsList.OrderBy(p => p.Name).ToList()
            };
        }

        public async Task<IList<string>> FetchAllPokemonsAsync(CancellationToken ct) { 
            return await _pokemonProvider.FetchAllPokemonsAsync(ct);
        }
    }
}
