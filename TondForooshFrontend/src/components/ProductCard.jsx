import React, { useEffect, useState } from "react";
import { Card, Button } from "react-bootstrap";
import "../styles/ProductCard.css"; // Import the CSS file

const ProductCard = ({ product }) => {
  const [isTouchDevice, setIsTouchDevice] = useState(false);

  useEffect(() => {
    const checkTouchDevice = () => {
      setIsTouchDevice(
        "ontouchstart" in window || navigator.maxTouchPoints > 0
      );
    };
    checkTouchDevice();
  }, []);

  return (
    <Card
      className={`product-card d-flex h-100 ${
        isTouchDevice ? "touch-device" : ""
      }`}
    >
      <div className="price-tag">${product.price}</div>
      <Card.Img variant="top" src={product.imageUrl} alt={product.name} />
      <Card.Body className="d-flex flex-column">
        <Card.Title>{product.name}</Card.Title>
        <Card.Text>{product.description}</Card.Text>
        <Button className="btn-warning mt-auto">Buy</Button>
      </Card.Body>
    </Card>
  );
};

export default ProductCard;
