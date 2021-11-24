
import React, { useState } from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import FormGroup from 'react-bootstrap/FormGroup'
import { Button, Col, Row } from 'react-bootstrap';
function EditInventoryCard(props) {
  console.log('AdminCardProps:', props);

  const [updatedItem, setUpdatedItem] = useState(props.currentItem);
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log('EventValue:', event.target.name.value);
    props.handleCloseEditInv();

  }
  const toUpdateObj = {
    name: props.currentItem.name ? props.currentItem.name : 'No Game Selected',
    boxArtUrlFront: props.currentItem.boxArtUrlFront ? props.currentItem.boxArtUrlFront : 'https://via.placeholder.com/280x150',
    description: props.currentItem.description ? props.currentItem.description : 'No Description Available',
    itemPrice: props.currentItem.itemPrice ? props.currentItem.itemPrice : -1.0,
    condition: props.currentItem.condition ? props.currentItem.condition : 0
  }
  return (
    <>
      <Card style={{ height: '40rem' }} onClick={props.handleEditInventory}>

        <Form className="mb-3" onSubmit={handleSubmit}>

          <Form.Group as={Row} className="m-1" controlId="name">
            <Form.Label column sm={2}>Name</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={toUpdateObj.name} placeholder='Enter a name...' />
            </Col>
          </Form.Group>

          <Button type="submit">Update</Button>
        </Form>
      </Card>
    </>
  )
}

export default EditInventoryCard