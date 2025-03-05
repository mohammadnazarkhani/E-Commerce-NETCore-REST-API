import React from 'react'; 
import { Navbar, Nav, Container } from 'react-bootstrap';

const NavbarComponent = () => (
  <Navbar bg="dark" variant="dark" expand="lg" className="w-100">
    <Container fluid>
      <Navbar.Brand href="/">TondForoosh</Navbar.Brand>
      <Nav className="me-auto">
        <Nav.Link href="#home">Home</Nav.Link>
        <Nav.Link href="#products">Products</Nav.Link>
      </Nav>
    </Container>
  </Navbar>
);

export default NavbarComponent;
