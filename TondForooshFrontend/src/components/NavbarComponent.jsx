import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import "../styles/NavbarComponent.css"; // Import the CSS file
import Logo from "./Logo"; // Import the Logo component

const NavbarComponent = () => {
  return (
    <Navbar
      dir="rtl"
      variant="dark"
      sticky="top"
      expand="lg"
      className="w-100 navbar-custom-bg"
      bg="dark"
    >
      <Container fluid>
        <Navbar.Brand href="/" className="navbar-logo">
          <Logo /> 
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            <Nav.Link href="/" className="nav-link-custom">
              خانه
            </Nav.Link>
            <Nav.Link href="/create/product" className="nav-link-custom">
              افزودن محصول
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
