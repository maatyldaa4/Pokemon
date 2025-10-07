using Pokemon.Application.Models;

namespace Pokemon.Application.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonCard> GetPokemonCardAsync(string name, CancellationToken ct);
        Task<PokemonIcon> GetPokemonAsync(string name, CancellationToken ct);
        Task<IList<PokemonIcon>> GetPokemonIconsAsync(string? search, string order, CancellationToken ct);
        Task<IList<PokemonCard>> GetPokemonCardsAsync(string? search, int? minBaseExperience, string sort, string order, CancellationToken ct);
        Task<IList<string>> FetchAllPokemonsAsync(CancellationToken ct);
    }
}
