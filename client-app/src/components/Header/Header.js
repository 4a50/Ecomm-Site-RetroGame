import { useState, useEffect } from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import SearchForm from './SearchForm.js';
import Button from 'react-bootstrap/Button'
import { Container } from 'react-bootstrap';
function Header(props) {

  return (
    <>
      <Navbar className="p-2" bg="dark" variant="dark">
        <Navbar.Brand href="#home">5-UP Retro Game Shoppe</Navbar.Brand>
        <SearchForm />
        <Navbar.Collapse className="justify-content-end">
          <Navbar.Text className="mx-2">Home</Navbar.Text>
          <Navbar.Text className="mx-2">Browse</Navbar.Text>
          <Navbar.Text className="mx-2">About</Navbar.Text>
          <Navbar.Text className="mx-2">Cart(0)</Navbar.Text>
          <Navbar.Text className="mx-2 text-white">Hello 4a50</Navbar.Text>

        </Navbar.Collapse>
      </Navbar>
    </>
  );
}
export default Header;