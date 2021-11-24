import React from 'react';
import Modal from 'react-bootstrap/Modal';
import Card from 'react-bootstrap/Card';
import InventoryCardCore from '../Common/InventoryCardCore.js';

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
        <Card>
          <InventoryCardCore item={props.item} />

        </Card>

      </Modal>
    </>
  )
}

export default InputModal;