using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonCardController(IPokemonService pokemonService) : ControllerBase
    {
        private readonly IPokemonService _pokemonService = pokemonService;

        [HttpGet("card/{name}")]
        public async Task<IActionResult> GetCardAsync(string name)
        {
            var card = await _pokemonService.GetPokemonCardAsync(name);

            return Ok(card);
        }
    }
}
