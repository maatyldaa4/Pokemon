using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record PokemonDto(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("base_experience")] int BaseExperience,
        [property: JsonPropertyName("height")] int Height,
        [property: JsonPropertyName("weight")] int Weight,
        [property: JsonPropertyName("moves")] IList<MovesRefDto> Moves,
        [property: JsonPropertyName("types")] IList<TypesRefDto> Types,
        [property: JsonPropertyName("sprites")] PokemonSpritesDto PokemonSprites);

    public record MovesRefDto(
        [property: JsonPropertyName("move")] NamedApiResourceDto Move);

    public record TypesRefDto(
      [property: JsonPropertyName("type")] NamedApiResourceDto Type);
}
