import { Col, Modal, Row, Image} from "react-bootstrap";
import type { PokemonDetails } from "../Common/Types"; 

interface IPokemonDetailsModalProps {
    selectedPokemon: PokemonDetails | undefined,
    show: boolean,
    handleClose: (show: boolean) => void
}

export default function PokemonDetailsModal({
    selectedPokemon, show, handleClose
}: Readonly<IPokemonDetailsModalProps>) {

    return (
        <Modal show={show} onHide={() => handleClose(false)}>
            <Modal.Header closeButton>
                <Modal.Title>{selectedPokemon?.name}</Modal.Title>
                    <Row className="align-items-center g-4">
                    <Col xs={12} md="auto" className="text-center">
                        <Image
                            src={selectedPokemon?.pokemonSprites.frontDefault}
                            alt={selectedPokemon?.name}
                            width={128}
                            height={128}
                            style={{ objectFit: "contain" }}
                        />
                    </Col>
                    <Col>
                        <Row xs={3} className="gx-4 gy-2 small">
                            <Col><strong>Base EXP</strong><div>{selectedPokemon?.baseExperience}</div></Col>
                            <Col><strong>Height</strong><div>{selectedPokemon?.height}</div></Col>
                            <Col><strong>Weight</strong><div>{selectedPokemon?.weight}</div></Col>
                        </Row>
                    </Col>
                </Row>
            </Modal.Header>
        </Modal>
    );
}