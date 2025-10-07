namespace Pokemon.Api.Requests
{
    public record PokemonIconsQuery(
     string? Search,
     string Order = "asc");
}
