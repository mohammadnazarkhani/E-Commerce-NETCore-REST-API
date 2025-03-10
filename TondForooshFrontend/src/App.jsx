import React, { useEffect, useState } from "react";
import { Container, Row, Col } from "react-bootstrap";
import axiosInstance from "./axiosInstance";
import NavbarComponent from "./components/NavbarComponent";
import ProductCard from "./components/ProductCard";
import Footer from "./components/Footer"; // Import the Footer component
import "./styles/ProductCard.css"; // Import the ProductCard CSS file

function App() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axiosInstance
      .get("/home/products")
      .then((response) => setProducts(response.data))
      .catch((error) => console.error("Error fetching products:", error));
  }, []);

  return (
    <div>
      {/* Navbar */}
      <NavbarComponent />
      {/* Products Section */}
      <Container className="mt-4 px-3 mb-5">
        {" "}
        {/* Adds some padding to prevent overflow and space from footer */}
        <Row className="g-4">
          {products.map((product) => (
            <Col key={product.id} md={4} sm={6} xs={12}>
              <ProductCard product={product} />
            </Col>
          ))}
        </Row>
      </Container>
      {/* Footer */}
      <Footer /> {/* Add the Footer component */}
    </div>
  );
}

export default App;
