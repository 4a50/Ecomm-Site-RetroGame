import React from 'react';
import Card from 'react-bootstrap/Card';
import { Alert } from 'react-bootstrap';
import InventoryCardCore from '../Common/InventoryCardCore';

export default function CarouselCard(props) {
  return (
    <Card className="m-2">
      <InventoryCardCore item={props.item} />
      <Alert className="text-center">Click for Details!</Alert>
    </Card>
  );

}