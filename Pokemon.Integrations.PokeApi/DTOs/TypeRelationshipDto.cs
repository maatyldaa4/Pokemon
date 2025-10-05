using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record TypeRelationshipDto(
         [property: JsonPropertyName("no_damage_to")] TypeRefDto NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] TypeRefDto HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] TypeRefDto NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] TypeRefDto HalfDamageFrom);
}
