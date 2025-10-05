using System.Text.Json.Serialization;

namespace Pokemon.Application.Models
{
    public record Type(
     int Id,
     string Name,
     IList<TypeRelationsRef> TypeRelations);

    public record TypeRelationsRef(
         [property: JsonPropertyName("no_damage_to")] NamedApiResource NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] NamedApiResource HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] NamedApiResource NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] NamedApiResource HalfDamageFrom);
}
