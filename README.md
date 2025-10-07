# Pokemon

## Summary
An application allows to browse Pokemons from PokeApi - https://pokeapi.co/docs/v2

## Structure
The solution consists of the following projects:
- **Pokemon.Api**                      → Web API <br/> This is a Minimal API for simplicity due to the limited number of endpoints. If you dig through my commits you can notice that I have started with controllers. The project has a swagger enabled. <br/>
- **Pokemon.Application**              → Core logic and data provider interface <br/>It lets me keep the logic separated from the implementation. If I wanted to add a feature that allows us to simulate pokemons battle I would also put that logic here. It contains all the objects and defines all the features that my application expects.<br/>
- **Pokemon.Integrations.PokeApi**     → External API <br/>This is the data provider. Due to the separation from the Application I can easily replace it with different Pokemon provider. It contains external DTOs, mappings to the Application models and implementation of the IPokemonProvider interface.<br/>
- **Pokemon.Common.HttpClient**          → Shared HttpClient <br/>I added this project to keep the base httpClient behavior separated. This would allow us to have all the error handling and operations defined in a single place. In case we wanted to consume other APIs, we do not have to repeate this logic in every single integraion.<br/>
- **pokemon.pokemonapp**                 → React frontend <br/>Very minimal frontend, just for a proof of concept. <br/>
- **Pokemon.Integ.PokeApi.Tests**        → Unit test <br/>Very limited unit tests, each project should have its own test project. I added it as an example, it's not ideal, if I had more time it would've been more detailed.<br/>
- **Pokemon.TestHelper**                 → Test utilities <br/> Helper methods, would be used for providing mock and defining assertion methods. <br/>

## Key Points 
- **Separation of layers** - I focused on separating layers and making them configurable. Projects have their configuration methods separated in Configuration folders. All used options are injected from appsettings.
- **Caching** - I decided to use very simple caching - built-in IMemoryCache. I cache it only on the external api level due to the project structure, but if I was consuming another API and combining the data I would also add caching on the Pokemon.Api level.
- **Filter/Sort/Search** - Added an option to filter/search/sort fetched data. To be honest, I have never done that before so I am sure it could be done better.

## What I would add
- Unit tests to every project, potentially also some integration tests
- Authorization/authentication - potentially JWT tokens, as I have an experience with it, although I would do a research beforehand. 
- Logging - I have added it only in ExternalApiClient
- General refactor and cleanup of methods - I am not satisfied with the quality of some, for example PokeApiClient seems messy, PokemonServices I think could hav a nicer handled filters/searches/sorts, etc.
- Develop frontend - current one is extremely limited
- Maybe a db, so a user could create his own PokeDex, it would let me add post/put methods to my API. 
