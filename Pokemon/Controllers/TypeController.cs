using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Services.Interfaces;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController(IPokemonService pokemonService) : ControllerBase
    {
        private readonly IPokemonService _pokemonService = pokemonService;

        [HttpGet("type/{name}")]
        public async Task<IActionResult> GetTypeAsync(string name)
        {
            var type = await _pokemonService.GetTypeAsync(name);

            return Ok(type);
        }
    }
}
