using NUnit.Framework;
using Pokemon.Application.Models;

namespace Pokemon.TestHelper.Asserts
{
    public static class ObjectsAssert
    {
        public static void AssertThatObjectsAreEqual(PokemonInfo pokemon, PokemonInfo otherPokemon)
        {
            Assert.That(pokemon.Id, Is.EqualTo(otherPokemon.Id));
            Assert.That(pokemon.Name, Is.EqualTo(otherPokemon.Name));
            Assert.That(pokemon.Height, Is.EqualTo(otherPokemon.Height));
            Assert.That(pokemon.Weight, Is.EqualTo(otherPokemon.Weight));
            Assert.That(pokemon.BaseExperience, Is.EqualTo(otherPokemon.BaseExperience));
            Assert.That(pokemon.Sprites.FrontDefault, Is.EqualTo(otherPokemon.Sprites.FrontDefault));
            Assert.That(pokemon.Moves.Count, Is.EqualTo(otherPokemon.Moves.Count));
            Assert.That(pokemon.Types.Count, Is.EqualTo(otherPokemon.Types.Count));
        }
    }
}
