
import React from 'react';
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
function AdminItemCard(props) {

  return (
    <Card style={{ height: '40rem' }}>
      <Card.Header className='d-flex justify-content-between'><Card.Title className="align-middle">
        {props.currentItem.name ? props.currentItem.name : 'No Game Selected'}</Card.Title>
        <Button onClick={props.handleShowModal}>Edit</Button>
      </Card.Header>
      <Card.Img style={{ height: '20rem' }} src={props.currentItem.boxArtUrlFront ? props.currentItem.boxArtUrlFront : 'https://via.placeholder.com/280x150'} />
      <Card.Body style={{ overflow: 'scroll' }}>{props.currentItem.description ? props.currentItem.description : 'No Description Available'}</Card.Body>
    </Card>
  )
}

export default AdminItemCard