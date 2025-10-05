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
        PokemonSprites PokemonSprites);

    public record MoveRef(string Name, string Url);
    public record TypeRef(string Name, string Url);

    public record MovesRef(
       MoveRef Move);

    public record TypesRef(
      TypeRef Type);


}
