import React from 'react';
import { useState, useEffect } from 'react';
import { CardGroup, Container } from 'react-bootstrap';
import Carousel from 'react-bootstrap/Carousel'
import CarouselCard from './CarouselCard.js'
export default function CarouselDisplay(props) {

  const [carouselData, setCarouselData] = useState([]);

  const mapItems = () => {
    return carouselData.map((item, idx) => {
      console.log(item);
      return <Carousel.Item key={idx}>
        <CardGroup>
          {item.map((itemCard, idx) => <CarouselCard key={`cc-${idx}`} item={itemCard} />)}
        </CardGroup>
      </Carousel.Item>
    })
  }

  useEffect(() => {
    let getCarouselData = async () => {
      try {
        let res = await fetch('inventory/initialfrontend');
        let data = await res.json();
        console.log('DATA:', data);
        setCarouselData(data);
      }
      catch (e) {
        console.log('error retrieving data:', e.message)
      }
    }
    getCarouselData();
  }, [])
  return (
    <>
      <h1>CarouselDisplay</h1>      
      <Container>
        <Carousel>
          {carouselData.length > 0 ? mapItems() : 'Nothing to add'}
        </Carousel>
      </Container>
    </>
  )
}