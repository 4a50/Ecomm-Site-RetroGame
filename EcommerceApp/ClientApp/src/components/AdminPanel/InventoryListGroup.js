import React from 'react'
import { ListGroup, Col, Row, Tab } from 'react-bootstrap'
import InventoryListGroupItem from './InventoryListGroupItem';
function InventoryListGroup(props) {

  const handleItemSelect = (itemNum) => {
    console.log('clicked Item = ', itemNum);
  }
  console.log('InvListProps:', props);
  const itemClicker = (e) => { console.log(e) }
  return (
    <ListGroup style={{ height: '40rem', overflow: 'scroll', scrollBehavior: 'smooth' }}>
      {props.inventory.map((item, idx) =>
        <InventoryListGroupItem
          currentItem={props.currentItem}
          item={item} idx={idx} key={idx} />
      )}
    </ListGroup>


  )
}
export default InventoryListGroup