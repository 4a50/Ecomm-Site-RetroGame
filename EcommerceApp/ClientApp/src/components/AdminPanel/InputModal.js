import React, { useState, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal';
import CarouselCard from '../Carousel/CarouselCard.js'
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
const InputModal = (props) => {
  console.log('IMProps', props);
  return (
    <>

      <Modal
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
        onHide={props.handleClose}
        show={`${props.showmodal}`}
      >
        <CarouselCard item={props.item} />

      </Modal>
    </>
  )
}

export default InputModal;