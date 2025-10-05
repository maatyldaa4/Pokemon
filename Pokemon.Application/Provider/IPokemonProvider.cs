using Pokemon.Application.Models;
using System;

namespace Pokemon.Application.Provider
{
    public interface IPokemonProvider
    {
        Task<PokemonInfo> GetPokemonAsync(string name);
        Task<IList<string>> GetPokemonsAsync();
        Task<Move> GetMoveAsync(string name);
        Task<Models.Type> GetTypeAsync(string name);
    }
}
