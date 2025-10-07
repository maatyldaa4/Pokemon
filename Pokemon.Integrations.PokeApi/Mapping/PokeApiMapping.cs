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
    public class PokeApiMapping : IPokeApiMapping
    {
        public PokemonModel ToPokemonModel(PokemonDto response)
        {
            return new PokemonModel(
                response.Id,
                response.Name,
                response.BaseExperience,
                response.Height,
                response.Weight,
                response.Moves.Select(ToMovesRefModel).ToList(),
                response.Types.Select(ToTypesRefModel).ToList(),
                ToPokemonSpritesModel(response.PokemonSprites));
        }

        public NamedApiResource ToNamedApiResource(NamedApiResourceDto namedApiResource)
        {
            return new NamedApiResource(
                namedApiResource.Name,
                namedApiResource.Url);
        }

        public MovesRefModel ToMovesRefModel(MovesRefDto movesRefDto)
        {
            return new MovesRefModel(
                ToNamedApiResource(movesRefDto.Move));
        }

        public TypesRefModel ToTypesRefModel(TypesRefDto typesRefDto)
        {
            return new TypesRefModel(
                ToNamedApiResource(typesRefDto.Type));
        }

        public PokemonSpritesModel ToPokemonSpritesModel(PokemonSpritesDto spritesDto)
        {
            return new PokemonSpritesModel(
                spritesDto.FrontDefault,
                spritesDto.BackDefault);
        }
        public TypeRelationshipRefModel ToTypeRelationshipRefModel(TypeRelationshipDto relationshipDto)
        {
            return new TypeRelationshipRefModel(
                relationshipDto.HalfDamageFrom.Select(ToNamedApiResource).ToList(),
                relationshipDto.HalfDamageTo.Select(ToNamedApiResource).ToList(),
                relationshipDto.NoDamageFrom.Select(ToNamedApiResource).ToList(),
                relationshipDto.NoDamageTo.Select(ToNamedApiResource).ToList());
        }

        public Move ToMoveModel(MoveDto move)
        {
            return new Move(
                move.Id,
                move.Name,
                move.Accuracy,
                move.PowerPoints,
                move.Power);
        }

        public TypeModel ToTypeModel(TypeDto type)
        {
            return new TypeModel(type.Id, type.Name, ToTypeRelationshipRefModel(type.TypeRelations));
        }

    }
}
