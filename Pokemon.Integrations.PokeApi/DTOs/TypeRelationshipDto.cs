using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record TypeRelationshipDto(
         [property: JsonPropertyName("no_damage_to")] TypeDto NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] TypeDto HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] TypeDto NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] TypeDto HalfDamageFrom);
}
