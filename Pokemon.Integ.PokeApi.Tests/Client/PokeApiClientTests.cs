using FakeItEasy;
using Pokemon.Application.Models;
using Pokemon.Application.Provider;
using Pokemon.ClientWrapper.Client;
using Pokemon.Integrations.PokeApi.Client;
using Pokemon.Integrations.PokeApi.DTOs;
using Pokemon.Integrations.PokeApi.Mapping;
using static Pokemon.TestHelper.Asserts.ObjectsAssert;

namespace Pokemon.Integ.PokeApi.Tests.Client
{
    [TestFixture]
    public class PokeApiClientTests
    {
        private IPokemonProvider _objectUnderTests;
        private IExternalApiClient _api;
        private IPokeApiMapping _mapping;
        private CancellationToken ct = CancellationToken.None;

        [SetUp]
        public void SetUp()
        {
            _api = A.Fake<IExternalApiClient>();
            _mapping = A.Fake<IPokeApiMapping>();
            _objectUnderTests = new PokeApiClient(_api, _mapping);
        }

        [Test]
        public void Should_Return_PokemonCard_When_GetPokemonAsyncCalled()
        {
            var pokemonName = "pikachu";
            var pokemonDto = A.Fake<PokemonDto>();
            var pokemonModel = A.Fake<PokemonCard>();
            A.CallTo(() => _api.GetDataAsync<PokemonDto>($"pokemon/{pokemonName}", ct)).Returns(pokemonDto);
            A.CallTo(() => _mapping.ToPokemonCard(pokemonDto)).Returns(pokemonModel);
            
            var result = _objectUnderTests.GetPokemonAsync(pokemonName, ct).Result;

            AssertThatObjectsAreEqual(result, pokemonModel);
        }

        [Test]
        public void Should_CallGetDataAsync_When_GetPokemonAsyncCalled()
        {
            var pokemonName = "pikachu";
            var pokemonDto = A.Fake<PokemonDto>();
            var pokemonModel = A.Fake<PokemonCard>();
            A.CallTo(() => _api.GetDataAsync<PokemonDto>($"pokemon/{pokemonName}", ct)).Returns(pokemonDto);
            A.CallTo(() => _mapping.ToPokemonCard(pokemonDto)).Returns(pokemonModel);

            var result = _objectUnderTests.GetPokemonAsync(pokemonName, ct).Result;

            A.CallTo(() => _api.GetDataAsync<PokemonDto>($"pokemon/{pokemonName}", ct))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_CallToPokemonModel_When_GetPokemonAsyncCalled()
        {
            var pokemonName = "pikachu";
            var pokemonDto = A.Fake<PokemonDto>();
            var pokemonModel = A.Fake<PokemonCard>();
            A.CallTo(() => _api.GetDataAsync<PokemonDto>($"pokemon/{pokemonName}", ct)).Returns(pokemonDto);
            A.CallTo(() => _mapping.ToPokemonCard(pokemonDto)).Returns(pokemonModel);

            var result = _objectUnderTests.GetPokemonAsync(pokemonName, ct).Result;

            A.CallTo(() => _mapping.ToPokemonCard(pokemonDto))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_Return_PokemonsNames_When_GetPokemonsAsync()
        {
            var pokemonName = "pikachu";
            var namedApiResource = new NamedApiResourceDto(pokemonName, "url");
            var pokemonsCollection = new PokemonsCollectionDto(1, "next", "prev", 
                new List<NamedApiResourceDto> { namedApiResource });
            A.CallTo(() => _api.GetDataAsync<PokemonsCollectionDto>($"pokemon", ct)).Returns(pokemonsCollection);
            var expectedNames = new List<string> { pokemonName };

            var result = _objectUnderTests.GetPokemonsAsync(ct).Result;

            Assert.That(result, Is.EquivalentTo(expectedNames));
        }

    }
}
