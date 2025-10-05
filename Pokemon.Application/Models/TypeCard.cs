namespace Pokemon.Application.Models
{
    internal class TypeCard
    {
        public record Type(
            int Id,
            string Name,
            IList<TypeRelationship> TypeRelations);
    }
}
