using Pokemon.Integrations.PokeApi.DTOs;
using PokemonModel = Pokemon.Application.Models.PokemonInfo;
using MovesRefModel = Pokemon.Application.Models.MovesRef;
using TypesRefModel = Pokemon.Application.Models.TypesRef;
using PokemonSpritesModel = Pokemon.Application.Models.PokemonSprites;
using TypeRelationshipRefModel = Pokemon.Application.Models.TypeRelationsRef;
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
                relationshipDto.HalfDamageFrom.ToNamedApiResource(),
                relationshipDto.HalfDamageTo.ToNamedApiResource(),
                relationshipDto.NoDamageFrom.ToNamedApiResource(),
                relationshipDto.NoDamageTo.ToNamedApiResource());
        }
    }
}
