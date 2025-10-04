using System.Text.Json.Serialization;

namespace Pokemon.Integrations.PokeApi.DTOs
{
    public record TypeDto(
      [property: JsonPropertyName("id")] int Id,
      [property: JsonPropertyName("name")] string Name,
      [property: JsonPropertyName("damage_relations")] TypeRelationshipDto TypeRelations);
}
