namespace Pokemon.Application.Models
{
    public record Move(
        int Id,
        string Name,
        int Accuracy,
        int EffectChance,
        int PowerPoints,
        int Power);
}
