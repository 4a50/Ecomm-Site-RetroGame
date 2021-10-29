import React, { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import InputModal from './InputModal.js'
const AdminPanel = (props) => {
  const [currentItem, setCurrentItem] = useState([]);
  const [inventory, setInventory] = useState([]);
  const [showModal, setShowModal] = useState(false);

  const handleClose = () => setShowModal(false);
  const handleOpen = () => setShowModal(true);
  return (
    <>
      <h1>Administration Panel</h1>
      <h3>Welcome Name Here</h3>
      <Button onClick={handleOpen}>ShowModal</Button>
      {showModal && <InputModal showmodal={showModal} handleClose={handleClose} />}
    </>
  )
}

export default AdminPanel;