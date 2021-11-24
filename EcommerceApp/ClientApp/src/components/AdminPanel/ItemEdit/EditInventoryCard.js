
import React, { useState } from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import FormGroup from 'react-bootstrap/FormGroup'
import { Button, Col, Row } from 'react-bootstrap';
import CommonModal from '../../Common/CommonModal.js'
import { textChangeRangeNewSpan } from 'typescript';
function EditInventoryCard(props) {
  console.log('AdminCardProps:', props);

  const [updatedItem, setUpdatedItem] = useState(props.currentItem);
  const [confirmModal, setConfirmModal] = useState(false);
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log('EventValue:', event.target.name.value);
    props.handleCloseEditInv();
  }
  const handleConfirmOpen = () => setConfirmModal(true);
  const handleConfirmClose = () => setConfirmModal(false);
  const buttons = <><Button>Button1</Button><Button>Button2</Button></>
  const toUpdateObj = {
    name: props.currentItem.name ? props.currentItem.name : 'No Game Selected',
    boxArtUrlFront: props.currentItem.boxArtUrlFront ? props.currentItem.boxArtUrlFront : 'https://via.placeholder.com/280x150',
    description: props.currentItem.description ? props.currentItem.description : 'No Description Available',
    itemPrice: props.currentItem.itemPrice ? props.currentItem.itemPrice : -1.0,
    condition: props.currentItem.condition ? props.currentItem.condition : 0
  }
  const confirmCancel = {
    title: 'Discard All Changes',
    description: 'Are you sure you wish to DISCARD all changes?',
    buttons: [1, 2, 3]
  }
  return (
    <>
      <Card style={{ height: '40rem' }} onClick={props.handleEditInventory}>

        <Form className="mb-3" onSubmit={handleSubmit}>
          <Form.Group as={Row} className="m-1" controlId="name">
            <Form.Label column sm={2}>Id</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={toUpdateObj.id} disabled />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="name">
            <Form.Label column sm={2}>Name</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={toUpdateObj.name} placeholder='Enter a name...' />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="">
            <Form.Label column sm={2}>Name</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={toUpdateObj.name} placeholder='Enter a name...' />
            </Col>
          </Form.Group>

          <Button type="submit">Update</Button>
          <Button variant="dark" onClick={handleConfirmOpen}>Cancel</Button>
        </Form>
      </Card>
      {confirmModal && <CommonModal
        buttons={buttons}
        displaymodal={confirmModal}
        hidemodal={handleConfirmClose}
        contentobj={confirmCancel}
      />}
    </>
  )
}

export default EditInventoryCard