import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import "../styles/NavbarComponent.css";
import Logo from "./Logo";

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
        <Navbar.Brand as={Link} to="/" className="navbar-logo">
          <Logo />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            <Nav.Link as={Link} to="/" className="nav-link-custom">
              خانه
            </Nav.Link>
            <Nav.Link as={Link} to="/categories" className="nav-link-custom">
              دسته‌بندی‌ها
            </Nav.Link>
            <Nav.Link as={Link} to="/create/product" className="nav-link-custom">
              افزودن محصول
            </Nav.Link>
            <Nav.Link as={Link} to="/create/category" className="nav-link-custom">
              افزودن دسته‌بندی
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
