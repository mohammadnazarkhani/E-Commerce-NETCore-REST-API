import React, { useEffect, useState } from "react";
import { Container, Row, Col } from "react-bootstrap";
import axiosInstance from "../axiosInstance";
import ProductCard from "../components/ProductCard";

const HomePage = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axiosInstance
      .get("/home/products")
      .then((response) => setProducts(response.data))
      .catch((error) => console.error("Error fetching products:", error));
  }, []);

  return (
    <>
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
    </>
  );
};

export default HomePage;
