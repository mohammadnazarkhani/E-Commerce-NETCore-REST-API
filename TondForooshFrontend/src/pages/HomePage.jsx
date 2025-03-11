import React, { useEffect, useState } from "react";
import { Container, Row, Col, Alert, Spinner } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import ProductCard from "../components/ProductCard";

const HomePage = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    setLoading(true);
    axiosInstance
      .get("/home/products")
      .then((response) => {
        setProducts(response.data);
        setError(null);
      })
      .catch((error) => {
        console.error("Error fetching products:", error);
        setError("Failed to load products. Please try again later.");
      })
      .finally(() => setLoading(false));
  }, []);

  const handleProductClick = (productId) => {
    navigate(`/product/${productId}`);
  };

  if (loading) {
    return (
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: "400px" }}>
        <Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>
      </Container>
    );
  }

  if (error) {
    return (
      <Container className="mt-4">
        <Alert variant="danger">{error}</Alert>
      </Container>
    );
  }

  return (
    <Container className="mt-4 px-3 mb-5">
      <Row className="g-4">
        {products.length === 0 ? (
          <Col>
            <Alert variant="info">No products available.</Alert>
          </Col>
        ) : (
          products.map((product) => (
            <Col key={product.id} md={4} sm={6} xs={12}>
              <ProductCard
                product={product}
                onClick={() => handleProductClick(product.id)}
              />
            </Col>
          ))
        )}
      </Row>
    </Container>
  );
};

export default HomePage;
