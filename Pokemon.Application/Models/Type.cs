using System.Text.Json.Serialization;

namespace Pokemon.Application.Models
{
    public record Type(
     int Id,
     string Name,
     TypeRelationsRef TypeRelations);

    public record TypeRelationsRef(
         [property: JsonPropertyName("no_damage_to")] IList<NamedApiResource> NoDamageTo,
         [property: JsonPropertyName("half_damage_to")] IList<NamedApiResource> HalfDamageTo,
         [property: JsonPropertyName("no_damage_from")] IList<NamedApiResource> NoDamageFrom,
         [property: JsonPropertyName("half_damage_from")] IList<NamedApiResource> HalfDamageFrom);
}
