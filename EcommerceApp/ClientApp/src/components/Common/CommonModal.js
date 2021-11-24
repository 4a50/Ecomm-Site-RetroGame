import React from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button'

const CommonModal = (props) => {
  console.log('CommonModalProps:', props);
  //Required props: 
  //  contentObj={title, description, buttons[2,3...] }   
  //  displayModal=bool
  //  hideModal=function

  //button codes 1 - Confirm, 2 - Go Back, 3 - goback
  const createButtons = () => {
    return props.contentobj.buttons.map((btn, idx) => {
      switch (btn) {
        case 1:
          return <Button key={idx} variant="danger" onClick={props.hidemodal}>Confirm</Button>
        case 2:
          return <Button key={idx} variant="dark" onClick={props.hidemodal}>Cancel</Button>
        case 3:
          return <Button key={idx} variant="dark" onClick={props.hidemodal}>Go Back</Button>

        default:
          return <Button>Invalid</Button>
      }

    })
  }

  return (
    <>
      <Modal
        // {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        show={props.displaymodal}
        onHide={props.hidemodal}
        centered

      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            {props.contentobj.title}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <h6>{props.contentobj.description}</h6>
        </Modal.Body>
        <Modal.Footer>
          {createButtons()}
        </Modal.Footer>
      </Modal>
    </>
  )
}

export default CommonModal;