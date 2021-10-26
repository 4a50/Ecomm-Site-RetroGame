import React from 'react';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

export default function CarouselCard(props) {
  return (
    <Card className="m-2">
      <Card.Title className="text-center">{props.item.name}</Card.Title>
      <Card.Img variant="bottom" src={props.item.boxArtUrlFront} />
      <Card.Text>{props.item.description}</Card.Text>
      <Button>Button</Button>
    </Card>
  );

}