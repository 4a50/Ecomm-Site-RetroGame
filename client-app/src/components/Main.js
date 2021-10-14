import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Carousel from 'react-bootstrap/Carousel';
import Card from 'react-bootstrap/Card'
import CarouselImages from './Main/CarouselImages.js'

function Main(props) {
  console.log('Main Props:', props);
  return (
    <Container className="d-flex flex-column">
      <Card className="m-2">
        <h1>Welcome to <strong>5UP</strong> Retro Game Shoppe</h1>
        <h2>Specializing in Cartridge Games</h2>
      </Card>
      <CarouselImages className="d-flex justify-content-center" />
    </Container>
  );
}

export default Main;