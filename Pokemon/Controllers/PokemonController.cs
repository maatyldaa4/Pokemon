using Microsoft.AspNetCore.Mvc;
using Pokemon.Application;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonProvider _pokemonProvider;

        public PokemonController(IPokemonProvider pokemonProvider)
        {
            _pokemonProvider = pokemonProvider;
        }

        [HttpGet("pokemon/{name}")]
        public async Task<IActionResult> GetPokemonAsync(string name)
        {
            var pokemon = await _pokemonProvider.GetPokemonAsync(name);

            return Ok(pokemon);
        }

        [HttpGet("pokemon")]
        public async Task<IActionResult> GetPokemonsAsync()
        {
            var pokemon = await _pokemonProvider.GetPokemonsAsync();

            return Ok(pokemon);
        }

    }
}
