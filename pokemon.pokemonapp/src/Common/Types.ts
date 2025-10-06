export type PokemonSummary = {
    name: string;
    imageUrl: string;
};

export type Move = {
    id: number,
    name: string,
    accuracy: number,
    powerPoints: number,
    power: number,
};

export type Type = {
    id: number,
    name: string,
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
    sprites: PokemonSprites,
    moves: Move[],
    types: Type[],
};