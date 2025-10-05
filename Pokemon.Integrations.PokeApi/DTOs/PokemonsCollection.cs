using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record PokemonsCollectionDto(
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("next")] string Next,
        [property: JsonPropertyName("previous")] string Previos,
        [property: JsonPropertyName("results")] IList<PokemonDtoRef> PokemonsRef);

    public record PokemonDtoRef(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url);
}
