using Pokemon.Application.Models;
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
        [property: JsonPropertyName("move")] MoveRefDto Move);

    public record TypesRefDto(
      [property: JsonPropertyName("type")] TypeRefDto Type);
        
    public record MoveRefDto(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url);
    public record TypeRefDto(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url);
}
