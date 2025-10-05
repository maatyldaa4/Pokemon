namespace Pokemon.Application.Models
{
    public record Move(
        int Id,
        string Name,
        int? Accuracy,
        int? PowerPoints,
        int? Power);
}
