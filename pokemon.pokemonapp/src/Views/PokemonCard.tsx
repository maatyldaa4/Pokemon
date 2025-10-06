import { Card, Button, Col } from "react-bootstrap";

interface IPokemonCardProps { 
    name: string,
    imageUrl: string,
    handleDetails: (pokemonName: string) => void
}

export default function PokemonCard({
    name, imageUrl, handleDetails
}: Readonly<IPokemonCardProps>) {

    return (
        <Col key={name} xs={12} sm={6} md={4} lg={3}>
            <Card key={name} style={{ width: '18rem' }}>
                <Card.Header>{name.toUpperCase()}</Card.Header>
                <Card.Body>
                    <Card.Img variant="top" src={imageUrl} />
                    <Card.Text>
                        Some quick example text to build on the card title and make up the
                        bulk of the card's content.
                    </Card.Text>
                    <Button variant="primary" onClick={() => handleDetails(name)}>Details</Button>
                </Card.Body>
            </Card>
        </Col>
    );
}