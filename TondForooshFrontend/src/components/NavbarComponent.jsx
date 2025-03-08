import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import "../styles/NavbarComponent.css"; // Import the CSS file

const NavbarComponent = () => (
  <Navbar
    dir="rtl"
    bg="orange"
    variant="dark"
    sticky="top"
    expand="lg"
    className="w-100"
  >
    <Container fluid>
      <Navbar.Brand href="/" className="navbar-brand-custom">
        تند‌فروش
      </Navbar.Brand>
      <Nav className="ms-auto">
        <Nav.Link href="/" className="nav-link-custom">
          خانه
        </Nav.Link>
      </Nav>
    </Container>
  </Navbar>
);

export default NavbarComponent;
