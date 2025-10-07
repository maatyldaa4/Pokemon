namespace Pokemon.Api.Requests
{
    public record PokemonCardsQuery(
     string? Search,
     int? MinBaseExperience,
     string Sort = "name",
     string Order = "asc");
}
