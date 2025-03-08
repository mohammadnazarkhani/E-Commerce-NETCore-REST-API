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
    >
      <Container fluid>
        <Navbar.Brand href="/" className="navbar-logo">
          <Logo /> 
        </Navbar.Brand>
        <Nav className="ms-auto">
          <Nav.Link href="/" className="nav-link-custom">
            خانه
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
