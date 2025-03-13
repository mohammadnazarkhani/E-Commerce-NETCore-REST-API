import React from "react";
import NavbarComponent from "../components/NavbarComponent";
import FooterComponent from "../components/FooterComponent";
import { Outlet } from 'react-router-dom';
import { Container } from 'react-bootstrap';
import './MainLayout.css'; // Import the CSS file for custom styles

const MainLayout = () => {
  return (
    <>
      <NavbarComponent />
      <Container fluid className="main-content">
        <Outlet />
      </Container>
      <FooterComponent />
    </>
  );
};

export default MainLayout;
