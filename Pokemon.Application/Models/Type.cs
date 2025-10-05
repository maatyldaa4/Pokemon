using System.Text.Json.Serialization;

namespace Pokemon.Application.Models
{
    public record Type(
     int Id,
     string Name,
     IList<TypeRelationsRef> TypeRelations);

    public record TypeRelationsRef(
         [property: JsonPropertyName("no_damage_to")] TypeRef NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] TypeRef HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] TypeRef NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] TypeRef HalfDamageFrom);
}
