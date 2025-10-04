namespace Pokemon.Application.Models
{
    public record Type(
     int Id,
     string Name,
     TypeRelationship TypeRelations);
}
