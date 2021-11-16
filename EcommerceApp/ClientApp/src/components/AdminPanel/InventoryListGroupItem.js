import React from 'react'
import { ListGroup, Col, Row, Tab } from 'react-bootstrap'

function InventoryListGroupItem(props) {

  return (
    <ListGroup.Item onClick={() => { props.currentItem(props.item); }} eventKey={props.idx}>{props.item.name}</ListGroup.Item>
  )
}
export default InventoryListGroupItem