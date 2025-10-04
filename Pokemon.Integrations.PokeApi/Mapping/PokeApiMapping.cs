using Pokemon.Integrations.PokeApi.DTOs;
using PokemonModel = Pokemon.Application.Models.Pokemon;
using MoveModel = Pokemon.Application.Models.Move;
using TypeModel = Pokemon.Application.Models.Type;
using PokemonSpritesModel = Pokemon.Application.Models.PokemonSprites;
using TypeRelationshipModel = Pokemon.Application.Models.TypeRelationship;

namespace Pokemon.Integrations.PokeApi.Mapping
{
    internal static class PokeApiMapping
    {
        public static PokemonModel ToPokemonModel(this PokemonDto response)
        {
            return new PokemonModel(
                response.Id,
                response.Name,
                response.BaseExperience,
                response.Height,
                response.Weight,
                response.Moves.Select(m => m.ToMoveModel()).ToList(),
                response.Types.Select(t => t.ToTypeModel()).ToList(),
                response.PokemonSprites.ToPokemonSpritesModel());
        }

        public static MoveModel ToMoveModel(this MoveDto moveDto)
        {
            return new MoveModel(
                moveDto.Id,
                moveDto.Name,
                moveDto.Accuracy,
                moveDto.EffectChance,
                moveDto.PowerPoints,
                moveDto.Power);
        }

        public static TypeModel ToTypeModel(this TypeDto typeDto)
        {
            return new TypeModel(
                typeDto.Id,
                typeDto.Name,
                typeDto.TypeRelations.ToTypeRelationshipModel());
        }

        public static PokemonSpritesModel ToPokemonSpritesModel(this PokemonSpritesDto spritesDto)
        {
            return new PokemonSpritesModel(
                spritesDto.FrontDefault,
                spritesDto.BackDefault);
        }
        public static TypeRelationshipModel ToTypeRelationshipModel(this TypeRelationshipDto relationshipDto)
        {
            return new TypeRelationshipModel(
                relationshipDto.HalfDamageFrom.ToTypeModel(),
                relationshipDto.HalfDamageTo.ToTypeModel(),
                relationshipDto.NoDamageFrom.ToTypeModel(),
                relationshipDto.NoDamageTo.ToTypeModel());
        }
    }
}
