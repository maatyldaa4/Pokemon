using Pokemon.Integrations.PokeApi.DTOs;
using PokemonModel = Pokemon.Application.Models.PokemonInfo;
using MoveRefModel = Pokemon.Application.Models.MoveRef;
using MovesRefModel = Pokemon.Application.Models.MovesRef;
using TypeRefModel = Pokemon.Application.Models.TypeRef;
using TypesRefModel = Pokemon.Application.Models.TypesRef;
using PokemonSpritesModel = Pokemon.Application.Models.PokemonSprites;
using TypeRelationshipRefModel = Pokemon.Application.Models.TypeRelationsRef;

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
                response.Moves.Select(m => m.ToMovesRefModel()).ToList(),
                response.Types.Select(t => t.ToTypesRefModel()).ToList(),
                response.PokemonSprites.ToPokemonSpritesModel());
        }

        public static MovesRefModel ToMovesRefModel(this MovesRefDto moveDto)
        {
            return new MovesRefModel(
                moveDto.Move.ToMoveRefModel());
        }

        public static MoveRefModel ToMoveRefModel(this MoveRefDto moveDto)
        {
            return new MoveRefModel(
                moveDto.Name,
                moveDto.Url);
        }

        public static TypesRefModel ToTypesRefModel(this TypesRefDto typesRefDto)
        {
            return new TypesRefModel(
                typesRefDto.Type.ToTypeRefModel());
        }

        public static TypeRefModel ToTypeRefModel(this TypeRefDto typeDto)
        {
            return new TypeRefModel(
                typeDto.Name,
                typeDto.Url);
        }

        public static PokemonSpritesModel ToPokemonSpritesModel(this PokemonSpritesDto spritesDto)
        {
            return new PokemonSpritesModel(
                spritesDto.FrontDefault,
                spritesDto.BackDefault);
        }
        public static TypeRelationshipRefModel ToTypeRelationshipRefModel(this TypeRelationshipDto relationshipDto)
        {
            return new TypeRelationshipRefModel(
                relationshipDto.HalfDamageFrom.ToTypeRefModel(),
                relationshipDto.HalfDamageTo.ToTypeRefModel(),
                relationshipDto.NoDamageFrom.ToTypeRefModel(),
                relationshipDto.NoDamageTo.ToTypeRefModel());
        }
    }
}
