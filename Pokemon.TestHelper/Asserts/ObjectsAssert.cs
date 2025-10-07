using NUnit.Framework;
using Pokemon.Application.Models;

namespace Pokemon.TestHelper.Asserts
{
    public static class ObjectsAssert
    {
        public static void AssertThatObjectsAreEqual(PokemonCard pokemon, PokemonCard otherPokemon)
        {
            Assert.That(pokemon.Id, Is.EqualTo(otherPokemon.Id));
            Assert.That(pokemon.Name, Is.EqualTo(otherPokemon.Name));
            Assert.That(pokemon.Height, Is.EqualTo(otherPokemon.Height));
            Assert.That(pokemon.Weight, Is.EqualTo(otherPokemon.Weight));
            Assert.That(pokemon.BaseExperience, Is.EqualTo(otherPokemon.BaseExperience));
            Assert.That(pokemon.PokemonSprites.FrontDefault, Is.EqualTo(otherPokemon.PokemonSprites.FrontDefault));
            Assert.That(pokemon.PokemonSprites.BackDefault, Is.EqualTo(otherPokemon.PokemonSprites.BackDefault));
        }
    }
}
