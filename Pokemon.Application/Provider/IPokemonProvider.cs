using Pokemon.Application.Models;
using System;

namespace Pokemon.Application.Provider
{
    public interface IPokemonProvider
    {
        Task<PokemonCard> GetPokemonAsync(string name, CancellationToken ct);
        Task<IList<string>> GetPokemonsAsync(CancellationToken ct, int? limit = null, int? offset = null);
        Task<IList<string>> FetchAllPokemonsAsync(CancellationToken ct);
    }
}
