using Pokemon.Application.Models;

namespace Pokemon.Application.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonCard> GetPokemonCardAsync(string name);
        Task<PokemonInfo> GetPokemonAsync(string name);
        Task<IList<PokemonIcon>> GetPokemonsAsync();
        Task<Move> GetMoveAsync(string name);
        Task<Models.Type> GetTypeAsync(string name);
        Task<BattleResult> BattleSimulationAsync(string firstPokemonName, string secondPokemonName);
    }
}
