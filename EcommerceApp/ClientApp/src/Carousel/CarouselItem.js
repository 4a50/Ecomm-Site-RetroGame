import React from 'react';
import Carousel from 'react-bootstrap/Carousel';
import CarouselCard from '../Carousel/CarouselCard.js'
import CardGroup from 'react-bootstrap/CardGroup';

export default class CarouselItem extends React.Component {
  render() {
    // console.log('CI', this.props);
    return (
      <Carousel.Item>
        <h1>Carousel</h1>
        <CardGroup>
          {this.props.data.map((card, idx) => <CarouselCard key={idx} item={card} />)}
        </CardGroup>
      </Carousel.Item>
    )
  }
}