using System.Text.Json.Serialization;

namespace Pokemon.Application.Models
{
    public record NamedApiResource(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url);
}
