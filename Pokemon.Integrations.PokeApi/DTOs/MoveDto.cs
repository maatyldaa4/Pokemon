using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record MoveDto(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("accuracy")] int? Accuracy,
        [property: JsonPropertyName("pp")] int? PowerPoints,
        [property: JsonPropertyName("power")] int? Power);
}
