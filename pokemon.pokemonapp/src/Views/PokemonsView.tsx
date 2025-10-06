import { useEffect, useState } from "react";
import { Spinner, Container, Row } from "react-bootstrap";
import PokemonCard from "./PokemonCard";
import type { PokemonSummary, PokemonDetails } from "../Common/Types";
import PokemonDetailsModal from "./PokemonDetailsModal";
 

export default function PokemonsView() {
    const [pokemons, setPokemons] = useState<PokemonSummary[]>([]);
    const [selectedPokemon, setSelectedPokemon] = useState<PokemonDetails>();
    const [loading, setLoading] = useState(true);
    const [modalShow, setModalShow] = useState(false);

    useEffect(() => {
        fetch("http://localhost/Pokemon/api/Pokemon/pokemon")
            .then(res => res.json())
            .then(pokemons => {
                setPokemons(pokemons);
                setLoading(false);

            })
            .catch(err => {
                console.error("Failed to load pokemons", err);
                setLoading(false);
            });
    }, []);

    const pokemonDetailsHandler = (pokemonName: string) => () => {
        fetch(`http://localhost/Pokemon/api/Pokemon/pokemon/${pokemonName}`)
            .then(res => res.json())
            .then(pokemonDetails => {
                setSelectedPokemon(pokemonDetails);
                setLoading(false);
                setModalShow(true);
                console.log(pokemonDetails);
            })
            .catch(err => {
                console.error("Failed to load pokemons", err);
                setLoading(false);
            });
    }

    if (loading)
        return (
            <div className="d-flex justify-content-center align-items-center vh-100">
                <Spinner animation="border" variant="primary" />
            </div>
        );


    return (
        <Container className="py-4">

            <Row className="g-3 justify-content-center">
                {pokemons.map(pokemon => (
                    <PokemonCard
                        key={pokemon.name}
                        name={pokemon.name}
                        imageUrl={pokemon.imageUrl}
                        handleDetails={pokemonDetailsHandler(pokemon.name)}
                    />))}
            </Row>
            <PokemonDetailsModal
                selectedPokemon={selectedPokemon}
                show={modalShow}
                handleClose={setModalShow}            />
        </Container>
    );
}