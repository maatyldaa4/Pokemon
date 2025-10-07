using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record NamedApiResourceDto(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url);
}
