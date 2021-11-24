import React from 'react';
import Card from 'react-bootstrap/Card';
import { Alert } from 'react-bootstrap';
import InventoryCardCore from '../Common/InventoryCardCore';

export default function CarouselCard(props) {
  console.log('CarouselCard props:', props);
  return (
    <Card style={{ height: '40rem' }} className="m-2">
      <InventoryCardCore item={props.item} />
      <Alert className="text-center">Click for Details!</Alert>
    </Card>
  );

}