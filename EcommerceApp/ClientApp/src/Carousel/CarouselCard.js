import React from 'react';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { Alert, ListGroup } from 'react-bootstrap';

export default function CarouselCard(props) {
  const findConditionCode = (code) => {
    const ConditionCode = {
      NotAvailable: 0,
      Excellent: 1,
      Good: 2,
      Fair: 3,
      Poor: 4
    }
    let val = Object.keys(ConditionCode).find(key => ConditionCode[key] === code);
    console.log(val)
    return val;
  }

  const formatPrice = (price) => {
    return (new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', currencyDisplay: 'narrowSymbol' }).format(price))
  }
  return (
    <Card className="m-2">
      <Card.Title className="text-center">{props.item.name}</Card.Title>
      <Card.Img variant="bottom" src={props.item.imageUrl} />
      <ListGroup variant="flush">
        <ListGroup.Item><strong>Price: </strong>{formatPrice(props.item.itemPrice)}</ListGroup.Item>
        <ListGroup.Item><strong>Condition: </strong>{findConditionCode(props.item.condition)}</ListGroup.Item>
      </ListGroup>
      <Card.Text>{props.item.description}</Card.Text>
      <Alert className="text-center">Click for Details!</Alert>
    </Card>
  );

}