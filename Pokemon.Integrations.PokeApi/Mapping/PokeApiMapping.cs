using Pokemon.Integrations.PokeApi.DTOs;
using PokemonModel = Pokemon.Application.Models.PokemonInfo;
using MovesRefModel = Pokemon.Application.Models.MovesRef;
using TypesRefModel = Pokemon.Application.Models.TypesRef;
using PokemonSpritesModel = Pokemon.Application.Models.PokemonSprites;
using TypeRelationshipRefModel = Pokemon.Application.Models.TypeRelationsRef;
using TypeModel = Pokemon.Application.Models.Type;
using Pokemon.Application.Models;

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

        public static NamedApiResource ToNamedApiResource(this NamedApiResourceDto namedApiResource)
        {
            return new NamedApiResource(
                namedApiResource.Name,
                namedApiResource.Url);
        }

        public static MovesRefModel ToMovesRefModel(this MovesRefDto movesRefDto)
        {
            return new MovesRefModel(
                movesRefDto.Move.ToNamedApiResource());
        }

        public static TypesRefModel ToTypesRefModel(this TypesRefDto typesRefDto)
        {
            return new TypesRefModel(
                typesRefDto.Type.ToNamedApiResource());
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
                relationshipDto.HalfDamageFrom.Select(t => t.ToNamedApiResource()).ToList(),
                relationshipDto.HalfDamageTo.Select(t => t.ToNamedApiResource()).ToList(),
                relationshipDto.NoDamageFrom.Select(t => t.ToNamedApiResource()).ToList(),
                relationshipDto.NoDamageTo.Select(t => t.ToNamedApiResource()).ToList());
        }

        public static Move ToMoveModel(this MoveDto move)
        {
            return new Move(
                move.Id, 
                move.Name, 
                move.Accuracy, 
                move.PowerPoints, 
                move.Power);
        }

        public static TypeModel ToTypeModel(this TypeDto type)
        {
            return new TypeModel(type.Id, type.Name, type.TypeRelations.ToTypeRelationshipRefModel());
        }

    }
}
