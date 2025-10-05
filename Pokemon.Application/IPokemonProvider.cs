using Pokemon.Application.Models;

namespace Pokemon.Application
{
    public interface IPokemonProvider
    {
        Task<PokemonInfo> GetPokemonAsync(string name);
        Task<IList<string>> GetPokemonsAsync();

    }
}
