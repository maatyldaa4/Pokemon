using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record PokemonsCollectionDto(
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("next")] string Next,
        [property: JsonPropertyName("previous")] string Previos,
        [property: JsonPropertyName("results")] IList<NamedApiResourceDto> PokemonsRef);
}
