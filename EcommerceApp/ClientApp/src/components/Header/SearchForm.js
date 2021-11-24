
import React, { useState, useEffect } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import placeHolder from '../data/placeholder.json'

function SearchForm(props) {

  const [placeHolderString, setPlaceHolderString] = useState('');
  useEffect(() => {
    let rand = Math.round(Math.random() * ((placeHolder.length - 1) - Math.floor(0)) + 0);
    console.log(rand, placeHolder.length);
    setPlaceHolderString(placeHolder[rand].name);
  }, []);
  return (
    <div className="d-flex flex-inline">
      <Form style={{
        width: "20rem"
      }}>
        <Form.Control placeholder={placeHolderString} />
      </Form>
      <Button className="mx-2" variant="secondary" >Search</Button>
    </div>
  )
}
export default SearchForm;