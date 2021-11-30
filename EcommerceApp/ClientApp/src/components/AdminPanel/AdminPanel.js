import React, { useState, useEffect } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import SelectedCard from './AdminItemCard.js';
import EditInventoryCard from './ItemEdit/EditInventoryCard.js'
import InventoryListGroup from './InventoryListGroup.js';
import inventoryList from '../../sampleData/sampleServerResponse.json';
import defaultObj from '../../data/noData.json'


const AdminPanel = (props) => {
  const [currentItem, setCurrentItem] = useState({});
  const [inventory, setInventory] = useState([]);
  const [editInventory, setEditInventory] = useState(false);
  useEffect(() => {
    let invList = inventoryList;
    invList.unshift(defaultObj);
    setInventory(invList);
  }, []);

  const handleCloseEditInv = () => setEditInventory(false);
  const handleEditInv = () => setEditInventory(true);
  console.log('currentItem:', currentItem);
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
        <Col>
          {editInventory ? <EditInventoryCard
            currentItem={currentItem}
            handleCloseEditInv={handleCloseEditInv} /> :
            <SelectedCard
              currentItem={currentItem}
              handleEditInventory={handleEditInv}
              handleCloseEditInv={handleCloseEditInv}
            />}
        </Col>
      </Row>
      <Row>


      </Row>
    </>
  )
}

export default AdminPanel;