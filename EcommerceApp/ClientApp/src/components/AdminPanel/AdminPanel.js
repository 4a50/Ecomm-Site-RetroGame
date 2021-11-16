import React, { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import InputModal from './InputModal.js'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Card from 'react-bootstrap/Card';
import InventoryListGroup from './InventoryListGroup.js';
import inventoryList from '../../sampleData/sampleServerResponse.json'

const AdminPanel = (props) => {
  const [currentItem, setCurrentItem] = useState([]);
  const [inventory, setInventory] = useState(inventoryList);
  const [showModal, setShowModal] = useState(false);

  const handleClose = () => setShowModal(false);
  const handleOpen = () => setShowModal(true);
  return (
    <>
      <Row>
        <h1>Administration Panel</h1>
        <h3>Welcome Name Here</h3>
      </Row>
      <Row>
        <Col>
          <InventoryListGroup currentItem={setCurrentItem} inventory={inventory} />
        </Col>
        {currentItem &&
          <Col>
            <Card>
              <Card.Header>{currentItem.name}
                <Button>Edit</Button></Card.Header>
              <Card.Img style={{ height: '20rem' }} src={currentItem.boxArtUrlFront} />
              <Card.Body>{currentItem.description}</Card.Body>
            </Card>
          </Col>
        }
      </Row>
      <Row>
        <Button onClick={handleOpen}>ShowModal</Button>
        {showModal && <InputModal showmodal={showModal} handleClose={handleClose} />}

      </Row>

    </>
  )
}

export default AdminPanel;