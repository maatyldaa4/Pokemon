using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Models
{
    internal class PokemonCard
    {
        public record PokemonInfo(
          int Id,
          string Name,
          int BaseExperience,
          int Height,
          int Weight,
          IList<Move> Moves,
          IList<Type> Types,
          PokemonSprites PokemonSprites);
    }
}
