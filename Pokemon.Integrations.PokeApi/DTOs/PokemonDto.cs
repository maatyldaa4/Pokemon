using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record PokemonDto(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("base_experience")] int BaseExperience,
        [property: JsonPropertyName("height")] int Height,
        [property: JsonPropertyName("weight")] int Weight,
        [property: JsonPropertyName("sprites")] PokemonSpritesDto PokemonSprites);
}
