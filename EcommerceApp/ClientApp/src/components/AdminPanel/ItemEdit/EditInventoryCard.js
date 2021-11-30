
import React, { useState } from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import { Button, Col, Row } from 'react-bootstrap';
import CommonModal from '../../Common/CommonModal.js'
function EditInventoryCard(props) {
  console.log('AdminCardProps:', props);

  const [updatedItem] = useState(props.currentItem);
  const [confirmModal, setConfirmModal] = useState(false);
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log('EventValue:', event.target.name.value);
    props.handleCloseEditInv();
  }
  const handleConfirmOpen = () => setConfirmModal(true);
  const handleConfirmClose = () => setConfirmModal(false);

  //confim discard all changes and return to select screen
  const handleDiscardConfirmButton = () => {
    handleConfirmClose();
    props.handleCloseEditInv();
  }
  const confirmCancel = {
    title: 'Discard All Changes',
    description: 'Are you sure you wish to DISCARD all changes?',
    buttons: [1, 2]
  }
  console.log('Edit Inv Card Props:', props);
  return (
    <>
      <Card style={{ height: '40rem' }} onClick={props.handleEditInventory}>

        <Form className="mb-3" onSubmit={handleSubmit}>
          <Form.Group as={Row} className="m-1" controlId="name">
            <Form.Label column sm={2}>Id</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.id} disabled />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="name">
            <Form.Label column sm={2}>Name</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.name} placeholder={'Enter a name...'} />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="description">
            <Form.Label column sm={2}>Description</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.name} placeholder='Enter Description...' />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="gameSystem">
            <Form.Label column sm={2}>Game System</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.gameSystem} placeholder='Enter Game System Name' />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="gameGenre">
            <Form.Label column sm={2}>Genre</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.genre} placeholder='Enter Genre...' />
            </Col>
          </Form.Group>
          <Form.Group as={Row} className="m-1" controlId="gamePrice">
            <Form.Label column sm={2}>Game Price</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" defaultValue={updatedItem.itemPrice} placeholder='Enter a price' />
            </Col>
          </Form.Group>
          <Button type="submit">Update</Button>
          <Button variant="dark" onClick={handleConfirmOpen}>Cancel</Button>
        </Form>
      </Card>
      {confirmModal && <CommonModal
        confirmAction={handleDiscardConfirmButton}
        displaymodal={confirmModal}
        hidemodal={handleConfirmClose}
        contentobj={confirmCancel}
      />}
    </>
  )
}

export default EditInventoryCard