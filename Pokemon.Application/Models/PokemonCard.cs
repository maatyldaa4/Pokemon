namespace Pokemon.Application.Models
{
    public record PokemonCard(
          int Id,
          string Name,
          int BaseExperience,
          int Height,
          int Weight,
          IList<Move> Moves,
          IList<Type> Types,
          PokemonSprites PokemonSprites);
}
