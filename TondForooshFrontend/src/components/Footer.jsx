import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import "../styles/Footer.css"; // Import the CSS file

const Footer = () => (
  <footer className="footer-custom-bg">
    <Container>
      <Row>
        <Col className="text-center py-3">
          <p>&copy; 2023 TondForoosh. All rights reserved.</p>
          <p>
            <a href="/privacy-policy" className="footer-link">Privacy Policy</a> | 
            <a href="/terms-of-service" className="footer-link">Terms of Service</a>
          </p>
        </Col>
      </Row>
    </Container>
  </footer>
);

export default Footer;
