import React from 'react';
import Carousel from 'react-bootstrap/Carousel';
import CardGroup from 'react-bootstrap/CardGroup'
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

export const Home = (props) => {


  return (
    <>
      <Carousel style={{ width: '50rem' }}>
        <Carousel.Item>
          <CardGroup>
            <Card className="m-2">
              <Card.Title className="text-center">This is a Card Title</Card.Title>
              <Card.Img variant="bottom" src="https://via.placeholder.com/200" />
              <Card.Text>This is text</Card.Text>
              <Button>Button</Button>
            </Card>
            <Card className="m-2">
              <Card.Title className="text-center">This is a Card Title</Card.Title>
              <Card.Img variant="bottom" src="https://via.placeholder.com/200" />
              <Card.Text>This is text</Card.Text>
              <Button>Button</Button>
            </Card>
          </CardGroup>
        </Carousel.Item>
      </Carousel>

    </>
  )
}
