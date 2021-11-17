import React from 'react'
import ListGroup from 'react-bootstrap/ListGroup'

function InventoryListGroupItem(props) {

  return (
    <ListGroup.Item onClick={() => { props.currentItem(props.item); }} eventKey={props.idx}>{props.item.name}</ListGroup.Item>
  )
}
export default InventoryListGroupItem