import React, { useState, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
const InputModal = (props) => {
  console.log('IMProps', props);
  return (
    <>

      <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
        onHide={props.handleClose}
        show={`${props.showmodal}`}
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Modal heading
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <h4>{props.showmodal}</h4>
          <p>
            Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
            dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac
            consectetur ac, vestibulum at eros.
          </p>
        </Modal.Body>
        <Modal.Footer>
          <Row>
            <Col>
              <Button onClick={props.handleClose} variant="dark">Close</Button>
            </Col>
            <Col>
              <Button onClick={props.handleClose} variant="success">Update</Button>
            </Col>
            <Col>
              <Button onClick={props.handleClose} variant="danger">Remove</Button>
            </Col>
          </Row>
        </Modal.Footer>
      </Modal>
    </>
  )
}

export default InputModal;