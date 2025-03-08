import React from "react";
import { Card, Button } from "react-bootstrap";
import "../styles/ProductCard.css"; // Import the CSS file

const ProductCard = ({ product }) => (
  <Card className="product-card d-flex h-100">
    <Card.Img variant="top" src={product.imageUrl} alt={product.name} />
    <Card.Body className="d-flex flex-column">
      <div className="flex-grow-1">
        <Card.Title>{product.name}</Card.Title>
        <Card.Text>{product.description}</Card.Text>
      </div>
      <Button variant="warning" className="mt-auto">Buy - ${product.price}</Button>
    </Card.Body>
  </Card>
);

export default ProductCard;
