export type PokemonSummary = {
    name: string;
    imageUrl: string;
};

export type PokemonSprites = {
    frontDefault: string,
    backDefault: string,
}

export type PokemonDetails = {
    id: number,
    name: string,
    baseExperience: number,
    height: number,
    weight: number,
    pokemonSprites: PokemonSprites,
};