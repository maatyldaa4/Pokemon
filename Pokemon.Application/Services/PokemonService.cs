using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.Application.Services.Interfaces;
using PokemonType = Pokemon.Application.Models.Type;

namespace Pokemon.Application.Services
{
    public class PokemonService(IPokemonProvider pokemonProvider) : IPokemonService
    {
        private readonly IPokemonProvider _pokemonProvider = pokemonProvider;

        public async Task<PokemonCard> GetPokemonCardAsync(string name)
        {
            PokemonInfo pokemonInfo = await _pokemonProvider.GetPokemonAsync(name);
            IList<Move> moves = new List<Move>();
            foreach (var moveRef in pokemonInfo.Moves)
            {
                Move move = await _pokemonProvider.GetMoveAsync(moveRef.Move.Name);

                moves.Add(move);
            }

            IList<PokemonType> types = new List<PokemonType>();
            foreach (var typeRef in pokemonInfo.Types)
            {
                PokemonType type = await _pokemonProvider.GetTypeAsync(typeRef.Type.Name);
                types.Add(type);
            }

            return new PokemonCard(
                pokemonInfo.Id,
                pokemonInfo.Name,
                pokemonInfo.BaseExperience,
                pokemonInfo.Height,
                pokemonInfo.Weight,
                moves,
                types,
                pokemonInfo.Sprites);
        }

        public async Task<IList<PokemonIcon>> GetPokemonsAsync()
        {
            IList<string> names = await _pokemonProvider.GetPokemonsAsync();

            IList<PokemonIcon> icons = new List<PokemonIcon>();
            foreach (var name in names)
            {
                var pokemonInfo = await _pokemonProvider.GetPokemonAsync(name);
                icons.Add(new PokemonIcon(pokemonInfo.Name, pokemonInfo.Sprites.FrontDefault));
            }
             return icons;
        }

        public Task<Move> GetMoveAsync(string name)
        {
            return _pokemonProvider.GetMoveAsync(name);
        }

        public Task<PokemonType> GetTypeAsync(string name)
        {
           return _pokemonProvider.GetTypeAsync(name);
        }

        public Task<PokemonInfo> GetPokemonAsync(string name)
        {
            return _pokemonProvider.GetPokemonAsync(name);
        }
    }
}
