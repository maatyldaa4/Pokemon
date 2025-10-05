using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record TypeRelationshipDto(
         [property: JsonPropertyName("no_damage_to")] NamedApiResourceDto NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] NamedApiResourceDto HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] NamedApiResourceDto NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] NamedApiResourceDto HalfDamageFrom);
}
