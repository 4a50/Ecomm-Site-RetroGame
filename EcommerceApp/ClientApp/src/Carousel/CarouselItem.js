import React from 'react';
import Carousel from 'react-bootstrap/Carousel';
import CardGroup from 'react-bootstrap/CardGroup';
import CarouselCard from './CarouselCard';

export default function CarouselItem(props) {
  return (
    <Carousel.Item>
      <CardGroup>
        {props.cardArr.map(card => <CarouselCard item={card} />)}
      </CardGroup>
    </Carousel.Item>
  )
}