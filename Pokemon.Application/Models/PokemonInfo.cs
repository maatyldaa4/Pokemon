using System.Text.Json.Serialization;

namespace Pokemon.Application.Models
{
    public record PokemonInfo(
        int Id, 
        string Name, 
        int BaseExperience,
        int Height,
        int Weight,
        IList<MovesRef> Moves,
        IList<TypesRef> Types,
        PokemonSprites Sprites);

    public record MovesRef(
       NamedApiResource Move);

    public record TypesRef(
      NamedApiResource Type);

}
