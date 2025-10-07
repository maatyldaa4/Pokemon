using Pokemon.Application.Models;
using Pokemon.Integrations.PokeApi.DTOs;

namespace Pokemon.Integrations.PokeApi.Mapping
{
    public interface IPokeApiMapping
    {
        NamedApiResource ToNamedApiResource(NamedApiResourceDto namedApiResource);
        PokemonCard ToPokemonCard(PokemonDto response);
        PokemonSprites ToPokemonSpritesModel(PokemonSpritesDto spritesDto);
      
    }
}