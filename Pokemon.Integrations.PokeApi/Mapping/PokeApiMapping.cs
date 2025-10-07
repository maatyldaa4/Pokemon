using Pokemon.Integrations.PokeApi.DTOs;
using PokemonSpritesModel = Pokemon.Application.Models.PokemonSprites;
using Pokemon.Application.Models;

namespace Pokemon.Integrations.PokeApi.Mapping
{
    public class PokeApiMapping : IPokeApiMapping
    {
        public PokemonCard ToPokemonCard(PokemonDto response)
        {
            return new PokemonCard(
                response.Id,
                response.Name,
                response.BaseExperience,
                response.Height,
                response.Weight,
                ToPokemonSpritesModel(response.PokemonSprites));
        }

        public NamedApiResource ToNamedApiResource(NamedApiResourceDto namedApiResource)
        {
            return new NamedApiResource(
                namedApiResource.Name,
                namedApiResource.Url);
        }

        public PokemonSpritesModel ToPokemonSpritesModel(PokemonSpritesDto spritesDto)
        {
            return new PokemonSpritesModel(
                spritesDto.FrontDefault,
                spritesDto.BackDefault);
        }
    }
}
