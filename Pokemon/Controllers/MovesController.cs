using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController(IPokemonService pokemonService) : ControllerBase
    {
        private readonly IPokemonService _pokemonService = pokemonService;

        [HttpGet("move/{name}")]
        public async Task<IActionResult> GetMoveAsync(string name)
        {
            var move = await _pokemonService.GetMoveAsync(name);

            return Ok(move);
        }
    }
}
