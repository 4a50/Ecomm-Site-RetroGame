import React from 'react'
import ListGroup from 'react-bootstrap/ListGroup'
import InventoryListGroupItem from './InventoryListGroupItem';
function InventoryListGroup(props) {
  return (
    <ListGroup style={{ height: '20rem', overflow: 'scroll', scrollBehavior: 'smooth' }}>
      {props.inventory.map((item, idx) =>
        <InventoryListGroupItem
          currentItem={props.currentItem}
          item={item} idx={idx} key={idx} />
      )}
    </ListGroup>


  )
}
export default InventoryListGroup