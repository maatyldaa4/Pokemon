using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController(IPokemonService pokemonService) : ControllerBase
    {
        private readonly IPokemonService _pokemonService = pokemonService;

        [HttpGet("pokemon/{name}")]
        public async Task<IActionResult> GetPokemonAsync(string name)
        {
            var pokemon = await _pokemonService.GetPokemonAsync(name);

            return Ok(pokemon);
        }

        [HttpGet("pokemon")]
        public async Task<IActionResult> GetPokemonsAsync()
        {
            var pokemon = await _pokemonService.GetPokemonsAsync();

            return Ok(pokemon);
        }

    }
}
