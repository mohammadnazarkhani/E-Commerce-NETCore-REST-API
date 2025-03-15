import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import "../styles/Footer.css";

const FooterComponent = () => (
  <footer className="footer-custom-bg">
    <Container>
      <Row>
        <Col className="text-center py-3">
          <p>&copy; 2023 TondForoosh. All rights reserved.</p>
          <p>
            <Link to="/privacy-policy" className="footer-link">Privacy Policy</Link> |{" "}
            <Link to="/terms-of-service" className="footer-link">Terms of Service</Link>
          </p>
        </Col>
      </Row>
    </Container>
  </footer>
);

export default FooterComponent;
