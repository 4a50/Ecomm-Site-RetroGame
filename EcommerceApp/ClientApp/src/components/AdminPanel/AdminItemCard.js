
import React from 'react';
import Card from 'react-bootstrap/Card'
import InventoryCardCore from '../Common/InventoryCardCore';
function AdminItemCard(props) {
  console.log('AdminCardProps:', props);
  const selectItemObj = {
    name: props.currentItem.name ? props.currentItem.name : 'No Game Selected',
    boxArtUrlFront: props.currentItem.boxArtUrlFront ? props.currentItem.boxArtUrlFront : 'https://via.placeholder.com/280x150',
    description: props.currentItem.description ? props.currentItem.description : 'No Description Available',
    itemPrice: props.currentItem.itemPrice ? props.currentItem.itemPrice : -1.0,
    condition: props.currentItem.condition ? props.currentItem.condition : 0
  }
  return (
    <>
      <Card style={{ height: '40rem' }} onClick={props.handleEditInventory}>
        <InventoryCardCore item={selectItemObj} />
        <Card.Footer>
        </Card.Footer>
      </Card>
    </>
  )
}

export default AdminItemCard