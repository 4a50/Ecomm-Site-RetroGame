import React from 'react';
import Carousel from 'react-bootstrap/Carousel'


export const Home = (props) => {


    return (
        <>
            <Carousel>
        <Carousel.Item>
    <img
      className="d-block w-100"
    src="https://via.placeholder.com/200"
      alt="First slide"  />
    <Carousel.Caption>
      <h3>First slide label</h3>
      <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
    </Carousel.Caption>
  </Carousel.Item>
            </Carousel>
           
        </>
    )
}
