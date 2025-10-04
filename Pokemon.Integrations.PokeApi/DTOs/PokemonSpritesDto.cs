using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record PokemonSpritesDto(
          [property: JsonPropertyName("front_default")] string FrontDefault,
          [property: JsonPropertyName("back_default")] string BackDefault);
}
