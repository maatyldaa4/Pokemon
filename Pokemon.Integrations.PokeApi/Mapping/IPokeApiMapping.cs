using Pokemon.Application.Models;
using Pokemon.Integrations.PokeApi.DTOs;

namespace Pokemon.Integrations.PokeApi.Mapping
{
    public interface IPokeApiMapping
    {
        Move ToMoveModel(MoveDto move);
        MovesRef ToMovesRefModel(MovesRefDto movesRefDto);
        NamedApiResource ToNamedApiResource(NamedApiResourceDto namedApiResource);
        PokemonInfo ToPokemonModel(PokemonDto response);
        PokemonSprites ToPokemonSpritesModel(PokemonSpritesDto spritesDto);
        Application.Models.Type ToTypeModel(TypeDto type);
        TypeRelationsRef ToTypeRelationshipRefModel(TypeRelationshipDto relationshipDto);
        TypesRef ToTypesRefModel(TypesRefDto typesRefDto);
    }
}