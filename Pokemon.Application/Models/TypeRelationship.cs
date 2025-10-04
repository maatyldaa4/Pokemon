namespace Pokemon.Application.Models
{
    public record TypeRelationship(
        Type NoDamageTo,
        Type HalfDamageTo,
        Type NoDamageFrom,
        Type HalfDamageFrom);
}
