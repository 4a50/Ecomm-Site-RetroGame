import Carousel from 'react-bootstrap/Carousel';
function CarouselImages(props) {
  return (
    <Carousel className="m-2 p-4" style={{ width: "40rem" }}>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://via.placeholder.com/200"
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://via.placeholder.com/200"
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  )
}

export default CarouselImages